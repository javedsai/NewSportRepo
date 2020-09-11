using Acr.UserDialogs;
using SportDirect.Core.Helpers;
using SportDirect.Data.Models.Request;
using SportDirect.Helpers;
using SportDirect.Service.Interfaces;
using SportDirect.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace SportDirect.Areas.Authentication.ViewModels
{
  public  class ForgetPasswordPageViewModel:BasePageViewModel
    {
        IApiService _apiService;

        public bool _isEmailErrorVisible;
        public bool IsEmailErrorVisible
        {
            get { return _isEmailErrorVisible; }
            set { _isEmailErrorVisible = value; RaisePropertyChanged(nameof(IsEmailErrorVisible)); }
        }
        public bool _isSendButtonEnabled;
        public bool IsSendButtonEnabled
        {
            get { return _isSendButtonEnabled; }
            set { _isSendButtonEnabled = value; RaisePropertyChanged(nameof(IsSendButtonEnabled)); }
        }
        public string _email = Settings.Customer_Email;
        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                RaisePropertyChanged(nameof(Email));
            }
        }

        public bool CheckValidation()
        {
            if (IsEmailErrorVisible
               )


            {
                IsSendButtonEnabled = false;
                return false;
            }
            else if (string.IsNullOrEmpty(Email))
            {
                IsSendButtonEnabled = false;
                return false;
            }
            else
            {
                IsSendButtonEnabled = true;
                return true;
            }
        }
        public ForgetPasswordPageViewModel(IApiService apiService)
        {
            _apiService = apiService;
        }
        public ICommand GetBackCommand => new Command(async () =>
        {
            await App.Current.MainPage.Navigation.PopModalAsync();
        });
        public ICommand SendButtonClicked => new Command(async (obj) =>
        {
            UserDialogs.Instance.ShowLoading();
            try
            {
                string queryid_id = @"mutation customerRecover($email: String!) {
                      customerRecover(email: $email) {
                        customerUserErrors {
                          code
                          field
                          message
                        }
                      }
                    }";
                ForgetModelRequest forgetRequest = new ForgetModelRequest();
                forgetRequest.email = Email;
                var res = await _apiService.ForgetPassword(queryid_id, forgetRequest);
                if (res.data.customerRecover.customerUserErrors != null)
                {
                    if (!string.IsNullOrEmpty(Convert.ToString(res.data.customerRecover)))
                    {
                        // SettingExtension.AccessToken = Convert.ToString(res.data.customerAccessTokenCreate.customerAccessToken.accessToken);
                        Email = string.Empty;
                        IsEmailErrorVisible = false;

                        UserDialogs.Instance.Alert("Reset link has been send to your registered mail");
                        //  UserDialogs.Instance.HideLoading();
                    }
                    else if (res.data.customerRecover.customerUserErrors.Count > 0)
                    {
                        string msg = Convert.ToString(res.data.customerRecover.customerUserErrors[0]);
                        UserDialogs.Instance.Alert("Please enter the valid emailid and password.");
                    }
                    else
                    {
                        UserDialogs.Instance.Alert("Please enter the valid emailid and password.");
                    }
                }
                else
                {
                     UserDialogs.Instance.Alert("Please Enter Valid Mail");
                }

            }
            catch (Exception ex)
            {
                UserDialogs.Instance.Alert(ex.Message.ToString());
            }
            UserDialogs.Instance.HideLoading();
        });
        // UserDialogs.Instance.Alert("In progress");
    }
}
