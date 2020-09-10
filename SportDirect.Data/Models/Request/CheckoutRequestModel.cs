using System;
using System.Collections.Generic;
using System.Text;

namespace SportDirect.Data.Models.Request
{
    public class CheckoutRequestModel
    {
        public Inputs input { get; set; }
    }
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class LineItem
    {
        public int quantity { get; set; }
        public string variantId { get; set; }
    }

    public class ShippingAddress
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string city { get; set; }
        public string company { get; set; }
        public string country { get; set; }
        public string phone { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string zip { get; set; }
        public string province { get; set; }
    }

    public class Inputs
    {
        public List<LineItem> lineItems { get; set; }
        public string email { get; set; }
        public ShippingAddress shippingAddress { get; set; }
        public string note { get; set; }
    }


}
