using System;
using System.Collections.Generic;
using System.Text;

namespace SportDirect.Core.Models.Authentication.Request
{
    public class SetPasswordRequestModel
    {
        public string email { get; set; }
        public string password { get; set; }
    }
}
