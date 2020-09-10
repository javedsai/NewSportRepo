using System;
using System.Collections.Generic;
using System.Text;

namespace SportDirect.Data.Models.Request
{
    public class SaveQueriesRequestModel :BaseRequestModel
    {
        public string name { get; set; }
        public string contactNumber { get; set; }
        public string description { get; set; }
    }
}
