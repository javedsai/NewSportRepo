using System;
using System.Collections.Generic;
using System.Text;

namespace SportDirect.Data.Models.Response
{
    public class Data_TR
    {
        public CustomerCreate_ customerCreate { get; set; }
    }

    public class GraphqlResponse
    {
        public Data_TR data { get; set; }

    }

    public class Customer_T
    {
        public string id { get; set; }

    }
    //public class CustomerUserErrors
    //{
    //    public string code { get; set; }
    //    public IList<string> field { get; set; }
    //    public string message { get; set; }

    //}
    public class CustomerCreate_
    {
        public Customer_T customer { get; set; }
        public IList<CustomerUserErrors> customerUserErrors { get; set; }

    }
}
