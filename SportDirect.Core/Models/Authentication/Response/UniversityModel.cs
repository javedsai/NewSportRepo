using System;
using System.Collections.Generic;
using System.Text;

namespace SportDirect.Core.Models.Authentication.Response
{
    public class UniversityModel
    {
        public int id { get; set; }
        public string uni_name { get; set; }
        public string address { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
    }
}
