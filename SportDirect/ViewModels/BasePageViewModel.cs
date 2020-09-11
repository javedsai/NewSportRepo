using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using SportDirect.Core.Models.Result;
using SportDirect.Resources;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using SportDirect.Resources;
using Xamarin.Forms;
using XF.Material.Forms.UI.Dialogs;
using XF.Material.Forms.UI.Dialogs.Configurations;
using Plugin.Connectivity;
using SportDirect.Areas.Views.MasterDetailsPage;
using Acr.UserDialogs;
using SportDirect.Services;
using SportDirect.Core.Helpers;

namespace SportDirect.ViewModels
{
    public class BasePageViewModel : ViewModelBase
    {
        protected NavigationPage _navigation => (Application.Current.MainPage as NavigationPage) ?? Application.Current.MainPage as NavigationPage;
        private bool _isEnabled;
        private string _title;
        private object _parameter;
        private IMaterialModalPage loadingDialog;

        public Services.Interfaces.INavigationService NavigationService;
        public RelayCommand GoBackCommand { get; set; }
        public RelayCommand GetBackCommand { get; set; }
        public RelayCommand CancelPopupCommand { get; set; }
       // public ICommand IsPresentTrueCommand { get; set; }

        public bool IsInitialized { get; protected set; }
        public string PageName => this.GetType().Name;

        public string Title
        {
            get => _title;
            set => Set(ref _title, value);
        }

        public bool IsEnabled
        {
            get => _isEnabled;
            set => Set(ref _isEnabled, value);
        }

        public object Parameter
        {
            get => _parameter;
            set => Set(ref _parameter, value);
        }

        public MaterialAlertDialogConfiguration alertDialogConfiguration = new MaterialAlertDialogConfiguration
        {
            BackgroundColor = (Color)App.AppInstance.Resources["PrimaryColor"],
            TitleTextColor = (Color)App.AppInstance.Resources["Text2ColorBold"],
            MessageTextColor = (Color)App.AppInstance.Resources["Text2Color"],
            TintColor = (Color)App.AppInstance.Resources["Text2ColorBold"],
            CornerRadius = 8,
            ButtonAllCaps = false
        };

        public BasePageViewModel()
        {
            Title = AppResources.OurServicesTxt;
            // initialize only if has pushed
            NavigationService = App.Container.GetInstance<Services.Interfaces.INavigationService>();
            GoBackCommand = new RelayCommand(async () => { await NavigationService.NavigateBackAsync(); });
            GetBackCommand = new RelayCommand(async () => { await App.Current.MainPage.Navigation.PopModalAsync(); });
            CancelPopupCommand = new RelayCommand(async () => { await NavigationService.ClosePopupsAsync(); });
           // IsPresentTrueCommand = new Command(HamburgerMenuChange);
            Initialize();
        }
        //private void HamburgerMenuChange(Object obj)
        //{
        //    if (AppShell.Current.FlyoutIsPresented)
        //    {
        //        AppShell.Current.FlyoutIsPresented = false;
        //    }
        //    else
        //    {
        //        AppShell.Current.FlyoutIsPresented = true;
        //    }
        //}
        ~BasePageViewModel()
        {
            
        }
        public Command GoToBackCmd
        {
            get
            {
                return new Command(async () =>
                {
                    await _navigation.PopAsync();
                });
            }
        }
         public ICommand IsPresentTrueCommand2 => new Command(async () =>
         {
             try
             {
                 MainMenu.Current.IsPresented = true;
             }
             catch (Exception ex)
             {
                 UserDialogs.Instance.Alert(ex.Message);
             }            
         });
         public ICommand IsPresentFalseCommand2 => new Command(async () =>
         {
             try
             {
                 MainMenu.Current.IsPresented = false;
             }
             catch (Exception ex)
             {
                 UserDialogs.Instance.Alert(ex.Message);
             }
         });
        public ICommand InternetConnectionCmd => new Command(async () =>
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                await NavigationService.NavigateBackAsync();
            }
        });
        /// <summary>
        /// Tries to call a service method and shows the user an error if the request isn't successful
        /// </summary>
        /// <typeparam name="TType"></typeparam>
        /// <param name="action"></param>
        /// <param name="setLoading"></param>
        /// <param name="failWithToast"></param>
        /// <returns></returns>
        protected async Task<Result<TType>> TryWithErrorAsync<TType>(
            Task<Result<TType>> action,
            bool setLoading = false,
            bool failWithToast = false
            )
        {
            Result<TType> result = null;
            try
            {
                if (setLoading)
                    await ShowLoading();
                result = await action;
                if (setLoading)
                    await HideLoading();
                if (result?.ResultType != ResultType.Ok)
                {
                    // special case for unauthorized. Boot them back to the start.
                    if (result.ResultType == ResultType.Unauthorized)
                    {
                        await ShowAlert("Looks Like Your Session Has Expired! Please Sign Back In.", "Session Expired", "Ok");
                    }
                    else if (result.ResultType == ResultType.PartialOk)
                    {
                        Debug.WriteLine("Partial OK request detected");
                        if (failWithToast)
                            ShowAlert("Not all data was able to sync.");
                    }
                    else
                    {
                        // otherwise, continue with the error handling
                        var errorMessage = result?.Errors?.FirstOrDefault();
                        if  (!failWithToast)
                             ShowAlert(errorMessage, "Oops!");
                        else if (failWithToast)
                             ShowAlert(errorMessage);
                        Debug.WriteLine(errorMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                ShowAlert(ex.Message, "Oops!");
                if (setLoading)
                    await HideLoading();
                Debug.WriteLine(ex);
                Console.WriteLine(ex);
            }
            return result;
        }

        private void Initialize()
        {
            if (IsInitialized)
                return;

            IsInitialized = true;
        }
        public virtual async Task OnPageAppearing()
        {
           
        }
        public virtual async Task OnPageDisappearing()
        {
            
        }
        public virtual Task InitializeAsync(object navigationData)
        {
            return Task.FromResult(false);
        }
        public async Task ShowLoading(string loadingMessage = "")
        {
            if (string.IsNullOrEmpty(loadingMessage))
                loadingMessage = AppResources.GetInTouchBtnTxt;
            loadingDialog = await MaterialDialog.Instance.LoadingDialogAsync(message: loadingMessage);
        }
        public async Task HideLoading()
        {
            await loadingDialog.DismissAsync();
        }
        public async Task ShowAlert(string message, string title = "", string acknowledgeText = "")
        {
            if (string.IsNullOrEmpty(acknowledgeText))
                acknowledgeText = "Ok";
            await MaterialDialog.Instance.AlertAsync(message: message, title: title, acknowledgementText: acknowledgeText, configuration: alertDialogConfiguration);
        }
        public void ShowFlyout()
        {
            Shell.Current.FlyoutIsPresented = true;
        }
        public void HideFlyout()
        {
            Shell.Current.FlyoutIsPresented = false;
        }

        public async Task<bool?> ShowConfirmAlert(string message,string title = "", string confirm = "", string dismitive = "")
        {
            bool? result = false;
            result = await MaterialDialog.Instance.ConfirmAsync(message: message, title: title, confirmingText: confirm, dismissiveText: dismitive, configuration: alertDialogConfiguration);
            return result;
        }

        //protected bool CheckConnection(bool AlertIfNot = false)
        //{
        //    if (ConnectivityService.IsConnected())
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        if (AlertIfNot)
        //            ThreadingHelpers.InvokeOnMainThread(() => { UserDialogs.Instance.Alert("No Internet Connection", "Offline!"); });
        //        return false;
        //    }
        //}
    }
}
