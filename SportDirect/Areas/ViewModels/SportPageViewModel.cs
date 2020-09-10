using SportDirect.Areas.Model;
using SportDirect.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace SportDirect.Areas.ViewModels
{
   public class SportPageViewModel : BasePageViewModel
    {
        private ObservableCollection<SportModel> _sportList;
        public ObservableCollection<SportModel> SportList
        {
            get { return _sportList; }
            set { _sportList = value; RaisePropertyChanged(); }
        }

        public ICommand SportListCommand => new Command(async (obj) =>
        {
            //Acr.UserDialogs.UserDialogs.Instance.Alert("In progress");
        });
        public SportPageViewModel()
        {
            SportList = GetSportList();
        }
        public ObservableCollection<SportModel> GetSportList()
        {
            return new ObservableCollection<SportModel>
            {
              new SportModel{ Title="MARTIAL ARTS", Image="MartialArts"},
              new SportModel{ Title="BASKETBALL", Image="Basketball"},
              new SportModel{ Title="BOXE", Image="Boxe"},
              new SportModel{ Title="FITNESS", Image="Fitness"},
              new SportModel{ Title="GYMNASTIC", Image="Gymnasiummats"} 
            };
        }
    }
}