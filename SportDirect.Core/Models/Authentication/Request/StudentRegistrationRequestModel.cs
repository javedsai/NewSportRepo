using System;
using System.Collections.Generic;
using System.Text;

namespace SportDirect.Core.Models.Authentication.Request
{
    public class StudentRegistrationRequestModel
    {
        public string student_name { get; set; }
        public int universityID { get; set; }
        public int courseID { get; set; }
        public string roll_no { get; set; }
        public string course_name { get; set; }
        public string mobile_no { get; set; }
        public string email { get; set; }
    }
}
