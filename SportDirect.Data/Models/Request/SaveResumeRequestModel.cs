using System;
using System.Collections.Generic;
using System.Text;

namespace SportDirect.Data.Models.Request
{
    public class SaveResumeRequestModel :BaseRequestModel
    {
        public string jobId { get; set; }
        public byte[] resume { get; set; }
        public string FileName { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string description { get; set; }
    }
}
