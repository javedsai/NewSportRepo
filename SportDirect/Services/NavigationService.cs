using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Acr.UserDialogs;
using SportDirect.Areas.ViewModels;
using SportDirect.Areas.Views;
using SportDirect.Helpers;
using SportDirect.Interfaces;
using SportDirect.Services.Interfaces;
using SportDirect.ViewModels;
using Plugin.Connectivity;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using XF.Material.Forms.UI;
using SportDirect.Areas.Authentication.Views;
using SportDirect.Areas.Authentication.ViewModels;
using SportDirect.Areas.PopUp;
using SportDirect.Areas.Views.MasterDetailsPage.ViewModels;
using SportDirect.Areas.Views.MasterDetailsPage;
using SportDirect.Data.Models.Request;
using SportDirect.Service.Interfaces;
using Xamarin.Essentials;

namespace SportDirect.Services
{
    public class NavigationService : INavigationService
    {
        protected readonly IList<Tuple<Type, Type, bool>> _mappings;
        protected Application CurrentApplication
        {
            get { return Application.Current; }
        }

        public IList<Tuple<Type, Type, bool>> _mappingsRead { get => _mappings; }

        //Re-Exposed Navigation events for hooking into page changes
        public EventHandler ModalPopped;
        public EventHandler ModalPushed;

        public NavigationService(IApiService apiService)
        {
            _apiService = apiService;
            CurrentApplication.ModalPopped += (sender, e) => ModalPopped?.Invoke(sender, e);
            CurrentApplication.ModalPushed += (sender, e) => ModalPushed?.Invoke(sender, e);

            _mappings = new List<Tuple<Type, Type, bool>>();

            CreatePageViewModelMappings();
        }
        public IApiService _apiService;

        public async Task InitializeAsync()
        {
            //await _userService.Initialization; // if we need to fetch any data before navigating to any page      

            //try
            //{
            //    var location = await Geolocation.GetLastKnownLocationAsync();
            //    if (location != null)
            //    {

            //        var placemarks = await Geocoding.GetPlacemarksAsync(location.Latitude, location.Longitude);
            //        var placemark = placemarks?.FirstOrDefault();
            //        if (placemark != null)
            //        {
            //            App.CurrentCountryCode = placemark.CountryCode;
            //        }

            //    }
            //}
            //catch (FeatureNotSupportedException fnsEx)
            //{
            //    // Handle not supported on device exception  
            //}
            //catch (PermissionException pEx)
            //{
            //    // Handle permission exception  
            //}
            //catch (Exception ex)
            //{
            //    // Unable to get location  
            //}


            if (Settings.IsDarkMode == true)
            {
                Settings.notificationOnOff = "On";
            }
            else
            {
                Settings.notificationOnOff = "Off";
            }
            if (Settings.OrderNotiOnOffIsToggled == true)
            {
                Settings.orderNotiOnOff = "On";
            }
            else
            {
                Settings.orderNotiOnOff = "Off";
            }
            if (Settings.OffersNotiOnOffIsToggled == true)
            {
                Settings.offersNotiOnOff = "On";
            }
            else
            {
                Settings.offersNotiOnOff = "Off";
            }
            if (Settings.IsWalkthroughCompleted == true)
            {
                 if (!string.IsNullOrEmpty(Settings.Customer_Access_Token))
                    {
                        App.Current.MainPage = new NavigationPage(new MainMenu());
                    }
                    else
                    {
                        App.Current.MainPage = new NavigationPage(new LoginPage());
                    }
            }
            else
            {
                App.Current.MainPage = new NavigationPage(new LoginPage());
                //await NavigateToAsync<LanguagePageViewModel>();
            }
        }
        public Task NavigateToAsync<TViewModel>(TViewModel viewModel) where TViewModel : BasePageViewModel
        {
            return InternalNavigateToAsync(typeof(TViewModel), viewModel, null);
        }
        public Task NavigateToAsync<TViewModel>() where TViewModel : BasePageViewModel
        {
            return InternalNavigateToAsync(typeof(TViewModel), null, null);
        }
        public Task NavigateToAsync<TViewModel>(object parameter) where TViewModel : BasePageViewModel
        {
            return InternalNavigateToAsync(typeof(TViewModel), null, parameter);
        }
        public Task NavigateToAsync(Type viewModelType)
        {
            return InternalNavigateToAsync(viewModelType, null, null);
        }
        public Task NavigateToAsync(Type viewModelType, object parameter)
        {
            return InternalNavigateToAsync(viewModelType, null, parameter);
        }

