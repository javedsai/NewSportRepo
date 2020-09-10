using System;
using System.Collections.Generic;
using System.Text;

namespace SportDirect.Data.Models.Response
{
    public class LineItemResponse
    {
        public DataIn data { get; set; }
    }
    public class CheckoutIn
    {
        public string id { get; set; }
    }

    public class CheckoutLineItemsAdd
    {
        public CheckoutIn checkout { get; set; }
        public List<object> checkoutUserErrors { get; set; }
    }

    public class DataIn
    {
        public CheckoutLineItemsAdd checkoutLineItemsAdd { get; set; }
    }

}
