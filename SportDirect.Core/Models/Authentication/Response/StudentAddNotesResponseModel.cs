using System;
using System.Collections.Generic;
using System.Text;

namespace SportDirect.Core.Models.Authentication.Response
{
    public class AddNotesResponseData
    {
        public int id { get; set; }
        public int userID { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string price { get; set; }
        public int courseID { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
    }    
}
