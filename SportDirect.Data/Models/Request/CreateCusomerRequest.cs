using System;
using System.Collections.Generic;
using System.Text;

namespace SportDirect.Data.Models.Request
{
    public class Input
    {
        public string email { get; set; }
        public string password { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        //public string phone { get; set; }

    }
    public class CreateCusomerRequest
    {
        public Input input { get; set; }

    }
}
