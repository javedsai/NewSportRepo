using System;
using System.Collections.Generic;
using System.Text;

namespace SportDirect.Data.Models.Response
{
    public class CheckoutResponseModel
    {
        public CheckoutData data { get; set; }
    }
    public class Checkout
    {
        public string id { get; set; }
    }

    public class CheckoutCreate
    {
        public Checkout checkout { get; set; }
        public List<object> checkoutUserErrors { get; set; }
    }

    public class CheckoutData
    {
        public CheckoutCreate checkoutCreate { get; set; }
    }
}
