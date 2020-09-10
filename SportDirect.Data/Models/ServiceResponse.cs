using SportDirect.Data.Models.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace SportDirect.Data.Models
{

   public class ServiceResponse<T>:BaseResponseModel
    {
        public T Data { get; set; }
        public int expires_in { get; set; }
    }
}
