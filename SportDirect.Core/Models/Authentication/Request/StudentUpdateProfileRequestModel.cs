using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SportDirect.Core.Models.Authentication.Request
{
    public class StudentUpdateProfileRequestModel
    {
        public string student_name { get; set; }
        public string mobile_no { get; set; }
        public string localtion { get; set; }
        public string roll_no { get; set; }
    }
}
