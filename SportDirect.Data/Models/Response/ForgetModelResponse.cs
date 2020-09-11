using System;
using System.Collections.Generic;
using System.Text;

namespace SportDirect.Data.Models.Response
{
    public class ForgetModelResponse
    {
        public UserData data { get; set; }
        public List<Error> errors { get; set; }
    }
    public class CustomerRecover
    {
        public List<object> customerUserErrors { get; set; }
    }

    public class UserData
    {
        public CustomerRecover customerRecover { get; set; }
    }



    public class Location
    {
        public int line { get; set; }
        public int column { get; set; }
    }

    public class Error
    {
        public string message { get; set; }
        public List<Location> locations { get; set; }
        public List<string> path { get; set; }
    }

}
