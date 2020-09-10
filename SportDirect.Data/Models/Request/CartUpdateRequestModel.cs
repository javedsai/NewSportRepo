using System;
using System.Collections.Generic;
using System.Text;

namespace SportDirect.Data.Models.Request
{
    public class UpdateLineItem
    {
        public int quantity { get; set; }
        public string id { get; set; }
        public string variantId { get; set; }
    }

    public class CartUpdateRequestModel
    {
        public string checkoutId { get; set; }
        public List<UpdateLineItem> lineItems { get; set; }
    }
}
