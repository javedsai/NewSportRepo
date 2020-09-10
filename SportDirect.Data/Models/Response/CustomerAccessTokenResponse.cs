using System;
using System.Collections.Generic;
using System.Text;

namespace SportDirect.Data.Models.Response
{
 

    public class CustomerAccessToken_Acc
    {
        public string accessToken { get; set; }
        public DateTime expiresAt { get; set; }

    }
    public class CustomerAccessTokenRenew
    {
        public CustomerAccessToken_Acc customerAccessToken { get; set; }
        public IList<UserErrors_Acc> userErrors { get; set; }

    }
    public class Data_Acc
    {
        public CustomerAccessTokenRenew customerAccessTokenRenew { get; set; }

    }
    public class CustomerAccessTokenResponse
    {
        public Data_Acc data { get; set; }

    }
    public class UserErrors_Acc
    {
        public IList<string> field { get; set; }
        public string message { get; set; }

    }
    //public class CustomerAccessTokenRenew
    //{
    //    public IList<undefined> customerAccessToken { get; set; }
    //    public IList<UserErrors> userErrors { get; set; }

    //}
    //public class Data
    //{
    //    public CustomerAccessTokenRenew customerAccessTokenRenew { get; set; }

    //}
    //public class Application
    //{
    //    public Data data { get; set; }

    //}



}
