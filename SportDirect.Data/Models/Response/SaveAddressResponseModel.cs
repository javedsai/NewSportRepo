using System;
using System.Collections.Generic;
using System.Text;

namespace SportDirect.Data.Models.Response
{
   public class SaveAddressResponseModel
    {
    }
    public class Customer_Address
    {
        public int Cus_id { get; set; }
        public string id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public DateTime createdAt { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string city { get; set; }
        public string company { get; set; }
        public string province { get; set; }
        public string phone { get; set; }
        public string country { get; set; }
        public string zip { get; set; }
    }


    public class Customer_Info
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public DateTime createdAt { get; set; }
        public string Customer_Access_Token { get; set; }
        public string customerID { get; set; }
    }
}
