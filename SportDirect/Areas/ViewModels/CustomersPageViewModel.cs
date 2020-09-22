using SportDirect.Areas.Model;
using SportDirect.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using SportDirect.Service.Interfaces;
using System.Threading.Tasks;
using SportDirect.Data.Models.Common;
using Acr.UserDialogs;
using SportDirect.Areas.Views;

namespace SportDirect.Areas.ViewModels
{
   public class CustomersPageViewModel :BasePageViewModel
    {
        private IApiService _apiService;
        private ObservableCollection<CategoryCommonModel> _customerList;
        public ObservableCollection<CategoryCommonModel> CustomerList
        {
            get { return _customerList; }
            set { _customerList = value; RaisePropertyChanged(); }
        }

        public ICommand CustomersListCommand => new Command(async (obj) =>
        {
            var categoryData = obj as CategoryCommonModel;
            UserDialogs.Instance.ShowLoading();
            await App.Locator.FeaturedProductPage.InitilizeData(categoryData.handle);
            await App.Current.MainPage.Navigation.PushModalAsync(new FeaturedProductPage(false));
            UserDialogs.Instance.HideLoading();
        });
        public CustomersPageViewModel(IApiService apiService)
        {
            _apiService = apiService;
        }
        public async Task InitilizeData(ObservableCollection<CategoryCommonModel> request)
        {
            CustomerList = request;
        }
    }
}