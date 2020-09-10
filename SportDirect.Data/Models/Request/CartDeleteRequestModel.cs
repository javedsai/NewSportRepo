using System;
using System.Collections.Generic;
using System.Text;

namespace SportDirect.Data.Models.Request
{
  public  class CartDeleteRequestModel
    {
        public string checkoutId { get; set; }
        public List<string> lineItemIds { get; set; }
    }
}
