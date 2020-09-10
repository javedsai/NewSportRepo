using Acr.UserDialogs;
using SportDirect.Areas.Model;
using SportDirect.Areas.Views;
using SportDirect.Assets;
using SportDirect.Core.Models.Authentication.Response;
using SportDirect.Data.Models.Request;
using SportDirect.Helpers;
using SportDirect.Service.Interfaces;
using SportDirect.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SportDirect.Areas.ViewModels
{
    public class AddNewAddressViewModel : BasePageViewModel
    {

        private bool IsEditWay { get; set; }

        public string _fname;
        public string FName
        {
            get { return _fname; }
            set
            {
                _fname = value;
                if (string.IsNullOrEmpty(_fname))
                    IsFirstNameErrorVisible = true;
                else
                    IsFirstNameErrorVisible = false;
                CheckValidation();
                RaisePropertyChanged(nameof(FName));
            }
        }
        public bool _isFirstNameErrorVisible;
        public bool IsFirstNameErrorVisible
        {
            get { return _isFirstNameErrorVisible; }
            set { _isFirstNameErrorVisible = value; RaisePropertyChanged(nameof(IsFirstNameErrorVisible)); }
        }

        public string _lname;
        public string LName
        {
            get { return _lname; }
            set
            {
                _lname = value;
                if (string.IsNullOrEmpty(_lname))
                    IsLastNameErrorVisible = true;
                else
                    IsLastNameErrorVisible = false;
                CheckValidation();
                RaisePropertyChanged(nameof(LName));
            }
        }
        public bool _isLastNameErrorVisible;
        public bool IsLastNameErrorVisible
        {
            get { return _isLastNameErrorVisible; }
            set { _isLastNameErrorVisible = value; RaisePropertyChanged(nameof(IsLastNameErrorVisible)); }
        }

        public string _mobileNumber;
        public string MobileNumber
        {
            get { return _mobileNumber; }
            set
            {
                _mobileNumber = value;
                if (string.IsNullOrEmpty(_mobileNumber))
                    IsMobileNameErrorVisible = true;
                else
                    IsMobileNameErrorVisible = false;
                CheckValidation();
                RaisePropertyChanged(nameof(MobileNumber));
            }
        }
        public bool _isMobileNameErrorVisible;
        public bool IsMobileNameErrorVisible
        {
            get { return _isMobileNameErrorVisible; }
            set { _isMobileNameErrorVisible = value; RaisePropertyChanged(nameof(IsMobileNameErrorVisible)); }
        }


        public string _address1;
        public string Address1
        {
            get { return _address1; }
            set
            {
                _address1 = value;
                if (string.IsNullOrEmpty(_address1))
                    IsMobileNameErrorVisible = true;
                else
                    IsMobileNameErrorVisible = false;
                CheckValidation();
                RaisePropertyChanged(nameof(Address1));
            }
        }
        public bool _isAddress1ErrorVisible;
        public bool IsAddress1ErrorVisible
        {
            get { return _isAddress1ErrorVisible; }
            set { _isAddress1ErrorVisible = value; RaisePropertyChanged(nameof(IsAddress1ErrorVisible)); }
        }

        public string _address2;
        public string Address2
        {
            get { return _address2; }
            set
            {
                _address2 = value;
                if (string.IsNullOrEmpty(_address2))
                    IsAddress2ErrorVisible = true;
                else
                    IsAddress2ErrorVisible = false;
                CheckValidation();
                RaisePropertyChanged(nameof(Address2));
            }
        }
        public bool _isAddress2ErrorVisible;
        public bool IsAddress2ErrorVisible
        {
            get { return _isAddress2ErrorVisible; }
            set { _isAddress2ErrorVisible = value; RaisePropertyChanged(nameof(IsAddress2ErrorVisible)); }
        }


        public string _organization;
        public string Organization
        {
            get { return _organization; }
            set
            {
                _organization = value;
                if (string.IsNullOrEmpty(_organization))
                    IsOrganizationErrorVisible = true;
                else
                    IsOrganizationErrorVisible = false;
                CheckValidation();
                RaisePropertyChanged(nameof(Organization));
            }
        }
        public bool _isOrganizationErrorVisible;
        public bool IsOrganizationErrorVisible
        {
            get { return _isOrganizationErrorVisible; }
            set { _isOrganizationErrorVisible = value; RaisePropertyChanged(nameof(IsOrganizationErrorVisible)); }
        }

        public string _city;
        public string City
        {
            get { return _city; }
            set
            {
                _city = value;
                if (string.IsNullOrEmpty(_city))
                    IsCityErrorVisible = true;
                else
                    IsCityErrorVisible = false;
                CheckValidation();
                RaisePropertyChanged(nameof(City));
            }
        }
        public bool _isCityErrorVisible;
        public bool IsCityErrorVisible
        {
            get { return _isCityErrorVisible; }
            set { _isCityErrorVisible = value; RaisePropertyChanged(nameof(IsCityErrorVisible)); }
        }


        public string _country;
        public string Country
        {
            get { return _country; }
            set
            {
                _country = value;
                if (string.IsNullOrEmpty(_country))
                    IsCityErrorVisible = true;
                else
                    IsCityErrorVisible = false;
                CheckValidation();
                RaisePropertyChanged(nameof(Country));
            }
        }
        public bool _isCountryErrorVisible;
        public bool IsCountryErrorVisible
        {
            get { return _isCountryErrorVisible; }
            set { _isCountryErrorVisible = value; RaisePropertyChanged(nameof(IsCountryErrorVisible)); }
        }

        public string _pincode;
        public string Pincode
        {
            get { return _pincode; }
            set
            {
                _pincode = value;
                if (string.IsNullOrEmpty(_pincode))
                    IsCityErrorVisible = true;
                else
                    IsCityErrorVisible = false;
                CheckValidation();
                RaisePropertyChanged(nameof(Pincode));
            }
        }
        public bool _isPincodeErrorVisible;
        public bool IsPincodeErrorVisible
        {
            get { return _isPincodeErrorVisible; }
            set { _isPincodeErrorVisible = value; RaisePropertyChanged(nameof(IsPincodeErrorVisible)); }
        }

        public string _province;
        public string Province
        {
            get { return _province; }
            set
            {
                _province = value;
                if (string.IsNullOrEmpty(_province))
                    IsProvinceErrorVisible = true;
                else
                    IsProvinceErrorVisible = false;
                CheckValidation();
                RaisePropertyChanged(nameof(Province));
            }
        }
        public bool _isProvinceErrorVisible;
        public bool IsProvinceErrorVisible
        {
            get { return _isProvinceErrorVisible; }
            set { _isProvinceErrorVisible = value; RaisePropertyChanged(nameof(IsProvinceErrorVisible)); }
        }
        public bool _isSavedButtonEnabled;
        public bool IsSavedButtonEnabled
        {
            get { return _isSavedButtonEnabled; }
            set { _isSavedButtonEnabled = value; RaisePropertyChanged(nameof(IsSavedButtonEnabled)); }
        }

        private IApiService _apiService;
        private string _id;
        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public bool CheckValidation()
        {
            if (IsFirstNameErrorVisible ||
                IsLastNameErrorVisible || IsAddress1ErrorVisible || IsCityErrorVisible || IsPincodeErrorVisible || IsCountryErrorVisible || IsProvinceErrorVisible || IsMobileNameErrorVisible || IsOrganizationErrorVisible)


            {
                IsSavedButtonEnabled = false;
                return false;
            }
            else if (string.IsNullOrEmpty(FName) ||
                string.IsNullOrEmpty(LName) || string.IsNullOrEmpty(Address1) || string.IsNullOrEmpty(Country) || string.IsNullOrEmpty(City) || string.IsNullOrEmpty(Pincode) || string.IsNullOrEmpty(Province) || string.IsNullOrEmpty(MobileNumber) || string.IsNullOrEmpty(Organization)
                )
            {
                IsSavedButtonEnabled = false;
                return false;
            }
            else
            {
                IsSavedButtonEnabled = true;
                return true;
            }
        }
        public async Task IntitializeErrorVisible()
        {
            IsFirstNameErrorVisible = false;
            IsLastNameErrorVisible = false;
            IsAddress1ErrorVisible = false;
            IsAddress2ErrorVisible = false;
            IsCountryErrorVisible = false;
            IsCityErrorVisible = false;
            IsPincodeErrorVisible = false;
            IsProvinceErrorVisible = false;
            IsMobileNameErrorVisible = false;
            IsOrganizationErrorVisible = false;

        }

        public AddNewAddressViewModel(IApiService apiService)
        {
            _apiService = apiService;
        }
        public ICommand SavedCommand => new Command(async (obj) =>
        {
            if(!IsEditWay)
            {
                //For Add
                try
                {
                    CreateAddressReequest createAddressReequest = new CreateAddressReequest();
                    createAddressReequest.customerAccessToken = Convert.ToString(Settings.Customer_Access_Token);
                    createAddressReequest.address = new Address();
                    createAddressReequest.address.firstName = FName;
                    createAddressReequest.address.lastName = LName;
                    createAddressReequest.address.company = Organization;
                    createAddressReequest.address.address1 = Address1;
                    createAddressReequest.address.address2 = Address2;
                    createAddressReequest.address.city = City;
                    createAddressReequest.address.country = Country;
                    createAddressReequest.address.zip = Pincode;
                    createAddressReequest.address.phone = MobileNumber;
                    createAddressReequest.address.province = Province;
                    string query = @"mutation customerAddressCreate($customerAccessToken: String!, $address: MailingAddressInput!) {
                                      customerAddressCreate(customerAccessToken: $customerAccessToken, address: $address) {
                                                        customerAddress {
                                                            id
                                                        }
                                                        customerUserErrors {
                                                            code
                                                            field
                                                          message
                                                        }
                                                    }
                                                }
                                                ";
                    UserDialogs.Instance.ShowLoading();
                    var res = await _apiService.CreateAddress(query, createAddressReequest);
                    if (res != null)
                    {
                        if (res.data.customerAddressCreate.customerAddress.id != null)
                        {
                            Settings.AddressId = res.data.customerAddressCreate.customerAddress.id;
                            string accestoken = Convert.ToString(Settings.Customer_Access_Token);
                            char quote = '"';
                            string modifiedString = quote + accestoken + quote;
                            string qury = "{ customer(customerAccessToken:" + modifiedString + "){ addresses(first: 9){ edges{ node{ firstName lastName address1 address2 city company province country zip } } } } }";
                            var res1 = await _apiService.GetAddress(qury);
                            Settings.Customer_Email = res1.data.customer.email;
                            foreach (var item in res1.data.customer.addresses.edges)
                            {
                                Customer_Add customer_Sql = new Customer_Add();
                                customer_Sql.firstName = Convert.ToString(item.node.firstName);
                                customer_Sql.lastName = Convert.ToString(item.node.lastName);
                                customer_Sql.address1 = Convert.ToString(item.node.address1);
                                customer_Sql.address2 = Convert.ToString(item.node.address2);
                                customer_Sql.company = Convert.ToString(item.node.company);
                                customer_Sql.country = Convert.ToString(item.node.country);

                                customer_Sql.zip = item.node.zip;
                                await App.Database.SaveNoteAsync(customer_Sql);
                            }

                            App.Locator.EditSaveAddress.Init();
                            FName = "";
                            LName = "";
                            Address1 = "";
                            Address2 = "";
                            City = "";
                            Country = "";
                            Pincode = "";
                            MobileNumber = "";
                            Province = "";
                            UserDialogs.Instance.HideLoading();

                            var cfg = new ToastConfig("Address added successfully.")
                            {
                                BackgroundColor = Color.Green
                            };
                            UserDialogs.Instance.Toast(cfg);
                            //await App.Current.MainPage.Navigation.PushAsync(new LoginPage());
                            // App.Current.MainPage = new NavigationPage(new LoginPage());

                        }
                        else if (res.data.customerAddressCreate.customerUserErrors.Count > 0)
                        {
                            UserDialogs.Instance.HideLoading();
                            string cs = Convert.ToString(res.data.customerAddressCreate.customerUserErrors[0].message);
                            UserDialogs.Instance.Alert(cs);
                        }
                        else
                        {

                            UserDialogs.Instance.Alert("There are some problem");
                        }
                    }
                    else
                    {
                        UserDialogs.Instance.Alert("Server not connected.");
                    }
                    await App.Current.MainPage.Navigation.PopModalAsync();
                }
                catch (Exception ex)
                {
                    UserDialogs.Instance.HideLoading();
                    UserDialogs.Instance.Alert(ex.Message.ToString());
                }
            }
            else
            {
                //For Edit
                try
                {
                    UpdateAddressRequest update = new UpdateAddressRequest();
                    update.customerAccessToken = Convert.ToString(Settings.Customer_Access_Token);
                    update.id = _editSaveAddressModel.ID;
                    update.address = new Address();
                    update.address.firstName = FName;
                    update.address.lastName = LName;
                    update.address.company = Organization;
                    update.address.address1 = Address1;
                    update.address.address2 = Address2;
                    update.address.city = City;
                    update.address.country = Country;
                    update.address.zip = Pincode;
                    update.address.phone = MobileNumber;
                    update.address.province = Province;
                    string query1 = @"mutation customerAddressUpdate($customerAccessToken: String!, $id: ID!, $address: MailingAddressInput!) {
                                                  customerAddressUpdate(customerAccessToken: $customerAccessToken, id: $id, address: $address) {
                                                    customerAddress {
                                                      id
                                                    }
                                                    customerUserErrors {
                                                      code
                                                      field
                                                      message
                                                    }
                                                  }
                                                }
                                                ";
                    UserDialogs.Instance.ShowLoading();
                    var res2 = await _apiService.UpdateAddres(query1, update);
                     if (res2 != null)
                    {
                        if (res2?.data?.customerAddressUpdate?.customerAddress?.id != null)
                        {
                            Settings.AddressId = res2.data.customerAddressUpdate.customerAddress.id;
                            string accestoken1 = Convert.ToString(Settings.Customer_Access_Token);
                            char quote = '"';
                            string modifiedString1 = quote + accestoken1 + quote;
                            string qury2 = "{ customer(customerAccessToken:" + modifiedString1 + "){ addresses(first: 9){ edges{ node{ firstName lastName address1 address2 city company province country zip } } } } }";
                            var res3 = await _apiService.GetAddress(qury2);
                            Settings.Customer_Email = res3.data.customer.email;
                            foreach (var item in res3?.data?.customer?.addresses?.edges)
                            {
                                Customer_Add customer_Sql1 = new Customer_Add();
                                customer_Sql1.firstName = Convert.ToString(item.node.firstName);
                                customer_Sql1.lastName = Convert.ToString(item.node.lastName);
                                customer_Sql1.address1 = Convert.ToString(item.node.address1);
                                customer_Sql1.address2 = Convert.ToString(item.node.address2);
                                customer_Sql1.company = Convert.ToString(item.node.company);
                                customer_Sql1.country = Convert.ToString(item.node.country);

                                customer_Sql1.zip = item.node.zip;
                                await App.Database.SaveNoteAsync(customer_Sql1);
                            }

                            App.Locator.EditSaveAddress.Init();
                            FName = "";
                            LName = "";
                            Address1 = "";
                            Address2 = "";
                            City = "";
                            Country = "";
                            Pincode = "";
                            MobileNumber = "";
                            Province = "";
                            UserDialogs.Instance.HideLoading();

                            var cfg = new ToastConfig("Address updated successfully.")
                            {
                                BackgroundColor = Color.Green
                            };
                            UserDialogs.Instance.Toast(cfg);
                            //await App.Current.MainPage.Navigation.PushAsync(new LoginPage());
                            // App.Current.MainPage = new NavigationPage(new LoginPage());

                        }
                        else if (res2?.data?.customerAddressUpdate?.customerUserErrors?.Count > 0)
                        {
                            UserDialogs.Instance.HideLoading();
                            UserDialogs.Instance.Alert(res2.data.customerAddressUpdate.customerUserErrors[0].message);
                        }
                        else
                        {

                            UserDialogs.Instance.Alert("There are some problem");
                        }
                    }
                    else
                    {
                        UserDialogs.Instance.Alert("Server not connected.");
                    }
                    await App.Current.MainPage.Navigation.PopModalAsync();
                }
                catch (Exception ex)
                {
                    UserDialogs.Instance.HideLoading();
                    UserDialogs.Instance.Alert(ex.Message.ToString());
                }
            }
            

            // App.Current.MainPage.Navigation.PushAsync(new SaveEditAddressPage());
        });
        public void Init()
        {
            IsEditWay = false;
            Status = false;
            FName = "";
            LName = "";
            Organization = "";
            Address1 = "";
            Address2 = "";
            City = "";
            Country = "";
            Pincode = "";
            MobileNumber = "";
        }
        private bool _status;
        public bool Status
        {
            get { return _status; }
            set { _status = value; }
        }
        private EditSaveAddressModel _editSaveAddressModel;
        public void Init(EditSaveAddressModel editSaveAddressModel)
        {
            try
            {
                _editSaveAddressModel = editSaveAddressModel;
                IsEditWay = true;
                Status = true;
                FName = editSaveAddressModel.firstName;
                LName = editSaveAddressModel.lastName;
                Organization = editSaveAddressModel.company;
                Address1 = editSaveAddressModel.address1;
                Address2 = editSaveAddressModel.address2;
                City = editSaveAddressModel.city;
                Country = editSaveAddressModel.country;
                Pincode = editSaveAddressModel.zip;
                MobileNumber = editSaveAddressModel.phone;
                Province = editSaveAddressModel.province;
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.Alert(ex.Message.ToString());
            }
        }
    }
}