        public async Task ShellGoToAsync(string route)
        {
            await Shell.Current.GoToAsync(route);
        }

        public async Task ShellNavigationPushAsync(Page page)
        {
            await Shell.Current.Navigation.PushAsync(page);
        }

        public async Task ShellGoBackAsync()
        {
            Shell.Current.SendBackButtonPressed();
        }

        public async Task ShellNavigationPopAsync()
        {
            await Shell.Current.Navigation.PopAsync();
        }

        public async Task ShellNavigationPopToRootAsync()
        {
            await Shell.Current.Navigation.PopToRootAsync();
        }

        public async Task NavigateBackAsync()
        {
            if (CurrentApplication.MainPage != null)
            {
                await CurrentApplication.MainPage.Navigation.PopAsync();
            }
        }

        public Type GetCurrentPageViewModel()
        {
            if (CurrentApplication.MainPage != null)
            {
                Page currentPage = CurrentApplication.MainPage.Navigation.NavigationStack.Last();
                if (currentPage?.BindingContext != null)
                    return currentPage.BindingContext.GetType();
            }
            return null;
        }

        public bool SetCurrentPageTitle(string title)
        {
            if (!string.IsNullOrEmpty(title))
            {
                Page currentPage = CurrentApplication.MainPage.Navigation.NavigationStack.Last();
                if (currentPage != null)
                {
                    currentPage.Title = title;
                    return true;
                }
            }
            return false;
        }

        public virtual Task RemoveLastFromBackStackAsync()
        {
            var mainPage = CurrentApplication.MainPage as Page;

            mainPage.Navigation.RemovePage(
                mainPage.Navigation.NavigationStack[mainPage.Navigation.NavigationStack.Count - 2]);

            return Task.FromResult(true);
        }

        public Task NavigateToPopupAsync<TViewModel>(bool animate, TViewModel viewModel) where TViewModel : BasePageViewModel
        {
            return NavigateToPopupAsync(null, animate, viewModel);
        }

        public async Task NavigateToPopupAsync<TViewModel>(object parameter, bool animate, TViewModel vieModel) where TViewModel : BasePageViewModel
        {
            var page = CreateAndBindPage(typeof(TViewModel), vieModel, parameter, true);

            await (page.BindingContext as BasePageViewModel).InitializeAsync(parameter);

            if (page is PopupPage)
            {
                await PopupNavigation.Instance.PushAsync(page as PopupPage, animate);
            }
            else
            {
                throw new ArgumentException($"The type ${ typeof(TViewModel)}its not a PopupPage type");
            }
        }

        public async Task CloseAllPopupsAsync()
        {
            await PopupNavigation.Instance.PopAllAsync(true);
        }

        public async Task ClosePopupsAsync()
        {
            await PopupNavigation.Instance.PopAsync(true);
        }

        protected virtual async Task InternalNavigateToAsync(Type viewModelType, object viewModel, object parameter)
        {
            Page page = CreateAndBindPage(viewModelType, viewModel, parameter, false);

            if (page is IRootView)
            {
                //TODO prob need to check the navigation stack at this point to ensure there are no pages on top??
                if (page is IMainView)
                {
                    if (page is IShelll)
                    {
                        object bindingContext = page.BindingContext;
                        //page = new MaterialNavigationPage(page);
                        page.BindingContext = bindingContext;
                    }
                    else
                    {
                        object bindingContext = page.BindingContext;
                        page = new MaterialNavigationPage(page);
                        page.BindingContext = bindingContext;
                    }
                }
                CurrentApplication.MainPage = page;
            }
            else if (CurrentApplication.MainPage is IMainView || CurrentApplication.MainPage is MaterialNavigationPage) // Implemented as an interface so we can have different main views on different platforms
            {
                var mainPage = CurrentApplication.MainPage as Page;

                if (mainPage.GetType() != page.GetType())
                {
                    var transitionNavigationPage = CurrentApplication.MainPage as MaterialNavigationPage;
                    if (transitionNavigationPage != null)
                    {
                        await mainPage.Navigation.PushAsync(page);
                    }
                }
            }
            await (page.BindingContext as BasePageViewModel).InitializeAsync(parameter);
        }

        protected Type GetPageTypeForViewModel(Type viewModelType, bool isPopup)
        {
            Type pageType = null;
            if (!isPopup)
                pageType = _mappings.FirstOrDefault(_ => (_.Item1 == viewModelType) && !_.Item3).Item2;
            else
                pageType = _mappings.FirstOrDefault(_ => (_.Item1 == viewModelType) && _.Item3).Item2;

            if (pageType == null)
                throw new KeyNotFoundException($"No map for ${viewModelType} was found on navigation mappings");

            return pageType;
        }

