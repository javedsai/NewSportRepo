using System;
using System.Collections.Generic;
using System.Text;

namespace SportDirect.Data.Models.Request
{
    public class Input_Log
    {
        public string email { get; set; }
        public string password { get; set; }

    }
    public class LoginRequest
    {
        public Input_Log input { get; set; }

    }
}
