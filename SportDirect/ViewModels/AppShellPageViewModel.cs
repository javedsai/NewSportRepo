using System;
using System.Threading.Tasks;
using SportDirect.Core.Models.User;
using GalaSoft.MvvmLight.Command;
using Xamarin.Forms;

namespace SportDirect.ViewModels
{
    public class AppShellPageViewModel : BasePageViewModel
    {
        public RelayCommand LogoutCommand { get; set; }

        public UserBasicInfo StudentBasicInfo {get;set;}


        public AppShellPageViewModel()
        {
            LogoutCommand = new RelayCommand(async () => await LogoutUser());
        }
        public async Task LogoutUser()
        {
            bool? result = await ShowConfirmAlert("Are you sure you want to logout from the ClassBuzz", "Logout!", "Yes", "No");
            if(result.Value)
            {
                Application.Current.Properties["LoggedUser"] = null;
                //await NavigationService.NavigateToAsync<LoginPageViewModel>();
            }    
        }
    }
}
