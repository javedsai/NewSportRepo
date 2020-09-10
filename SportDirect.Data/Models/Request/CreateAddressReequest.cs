using System;
using System.Collections.Generic;
using System.Text;

namespace SportDirect.Data.Models.Request
{
    public class Address
    {
        public string firstName { get; set; }
        //public string id { get; set; }
        public string lastName { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string city { get; set; }
        public string company { get; set; }
        public string country { get; set; }
        public string zip { get; set; }
        public string phone { get; set; }
        public string province { get; set; }

    }
    public class CreateAddressReequest
    {
        public string id { get; set; }
        public string customerAccessToken { get; set; }
        public Address address { get; set; }

    }
}
