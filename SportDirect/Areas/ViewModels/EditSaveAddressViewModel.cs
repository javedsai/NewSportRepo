using Acr.UserDialogs;
using SportDirect.Areas.Model;
using SportDirect.Areas.Views;
using SportDirect.Assets;
using SportDirect.Data.Models.Request;
using SportDirect.Helpers;
using SportDirect.Service.Interfaces;
using SportDirect.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SportDirect.Areas.ViewModels
{
    public class EditSaveAddressViewModel : BasePageViewModel
    {
        private ObservableCollection<EditSaveAddressModel> _editAddressList;
        public ObservableCollection<EditSaveAddressModel> EditAddressList
        {
            get { return _editAddressList; }
            set { _editAddressList = value; RaisePropertyChanged(); }
        }

        private IApiService _apiService;
        public EditSaveAddressViewModel(IApiService apiService)
        {
            _apiService = apiService;
        }
        public async void Init()
        {
            UserDialogs.Instance.ShowLoading();
            EditAddressList = await GetEditAddreesList();
            UserDialogs.Instance.HideLoading();
        }
        public ICommand AddNewCommand => new Command(async (obj) =>
        {

            await App.Current.MainPage.Navigation.PushModalAsync(new AddNewAddress());
        });
        public Command EditCommand
        {
            get
            {
                return new Command(async (obj) =>
                {
                    var obj2= obj as EditSaveAddressModel;
                    await App.Current.MainPage.Navigation.PushModalAsync(new AddNewAddress(obj2));
                });
            }
        }
        public Command RemoveCommand
        {
            get
            {
                return new Command(async (obj) =>
                {
                    try
                    {
                        UserDialogs.Instance.ShowLoading();
                        var EditAddressMdl = obj as EditSaveAddressModel;
                        EditAddressList.Remove(EditAddressMdl);
                        DeleteCusRequest deleteCusRequest = new DeleteCusRequest();
                        deleteCusRequest.customerAccessToken = Settings.Customer_Access_Token;
                        deleteCusRequest.id = EditAddressMdl.ID;
                        string query = @"mutation customerAddressDelete($id: ID!, $customerAccessToken: String!) {
                        customerAddressDelete(id: $id, customerAccessToken: $customerAccessToken) {
                            customerUserErrors {
                                code
                                field
                              message
                            }
                            deletedCustomerAddressId
                        }
                    }";
                        var res = await _apiService.DeleteAddress(query, deleteCusRequest);                 
                        if (res != null)
                        {
                            if (!string.IsNullOrEmpty(res.data.customerAddressDelete.deletedCustomerAddressId))
                            {
                                var cfg = new ToastConfig("Address Deleted successfully")
                                {
                                    BackgroundColor = Color.Green
                                };
                                UserDialogs.Instance.Toast(cfg);
                                App.Locator.EditSaveAddress.Init();
                                UserDialogs.Instance.HideLoading();
                            }
                            else if (res.data.customerAddressDelete.customerUserErrors.Count > 0)
                            {
                                UserDialogs.Instance.HideLoading();
                                string cs = Convert.ToString(res.data.customerAddressDelete.customerUserErrors[0].message);
                                UserDialogs.Instance.HideLoading();
                                UserDialogs.Instance.Alert(cs);
                             
                            }
                            else
                            {
                                UserDialogs.Instance.HideLoading();
                                UserDialogs.Instance.Alert("There are some problem");
                            }

                        }
                        else
                        {
                            UserDialogs.Instance.HideLoading();
                            UserDialogs.Instance.Alert("Server not connected");
                        }
                    }
                    catch (Exception ex)
                    {
                        UserDialogs.Instance.HideLoading();
                        UserDialogs.Instance.Alert(ex.Message.ToString());
                    }
                });
            }
        }
        public ICommand DoneCommand => new Command(async (obj) =>
        {
            await App.Current.MainPage.Navigation.PopModalAsync();
        });

        public async Task<ObservableCollection<EditSaveAddressModel>> GetEditAddreesList()
        {
            ObservableCollection<EditSaveAddressModel> obj_new = new ObservableCollection<EditSaveAddressModel>();
            List<Customer_Add> obj_listAddress = new List<Customer_Add>();
            string accestoken = Convert.ToString(Settings.Customer_Access_Token);
            char quote = '"';
            string modifiedString = quote + accestoken + quote;
            string query = "{ customer(customerAccessToken:" + modifiedString + "){ id addresses(first: 20){ edges{  node{id firstName lastName address1 address2 city company province country zip phone } } } } }";
            //  UserDialogs.Instance.ShowLoading();
            var res = await _apiService.GetCustomer(query);
            //  UserDialogs.Instance.HideLoading();
            if (res != null)
            {
                obj_listAddress = await App.Database.GetNoteAsync();
                foreach (var item in res.data.customer.addresses.edges)
                {
                    obj_new.Add(new EditSaveAddressModel()
                    {
                        Title = item.node.firstName + " " + item.node.lastName + " " + item.node.address1 + " " + item.node.address2,
                        ID = item.node.id,
                        firstName = item.node.firstName,
                        lastName = item.node.lastName,
                        address1 = item.node.address1,
                        address2 = item.node.address2,
                        city = item.node.city,
                        company = item.node.company,
                        country = item.node.country,
                        zip = item.node.zip,
                        province=item.node.province,
                        phone=item.node.phone
                    });
                }
            }
            else
            {
                obj_new.Clear();
            }

            //obj_listAddress = await App.Database.GetNoteAsync();
            //foreach (var item in obj_listAddress)
            //{
            //    obj_new.Add(new EditSaveAddressModel()
            //    {
            //        Title = item.address1 + " " + item.address2
            //    });

            //}

            return obj_new;

            //return new ObservableCollection<EditSaveAddressModel>()
            //{
            //   new EditSaveAddressModel{ Title="2226 Deer Ridge Drive Netwark1,NJ 07102"},
            //   new EditSaveAddressModel{ Title="2226 Deer Ridge Drive Netwark2,NJ 07102"},
            //   new EditSaveAddressModel{ Title="2226 Deer Ridge Drive Netwark3,NJ 07102"},
            //   new EditSaveAddressModel{ Title="2226 Deer Ridge Drive Netwark4,NJ 07102"},
            //   new EditSaveAddressModel{ Title="2226 Deer Ridge Drive Netwark5,NJ 07102"},
            //   new EditSaveAddressModel{ Title="2226 Deer Ridge Drive Netwark6,NJ 07102"},
            //   new EditSaveAddressModel{ Title="2226 Deer Ridge Drive Netwark7,NJ 07102"},
            //   new EditSaveAddressModel{ Title="2226 Deer Ridge Drive Netwark8,NJ 07102"},
            //   new EditSaveAddressModel{ Title="2226 Deer Ridge Drive Netwark9,NJ 07102"},
            //   new EditSaveAddressModel{ Title="2226 Deer Ridge Drive Netwark10,NJ 07102"}
            //};
        }
    }
}