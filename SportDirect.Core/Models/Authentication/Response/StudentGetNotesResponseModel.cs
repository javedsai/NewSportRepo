using System;
using System.Collections.Generic;
using System.Text;
using SportDirect.Core.Helpers;

namespace SportDirect.Core.Models.Authentication.Response
{
    public class Notefile
    {
        public int id { get; set; }
        public int userID { get; set; }
        public int noteID { get; set; }
        public string fileName { get; set; }
        public string fileType { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
    }

    public class User
    {
        public string student_name { get; set; }
        public string profile_image { get; set; }
    }

    public class NotesModel : BindableBase
    {
        public int id { get; set; }
        public int userID { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string price { get; set; }
        public int courseID { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public List<Notefile> notefiles { get; set; }
        public User user { get; set; }
        public int NoOfPages
        {   get
            {
                int noOfPage = 0;
                if(notefiles?.Count>=1)
                {
                    noOfPage = notefiles.Count;
                }
                return noOfPage;
            }
        }
        private string _noteThumnail = string.Empty;
        public string NoteThumnail { get => _noteThumnail; set { SetProperty(ref _noteThumnail, value); } }
    }
}
