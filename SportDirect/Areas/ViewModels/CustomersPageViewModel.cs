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
   public class CustomersPageViewModel :BasePageViewModel
    {
        private ObservableCollection<CustomerModel> _customerList;
        public ObservableCollection<CustomerModel> CustomerList
        {
            get { return _customerList; }
            set { _customerList = value; RaisePropertyChanged(); }
        }

        public ICommand CustomersListCommand => new Command(async (obj) =>
        {
           //Acr.UserDialogs.UserDialogs.Instance.Alert("In progress");
        });
        public CustomersPageViewModel()
        {
            CustomerList = GetCustmerList();
        }
        public ObservableCollection<CustomerModel> GetCustmerList()
        {
            return new ObservableCollection<CustomerModel>
            {
              new CustomerModel{ Title="ARENAS & ICE RINKS" , Image="ArenasIcerinks"},
              new CustomerModel{ Title="CAMPING & ACCOMODATION" , Image="camping"},
              new CustomerModel{ Title="OUTDOOR CENTER" , Image="Outdoorcenter"},
              new CustomerModel{ Title="GOLF COURSE & DRIVING RANGE" , Image="golfcourse"},
              new CustomerModel{ Title="TESNIS CENTER" , Image="Tennis"},
              new CustomerModel{ Title="KINDER GARDENDER" , Image="kinder"},
              new CustomerModel{ Title="SCHOOL $ BOARDS" , Image="schoolboard"},
              new CustomerModel{ Title="CITIES & MUNICIPARTIES" , Image="cities"},
            };
        }
    }
}