        protected Page CreateAndBindPage(Type viewModelType, object viewModelObj, object parameter, bool isPopup)
        {
            Type pageType = GetPageTypeForViewModel(viewModelType, isPopup);
            Page page = null;
            if (pageType == null)
                throw new Exception($"Mapping type for {viewModelType} is not a page");
            try
            {
                page = Activator.CreateInstance(pageType) as Page;
                BasePageViewModel viewModel;

                if (viewModelObj != null)
                    viewModel = viewModelObj as BasePageViewModel;
                else
                    viewModel = App.Container.GetInstance(viewModelType) as BasePageViewModel;

                page.BindingContext = viewModel;
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Code result's in {e.Message}");
            }
            return page;
        }

        private void CreatePageViewModelMappings()
        {
            //Pages
            _mappings.Add(new Tuple<Type, Type, bool>(typeof(MainPageViewModel), typeof(MainPage), false));
            _mappings.Add(new Tuple<Type, Type, bool>(typeof(AppShellPageViewModel), typeof(AppShell), false));
            _mappings.Add(new Tuple<Type, Type, bool>(typeof(CheckInternetPageViewModel), typeof(CheckInternetPage), false));
            _mappings.Add(new Tuple<Type, Type, bool>(typeof(MainMenuViewModel), typeof(MainMenu), false));
            _mappings.Add(new Tuple<Type, Type, bool>(typeof(HomeViewModel), typeof(Home), false));
            _mappings.Add(new Tuple<Type, Type, bool>(typeof(LanguagePageViewModel), typeof(LanguagePage), false));
            _mappings.Add(new Tuple<Type, Type, bool>(typeof(SignupPageViewModel), typeof(SignupPage), false));
            _mappings.Add(new Tuple<Type, Type, bool>(typeof(LoginPageViewModel), typeof(LoginPage), false));
            _mappings.Add(new Tuple<Type, Type, bool>(typeof(SaveAddressPageViewModel), typeof(SaveAddressPage), false));
            _mappings.Add(new Tuple<Type, Type, bool>(typeof(RegisterPageViewModel), typeof(RegisterPage), false));
            _mappings.Add(new Tuple<Type, Type, bool>(typeof(SettingPageViewModel), typeof(SettingPage), false));
            _mappings.Add(new Tuple<Type, Type, bool>(typeof(AddNewAddressViewModel), typeof(AddNewAddress), false));
            _mappings.Add(new Tuple<Type, Type, bool>(typeof(EditSaveAddressViewModel), typeof(EditSaveAddress), false));
            _mappings.Add(new Tuple<Type, Type, bool>(typeof(CustomersPageViewModel), typeof(CustomersPage), false));
            _mappings.Add(new Tuple<Type, Type, bool>(typeof(ProductsPageViewModel), typeof(ProductsPage), false));
            _mappings.Add(new Tuple<Type, Type, bool>(typeof(SportPageViewModel), typeof(SportPage), false));
            _mappings.Add(new Tuple<Type, Type, bool>(typeof(OffersPageViewModel), typeof(OffersPage), false));
            _mappings.Add(new Tuple<Type, Type, bool>(typeof(NewsDetailsPageViewModel), typeof(NewsDetailsPage), false));
            _mappings.Add(new Tuple<Type, Type, bool>(typeof(BlogsPageViewModel), typeof(BlogsPage), false));
            _mappings.Add(new Tuple<Type, Type, bool>(typeof(BlogsDetailsPageViewModel), typeof(BlogsDetailsPage), false));
            _mappings.Add(new Tuple<Type, Type, bool>(typeof(MyOrderPageViewModel), typeof(MyOrderPage), false));
            _mappings.Add(new Tuple<Type, Type, bool>(typeof(MyOrderDetailsPageViewModel), typeof(MyOrderDetailsPage), false));
            _mappings.Add(new Tuple<Type, Type, bool>(typeof(ProfilePageViewModel), typeof(ProfilePage), false));
            _mappings.Add(new Tuple<Type, Type, bool>(typeof(MyReviewsPageViewModel), typeof(MyReviewsPage), false));
            _mappings.Add(new Tuple<Type, Type, bool>(typeof(EditMyReviewsPageViewModel), typeof(EditMyReviewsPage), false));
            _mappings.Add(new Tuple<Type, Type, bool>(typeof(AccountSettinPageViewModel), typeof(AccountSettinPage), false));
            _mappings.Add(new Tuple<Type, Type, bool>(typeof(CartPageViewModel), typeof(CartPage), false));
            _mappings.Add(new Tuple<Type, Type, bool>(typeof(EditCartPageViewModel), typeof(EditCartPage), false));
            _mappings.Add(new Tuple<Type, Type, bool>(typeof(PaymentPageViewModel), typeof(PaymentPage), false));
            _mappings.Add(new Tuple<Type, Type, bool>(typeof(SuccessPopupViewModel), typeof(SuccessPopup), false));
            _mappings.Add(new Tuple<Type, Type, bool>(typeof(ProductViewPageViewModel), typeof(ProductViewPage), false));
            _mappings.Add(new Tuple<Type, Type, bool>(typeof(FilterPageViewModel), typeof(FilterPage), false));
            _mappings.Add(new Tuple<Type, Type, bool>(typeof(ProductDetailsPageViewModel), typeof(ProductDetailsPage), false));
            _mappings.Add(new Tuple<Type, Type, bool>(typeof(MainMenuMasterViewModel), typeof(MainMenuMaster), false));
            _mappings.Add(new Tuple<Type, Type, bool>(typeof(PromotionPageViewModel), typeof(PromotionPage), false));
            _mappings.Add(new Tuple<Type, Type, bool>(typeof(BookInstallationViewModel), typeof(BookInstallation), false));
            _mappings.Add(new Tuple<Type, Type, bool>(typeof(WarningAdviceViewModel), typeof(WarningAdvice), false));
            _mappings.Add(new Tuple<Type, Type, bool>(typeof(AboutUsPageViewModel), typeof(AboutUsPage), false));
            _mappings.Add(new Tuple<Type, Type, bool>(typeof(TermsPageViewModel), typeof(TermsPage), false));
            _mappings.Add(new Tuple<Type, Type, bool>(typeof(OurPolicyViewModel), typeof(OurPolicy), false));
            _mappings.Add(new Tuple<Type, Type, bool>(typeof(MyFavoritesViewModel), typeof(MyFavorites), false));
            _mappings.Add(new Tuple<Type, Type, bool>(typeof(ContactusViewModel), typeof(Contactus), false));
            _mappings.Add(new Tuple<Type, Type, bool>(typeof(PrivacySecurityViewModel), typeof(PrivacySecurity), false));
            _mappings.Add(new Tuple<Type, Type, bool>(typeof(ReferAFriendViewModel), typeof(ReferAFriend), false));
            _mappings.Add(new Tuple<Type, Type, bool>(typeof(FAQsPageViewModel), typeof(FAQsPage), false));
            _mappings.Add(new Tuple<Type, Type, bool>(typeof(BusinessLocationViewModel), typeof(BusinessLocation), false));
            _mappings.Add(new Tuple<Type, Type, bool>(typeof(GetQuotePageViewModel), typeof(GetQuotePage), false));
            _mappings.Add(new Tuple<Type, Type, bool>(typeof(GetQuoteDetailsPageViewModel), typeof(GetQuoteDetailsPage), false));
            _mappings.Add(new Tuple<Type, Type, bool>(typeof(OrderTrackingViewModel), typeof(OrderTracking), false));
            _mappings.Add(new Tuple<Type, Type, bool>(typeof(LiveCustomerServiceViewModel), typeof(LiveCustomerService), false));
            _mappings.Add(new Tuple<Type, Type, bool>(typeof(ComplexPageViewModel), typeof(ComplexPage), false));
            _mappings.Add(new Tuple<Type, Type, bool>(typeof(FeaturedProductPageViewModel), typeof(FeaturedProductPage), false));
            _mappings.Add(new Tuple<Type, Type, bool>(typeof(NotificationPageViewModel), typeof(NotificationPage), false));
            _mappings.Add(new Tuple<Type, Type, bool>(typeof(SortPageViewModel), typeof(SortPage), true));
            _mappings.Add(new Tuple<Type, Type, bool>(typeof(ForgetPasswordPageViewModel), typeof(ForgetPasswordPage), true));
            _mappings.Add(new Tuple<Type, Type, bool>(typeof(ZoomImagePopUpViewModel), typeof(ZoomImagePopUp), false));
            //PopupViews
            //_mappings.Add(new Tuple<Type, Type, bool>(typeof(SaleNotesContextPopupViewModel), typeof(SaleNotesContextPopup), true));
            //_mappings.Add(new Tuple<Type, Type, bool>(typeof(SelectNoteTypePopupViewModel), typeof(SelectNoteTypePopup), true));
        }
    }
}
