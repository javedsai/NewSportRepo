using System;
using System.Collections.Generic;
using System.Text;

namespace SportDirect.Data.Models.Response
{
    public class CartUpdateResponseModel
    {
        public UpdateData data { get; set; }
    }
    public class UpdateCheckout
    {
        public string id { get; set; }
    }

    public class CheckoutLineItemsUpdate
    {
        public UpdateCheckout checkout { get; set; }
        public List<object> checkoutUserErrors { get; set; }
    }

    public class UpdateData
    {
        public CheckoutLineItemsUpdate checkoutLineItemsUpdate { get; set; }
    }
}
