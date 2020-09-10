using SportDirect.Helpers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SportDirect.Areas.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingPage : ContentPage
    {
        public SettingPage()
        {
            InitializeComponent();
            BindingContext = App.Locator.SettingPage;
            SwitchIsToggled.IsToggled = Settings.IsDarkMode;
            OrderNotiOnOffSwitchIsToggled.IsToggled = Settings.OrderNotiOnOffIsToggled;
            OffersNotiOnOffSwitchIsToggled.IsToggled = Settings.OffersNotiOnOffIsToggled;

             NotificationOnOff.Text = Settings.notificationOnOff;
             OrderNotiOnOff.Text = Settings.orderNotiOnOff;
             OffersNotiOnOff.Text = Settings.offersNotiOnOff;
        }

        private void SwitchIsToggled_Toggled(object sender, ToggledEventArgs e)
        {
            var getVal = sender as Switch;
            if (getVal.IsToggled)
            {
                Settings.IsDarkMode = true;
                Settings.notificationOnOff= "On";
                NotificationOnOff.Text = "On";
            }
            else
            {
                Settings.IsDarkMode = false;
                Settings.notificationOnOff = "Off";
                NotificationOnOff.Text = "Off";
            }
        }

        private void OrderNotiOnOffSwitchIsToggled_Toggled(object sender, ToggledEventArgs e)
        {
            var getVal = sender as Switch;
            if (getVal.IsToggled)
            {
                Settings.OrderNotiOnOffIsToggled = true;
                Settings.orderNotiOnOff = "On";
                OrderNotiOnOff.Text = "On";
            }
            else
            {
                Settings.OrderNotiOnOffIsToggled = false;
                Settings.orderNotiOnOff = "Off";
                OrderNotiOnOff.Text = "Off";
            }
        }

        private void OffersNotiOnOffSwitchIsToggled_Toggled(object sender, ToggledEventArgs e)
        {
            var getVal = sender as Switch;
            if (getVal.IsToggled)
            {
                Settings.OffersNotiOnOffIsToggled = true;
                Settings.offersNotiOnOff = "On";
                OffersNotiOnOff.Text = "On";
            }
            else
            {
                Settings.OffersNotiOnOffIsToggled = false;
                Settings.offersNotiOnOff = "Off";
                OffersNotiOnOff.Text = "Off";
            }
        }
        //protected override void OnAppearing()
        // {
        //     SwitchIsToggled.IsToggled = Settings.IsDarkMode;
        //     base.OnAppearing();
        // }
        // private void SwitchDarkModeToggled(object sender, ToggledEventArgs e)
        // {
        //     var getVal = sender as Switch;
        //     if (getVal.IsToggled)
        //     {
        //         Settings.IsDarkMode = true;
        //         App.Current.Resources["CommonPageBackgroundColor"] = Color.FromHex("#202125");
        //         App.Current.Resources["OurClientPageBackgroundColor"] = Color.FromHex("#202125");                
        //         App.Current.Resources["PrimaryColor"] = Color.White;
        //         App.Current.Resources["Primary2Color"] = Color.White;
        //         App.Current.Resources["Primary3Color"] = Color.White;
        //         App.Current.Resources["RedColor"] = Color.FromHex("#FE0006");
        //         App.Current.Resources["Btn1BgColor"] = Color.Transparent;
        //         App.Current.Resources["Btn1TextColor"] = Color.White;
        //         App.Current.Resources["Btn2BgColor"] = Color.FromHex("#9E1E4C");
        //         App.Current.Resources["Btn2TextColor"] = Color.White;
        //         App.Current.Resources["FrameBgColor"] = Color.FromHex("#999999");
        //         App.Current.Resources["FrameBorderColor"] = Color.FromHex("#707070");
        //         App.Current.Resources["FrameBg1Color"] = Color.FromHex("#999999");
        //         App.Current.Resources["FrameBorder1Color"] = Color.FromHex("#707070");
        //         App.Current.Resources["FrameBg2Color"] = Color.FromHex("#999999");
        //         App.Current.Resources["FrameBorder2Color"] = Color.FromHex("#707070");
        //         App.Current.Resources["BoxViewBgColor"] = Color.WhiteSmoke;
        //         App.Current.Resources["PancakeBgColor"] = Color.FromHex("#999999");
        //         App.Current.Resources["PancakeBorderColor"] = Color.FromHex("#707070");
        //         App.Current.Resources["PancakeBg1Color"] = Color.FromHex("#999999");
        //         App.Current.Resources["PancakeBorder1Color"] = Color.FromHex("#707070");
        //         App.Current.Resources["ShellBgColor"] = Color.White;
        //         App.Current.Resources["ShellTabBarBgColor"] = Color.Gray;
        //         App.Current.Resources["ShallTabBarTitleColor"] = Color.White;
        //         App.Current.Resources["ShellTabBarUnselectedColor"] = Color.Black;
        //         App.Current.Resources["ShellForegroundColor"] = Color.White;
        //         App.Current.Resources["ShellTitleColor"] = Color.White;
        //     }
        //     else
        //     {
        //         Settings.IsDarkMode = false;
        //         App.Current.Resources["CommonPageBackgroundColor"] = Color.White;
        //         App.Current.Resources["OurClientPageBackgroundColor"] = Color.FromHex("#CED6E0");
        //         App.Current.Resources["PrimaryColor"] = Color.White;
        //         App.Current.Resources["Primary2Color"] = Color.Black;
        //         App.Current.Resources["Primary3Color"] = Color.Gray;
        //         App.Current.Resources["RedColor"] = Color.FromHex("#FE0006");
        //         App.Current.Resources["Btn1BgColor"] = Color.Transparent;
        //         App.Current.Resources["Btn1TextColor"] = Color.Red;
        //         App.Current.Resources["Btn2BgColor"] = Color.FromHex("#9E1E4C");
        //         App.Current.Resources["Btn2TextColor"] = Color.White;
        //         App.Current.Resources["FrameBgColor"] = Color.White;
        //         App.Current.Resources["FrameBorderColor"] = Color.WhiteSmoke;
        //         App.Current.Resources["FrameBg1Color"] = Color.FromHex("#F5F6FA");
        //         App.Current.Resources["FrameBorder1Color"] = Color.WhiteSmoke;
        //         App.Current.Resources["FrameBg2Color"] = Color.FromHex("#CCD6E0");
        //         App.Current.Resources["FrameBorder2Color"] = Color.WhiteSmoke;
        //         App.Current.Resources["BoxViewBgColor"] = Color.WhiteSmoke;
        //         App.Current.Resources["PancakeBgColor"] = Color.White;
        //         App.Current.Resources["PancakeBorderColor"] = Color.WhiteSmoke;
        //         App.Current.Resources["PancakeBg1Color"] = Color.FromHex("#F8D3A9");
        //         App.Current.Resources["PancakeBorder1Color"] = Color.WhiteSmoke;
        //         App.Current.Resources["ShellBgColor"] = Color.FromHex("#E67020");
        //         App.Current.Resources["ShellTabBarBgColor"] = Color.White;
        //         App.Current.Resources["ShallTabBarTitleColor"] = Color.Red;
        //         App.Current.Resources["ShellTabBarUnselectedColor"] = Color.Gray;
        //         App.Current.Resources["ShellForegroundColor"] = Color.WhiteSmoke;
        //         App.Current.Resources["ShellTitleColor"] = Color.Red;
        //     }
        // }
    }
}