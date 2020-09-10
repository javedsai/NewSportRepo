using System;
using System.Collections.Generic;
using System.Text;

namespace SportDirect.Core.Models.Authentication
{
    public class StudentDetail
    {
        public int id { get; set; }
        public string student_name { get; set; }
        public string profile_image { get; set; }
        public string mobile_no { get; set; }
        public string email { get; set; }
        public int universityID { get; set; }
        public int courseID { get; set; }
        public string roll_no { get; set; }
        public string verification_code { get; set; }
        public bool is_verified { get; set; }
        public string localtion { get; set; }
        public string password { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
    }

    public class RootStudentLoginResponseModel<T>
    {
        public int status { get; set; }
        public string message { get; set; }
        public bool auth { get; set; }
        public string accessToken { get; set; }
        public string reason { get; set; }
        public T data { get; set; }
    }
}
