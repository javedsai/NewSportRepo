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
   public class ProductsPageViewModel : BasePageViewModel
    {
        private ObservableCollection<ProductsModel> _productsList;
        public ObservableCollection<ProductsModel> ProductsList
        {
            get { return _productsList; }
            set { _productsList = value; RaisePropertyChanged(); }
        }
       
        public ICommand ProductsListCommand => new Command(async (obj) =>
        {
           // Acr.UserDialogs.UserDialogs.Instance.Alert("In progress");
        });
        public ProductsPageViewModel()
        {
            ProductsList = GetProductsList();
        }
        public ObservableCollection<ProductsModel> GetProductsList()
        {
            return new ObservableCollection<ProductsModel>
            {
              new ProductsModel{ Title="PROTECTIVE PADDING", Image="ProtectivePadding"},
              new ProductsModel{ Title="PROTECTIVE NETTING", Image="ProtectiveNetting"},
              new ProductsModel{ Title="FOAM SHAPES", Image="Foamshapes"},
              new ProductsModel{ Title="GYMNASIUM MATS", Image="Storage"},
              new ProductsModel{ Title="STORAGE", Image="SportsBags"},
            };
        }
    }
}