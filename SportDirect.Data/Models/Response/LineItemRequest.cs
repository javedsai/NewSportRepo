using System;
using System.Collections.Generic;
using System.Text;

namespace SportDirect.Data.Models.Response
{
    public class LineItemRequest
    {
        public List<LineItemsInfo> lineItems { get; set; }
        public string checkoutId { get; set; }
    }
    public class LineItemsInfo
    {
        public int quantity { get; set; }
        public string variantId { get; set; }
    }
}
