using System;
using System.Collections.Generic;
using System.Text;

namespace SportDirect.Data.Models.Request
{
    public class CheckOutCustomerRequestModel
    {
        public string checkoutId { get; set; }
        public string customerAccessToken { get; set; }
    }
}
