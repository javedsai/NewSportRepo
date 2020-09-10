using System;
namespace SportDirect.Core.Models.User
{
    public class CourseModel
    {
        public int id { get; set; }
        public string course_name { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
    }
}
