using System;
using SportDirect.Areas.Authentication.ViewModels;
using SportDirect.Areas.PopUp;
using SportDirect.Areas.ViewModels;
using SportDirect.Areas.Views.MasterDetailsPage.ViewModels;
using SportDirect.Bootstrap;

namespace SportDirect.ViewModels
{
    public class ViewModelLocator
    {
        public readonly IoCConfig _iocConfig;
        internal void RegisterViewModels()
        {
            _iocConfig.RegisterServices();
            _iocConfig.RegisterViewModel<MainPageViewModel>();
            _iocConfig.RegisterViewModel<AppShellPageViewModel>();    
            _iocConfig.RegisterViewModel<CheckInternetPageViewModel>();
            _iocConfig.RegisterViewModel<MainMenuViewModel>();
            _iocConfig.RegisterViewModel<HomeViewModel>(); 
            _iocConfig.RegisterViewModel<LanguagePageViewModel>();
            _iocConfig.RegisterViewModel<SignupPageViewModel>();
            _iocConfig.RegisterViewModel<LoginPageViewModel>();
            _iocConfig.RegisterViewModel<RegisterPageViewModel>();
            _iocConfig.RegisterViewModel<SaveAddressPageViewModel>();
            _iocConfig.RegisterViewModel<SettingPageViewModel>(); 
            _iocConfig.RegisterViewModel<AddNewAddressViewModel>();
            _iocConfig.RegisterViewModel<EditSaveAddressViewModel>();
            _iocConfig.RegisterViewModel<CustomersPageViewModel>();
            _iocConfig.RegisterViewModel<ProductsPageViewModel>();
            _iocConfig.RegisterViewModel<SportPageViewModel>();
            _iocConfig.RegisterViewModel<OffersPageViewModel>();
            _iocConfig.RegisterViewModel<NewsDetailsPageViewModel>();
            _iocConfig.RegisterViewModel<BlogsPageViewModel>();
            _iocConfig.RegisterViewModel<BlogsDetailsPageViewModel>();
            _iocConfig.RegisterViewModel<MyOrderPageViewModel>();
            _iocConfig.RegisterViewModel<MyOrderDetailsPageViewModel>();
            _iocConfig.RegisterViewModel<ProfilePageViewModel>();
            _iocConfig.RegisterViewModel<MyReviewsPageViewModel>();
            _iocConfig.RegisterViewModel<EditMyReviewsPageViewModel>();
            _iocConfig.RegisterViewModel<AccountSettinPageViewModel>();
            _iocConfig.RegisterViewModel<CartPageViewModel>();
            _iocConfig.RegisterViewModel<CartPageViewModel>();
            _iocConfig.RegisterViewModel<EditCartPageViewModel>();
            _iocConfig.RegisterViewModel<PaymentPageViewModel>();
            _iocConfig.RegisterViewModel<SuccessPopupViewModel>();
            _iocConfig.RegisterViewModel<ProductViewPageViewModel>();
            _iocConfig.RegisterViewModel<FilterPageViewModel>();
            _iocConfig.RegisterViewModel<ProductDetailsPageViewModel>();
            _iocConfig.RegisterViewModel<MainMenuMasterViewModel>();
            _iocConfig.RegisterViewModel<PromotionPageViewModel>();
            _iocConfig.RegisterViewModel<BookInstallationViewModel>();
            _iocConfig.RegisterViewModel<WarningAdviceViewModel>();
            _iocConfig.RegisterViewModel<AboutUsPageViewModel>();
            _iocConfig.RegisterViewModel<TermsPageViewModel>();
            _iocConfig.RegisterViewModel<OurPolicyViewModel>();
            _iocConfig.RegisterViewModel<MyFavoritesViewModel>();
            _iocConfig.RegisterViewModel<ContactusViewModel>();
            _iocConfig.RegisterViewModel<PrivacySecurityViewModel>();
            _iocConfig.RegisterViewModel<ReferAFriendViewModel>();
            _iocConfig.RegisterViewModel<FAQsPageViewModel>();
            _iocConfig.RegisterViewModel<BusinessLocationViewModel>();
            _iocConfig.RegisterViewModel<GetQuotePageViewModel>();
            _iocConfig.RegisterViewModel<GetQuoteDetailsPageViewModel>();
            _iocConfig.RegisterViewModel<OrderTrackingViewModel>();
            _iocConfig.RegisterViewModel<LiveCustomerServiceViewModel>();
            _iocConfig.RegisterViewModel<ComplexPageViewModel>();
            _iocConfig.RegisterViewModel<FeaturedProductPageViewModel>();
            _iocConfig.RegisterViewModel<NotificationPageViewModel>();
            _iocConfig.RegisterViewModel<SortPageViewModel>();
            _iocConfig.RegisterViewModel<ForgetPasswordPageViewModel>();

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Yukon.Application.ViewModels.ViewModelLocator"/> class.
        /// </summary>
        /// <param name="iocConfig">The native IoC config implementation.</param>
        public ViewModelLocator(IoCConfig iocConfig)
        {
            _iocConfig = iocConfig;
        }
        public MainPageViewModel MainPage => GetViewModel<MainPageViewModel>();
        public AppShellPageViewModel AppShellPage => GetViewModel<AppShellPageViewModel>();        
        public CheckInternetPageViewModel CheckInternetPage => GetViewModel<CheckInternetPageViewModel>();
        public MainMenuViewModel MainMenu => GetViewModel<MainMenuViewModel>();
        public HomeViewModel Home => GetViewModel<HomeViewModel>();          
        public LanguagePageViewModel LanguagePage => GetViewModel<LanguagePageViewModel>();
        public SignupPageViewModel SignupPage => GetViewModel<SignupPageViewModel>();
        public LoginPageViewModel LoginPage => GetViewModel<LoginPageViewModel>();
        public RegisterPageViewModel RegisterPage => GetViewModel<RegisterPageViewModel>();
        public SaveAddressPageViewModel SaveAddressPage => GetViewModel<SaveAddressPageViewModel>();
        public SettingPageViewModel SettingPage => GetViewModel<SettingPageViewModel>();
         public AddNewAddressViewModel AddNewAddress => GetViewModel<AddNewAddressViewModel>();
        public EditSaveAddressViewModel EditSaveAddress => GetViewModel<EditSaveAddressViewModel>();
        public CustomersPageViewModel CustomersPage => GetViewModel<CustomersPageViewModel>();
        public ProductsPageViewModel ProductsPage => GetViewModel<ProductsPageViewModel>();
        public SportPageViewModel SportPage => GetViewModel<SportPageViewModel>();
        public OffersPageViewModel OffersPage => GetViewModel<OffersPageViewModel>();
        public NewsDetailsPageViewModel NewsDetailsPage => GetViewModel<NewsDetailsPageViewModel>();
        public BlogsPageViewModel BlogsPage => GetViewModel<BlogsPageViewModel>();
        public BlogsDetailsPageViewModel BlogsDetailsPage => GetViewModel<BlogsDetailsPageViewModel>();
        public MyOrderPageViewModel MyOrderPage => GetViewModel<MyOrderPageViewModel>();
        public MyOrderDetailsPageViewModel MyOrderDetailsPage => GetViewModel<MyOrderDetailsPageViewModel>();
        public ProfilePageViewModel ProfilePage => GetViewModel<ProfilePageViewModel>();
        public MyReviewsPageViewModel MyReviewsPage => GetViewModel<MyReviewsPageViewModel>();
        public EditMyReviewsPageViewModel EditMyReviewsPage => GetViewModel<EditMyReviewsPageViewModel>();
        public AccountSettinPageViewModel AccountSettinPage => GetViewModel<AccountSettinPageViewModel>();
        public CartPageViewModel CartPage => GetViewModel<CartPageViewModel>();
        public EditCartPageViewModel EditCartPage => GetViewModel<EditCartPageViewModel>();
        public PaymentPageViewModel PaymentPage => GetViewModel<PaymentPageViewModel>();
        public SuccessPopupViewModel SuccessPopup => GetViewModel<SuccessPopupViewModel>();
        public ProductViewPageViewModel ProductViewPage => GetViewModel<ProductViewPageViewModel>();
        public FilterPageViewModel FilterPage => GetViewModel<FilterPageViewModel>();
        public ProductDetailsPageViewModel ProductDetailsPage => GetViewModel<ProductDetailsPageViewModel>();
        public MainMenuMasterViewModel MainMenuMaster => GetViewModel<MainMenuMasterViewModel>();
        public PromotionPageViewModel PromotionPage => GetViewModel<PromotionPageViewModel>();
        public BookInstallationViewModel BookInstallation => GetViewModel<BookInstallationViewModel>();
        public WarningAdviceViewModel WarningAdvice => GetViewModel<WarningAdviceViewModel>();
        public AboutUsPageViewModel AboutUsPage => GetViewModel<AboutUsPageViewModel>();
        public TermsPageViewModel TermsPage => GetViewModel<TermsPageViewModel>();
        public OurPolicyViewModel OurPolicy => GetViewModel<OurPolicyViewModel>();
        public MyFavoritesViewModel MyFavorites => GetViewModel<MyFavoritesViewModel>();
        public ContactusViewModel Contactus => GetViewModel<ContactusViewModel>();
        public PrivacySecurityViewModel PrivacySecurity => GetViewModel<PrivacySecurityViewModel>();
        public ReferAFriendViewModel ReferAFriend => GetViewModel<ReferAFriendViewModel>();
        public FAQsPageViewModel FAQsPage => GetViewModel<FAQsPageViewModel>();
        public BusinessLocationViewModel BusinessLocation => GetViewModel<BusinessLocationViewModel>();
        public GetQuotePageViewModel GetQuotePage => GetViewModel<GetQuotePageViewModel>();
        public GetQuoteDetailsPageViewModel GetQuoteDetailsPage => GetViewModel<GetQuoteDetailsPageViewModel>();
        public OrderTrackingViewModel OrderTracking => GetViewModel<OrderTrackingViewModel>();
        public LiveCustomerServiceViewModel LiveCustomerService => GetViewModel<LiveCustomerServiceViewModel>();
        public ComplexPageViewModel ComplexPage => GetViewModel<ComplexPageViewModel>();
        public FeaturedProductPageViewModel FeaturedProductPage => GetViewModel<FeaturedProductPageViewModel>();
        public NotificationPageViewModel NotificationPage => GetViewModel<NotificationPageViewModel>();
        public SortPageViewModel SortPage => GetViewModel<SortPageViewModel>();
        public ForgetPasswordPageViewModel ForgetPasswordPage => GetViewModel<ForgetPasswordPageViewModel>();

        // TODO: create properties for each newly created view model
        public TViewModel GetViewModel<TViewModel>() where TViewModel : BasePageViewModel
        {
            return _iocConfig.FindViewModel<TViewModel>();
        }
    }
}