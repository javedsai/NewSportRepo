using System;
using System.Collections.Generic;
using System.Text;

namespace SportDirect.Data.Models.Request
{
 
    public class DeleteCusRequest
    {
        public string id { get; set; }
        public string customerAccessToken { get; set; }

    }
}
