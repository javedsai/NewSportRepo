using System;
using System.Collections.Generic;
using System.Text;

namespace SportDirect.Data.Models.Response
{
    //public class CustomerAccessToken
    //{
    //    public string accessToken { get; set; }
    //    public DateTime expiresAt { get; set; }

    //}
    //public class CustomerAccessTokenCreate
    //{
    //    public CustomerAccessToken customerAccessToken { get; set; }
    //    public IList<CustomerUserErrors> customerUserErrors { get; set; }

    //}
    //public class Data_T
    //{
    //    public CustomerAccessTokenCreate customerAccessTokenCreate { get; set; }

    //}
    public class CustomerUserErrors
    {
        public string code { get; set; }
        public IList<string> field { get; set; }
        public string message { get; set; }

    }
    //public class CustLoginResponse
    //{
    //    public Data_T data { get; set; }

    //}
    public class CustomerAccessToken
    {
        public string accessToken { get; set; }
        public DateTime expiresAt { get; set; }

    }
    public class CustomerAccessTokenCreate
    {
        public CustomerAccessToken customerAccessToken { get; set; }
        public IList<CustomerUserErrors> customerUserErrors { get; set; }

    }
    public class Data_T
    {
        public CustomerAccessTokenCreate customerAccessTokenCreate { get; set; }

    }
    public class CustLoginResponse
    {
        public Data_T data { get; set; }

    }



}
