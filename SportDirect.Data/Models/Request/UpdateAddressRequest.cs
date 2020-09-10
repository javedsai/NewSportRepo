using System;
using System.Collections.Generic;
using System.Text;

namespace SportDirect.Data.Models.Request
{
    public class UpdateAddressRequest
    {
        public string customerAccessToken { get; set; }
        public string id { get; set; }
        public Address address { get; set; }
    }
    
}
