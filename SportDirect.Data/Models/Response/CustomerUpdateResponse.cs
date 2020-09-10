using System;
using System.Collections.Generic;
using System.Text;

namespace SportDirect.Data.Models.Response
{
    public class CustomerUpdateResponse
    {
        public CustomeData data { get; set; }
    }
    public class CustomerUpdateID
    {
        public string id { get; set; }
    }

    public class CustomerUpdate
    {
        public CustomerUpdateID customer { get; set; }
        public object customerAccessToken { get; set; }
        public List<CustomerUserError> customerUserErrors { get; set; }
    }

    public class CustomeData
    {
        public CustomerUpdate customerUpdate { get; set; }
    }
    public class CustomerUserError
    {
        public string code { get; set; }
        public List<string> field { get; set; }
        public string message { get; set; }
    }

}
