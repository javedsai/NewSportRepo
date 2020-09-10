using System;
using System.Collections.Generic;
using System.Text;

namespace SportDirect.Data.Models.Request
{
    public class CreateCustomerRequest
    {
        public Customer_create customer { get; set; }
    }
    public class Addresses_Create
    {
        public string address1 { get; set; }
        public string city { get; set; }
        public string province { get; set; }
        public string phone { get; set; }
        public string zip { get; set; }
        public string last_name { get; set; }
        public string first_name { get; set; }
        public string country { get; set; }

    }
    public class Customer_create
    {
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public bool verified_email { get; set; }
        public IList<Addresses_Create> addresses { get; set; }
        public string password { get; set; }
        public string password_confirmation { get; set; }
        public bool send_email_welcome { get; set; }

    }
}
