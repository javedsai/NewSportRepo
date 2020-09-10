using System;
using System.Collections.Generic;
using System.Text;

namespace SportDirect.Data.Models.Response
{
    public class SaveResumeResponseModel 
    {
        public Status1 status { get; set; }
    }
    public class Status1
    {
        public string code { get; set; }
        public string message { get; set; }
    }
}