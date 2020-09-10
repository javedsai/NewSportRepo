using Acr.UserDialogs;
using SportDirect.Areas.Model;
using SportDirect.Areas.Views.MasterDetailsPage;
using SportDirect.Helpers;
using SportDirect.Service.Interfaces;
using SportDirect.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace SportDirect.Areas.ViewModels
{
    public class SignupPageViewModel : BasePageViewModel
    {
        private string _checkImage = "CheckRed";
        public string CheckImage
        {
            get => _checkImage;
            set { _checkImage = value; RaisePropertyChanged(); }
        }
        private string _unCheckImage = "Uncheck";
        public string UnCheckImage
        {
            get=> _unCheckImage; 
            set { _unCheckImage = value; RaisePropertyChanged(); }
        }        
       
        private SignupModel _selectAcademy;
        public SignupModel SelectAcademy
        {
            get { return _selectAcademy; }
            set { _selectAcademy = value;RaisePropertyChanged(); }
        }
           
        private ObservableCollection<SignupModel> _academyName;
        public ObservableCollection<SignupModel> AcademyName
        {
            get { return _academyName; }
            set { _academyName = value; RaisePropertyChanged(); }
        }
         
        private IApiService _apiService;
        public SignupPageViewModel(IApiService apiService)
        {
            _apiService = apiService;
            AcademyName = GetAcademyNameList();
            SelectAcademy = null;
        }

        public ObservableCollection<SignupModel> GetAcademyNameList()
        {
            return new ObservableCollection<SignupModel>()
            {
                new SignupModel{ Name="Tennis Academy" },
                new SignupModel{ Name="Basketball Academy" }
            };
        }
        int Data=2;
        public ICommand IndividualCommand => new Command(async (obj) =>
        {
            UnCheckImage = "CheckRed";
            CheckImage = "Uncheck";
            Data = 1;
        });
        public ICommand DropdownDataCommand => new Command(async (obj) =>
        {
            CheckImage = "CheckRed";
            UnCheckImage = "Uncheck";
            Data = 2;
        });
       
        public ICommand SubmitCommand => new Command(async (obj) =>
        {
           if(Data ==1)
            {
                UserDialogs.Instance.ShowLoading();
                await App.Current.MainPage.Navigation.PushAsync(new MainMenu());
                Settings.IsWalkthroughCompleted = true;
                UserDialogs.Instance.HideLoading();
            } 
           else
            {
                if (SelectAcademy == null)
                {
                    UserDialogs.Instance.Alert("Select the academy");
                }
                else
                {
                    UserDialogs.Instance.ShowLoading();
                    await App.Current.MainPage.Navigation.PushAsync(new MainMenu());
                    Settings.IsWalkthroughCompleted = true;                    
                    UserDialogs.Instance.HideLoading();
                }
            } 
        });
    }
}
