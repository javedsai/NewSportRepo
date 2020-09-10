using System;
using System.Collections.Generic;
using System.Text;

namespace SportDirect.Data.Models.Response
{
   public class BaseResponseModel
    {
        public string code { get; set; }
        public string message { get; set; }
        public string token { get; set; }
    }
}
