using System;
using System.Collections.Generic;
using SportDirect.Core.Helpers;
using SportDirect.Core.Models.Authentication.Response;

namespace SportDirect.Core.Models.StudentCart
{
    public class CartModel : BindableBase
    {
        public int id { get; set; }
        public int userID { get; set; }
        public int noteID { get; set; }
        public string price { get; set; }
        public int quantity { get; set; }
        public string transID { get; set; }
        public string totalAmount { get; set; }
        public bool is_order { get; set; }
        public bool is_payment { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public List<NotesModel> notes { get; set; }
        public int NoOfPages
        {
            get
            {
                int noOfPage = 0;
                if (notes?.Count >= 1)
                {
                    noOfPage = notes[0].NoOfPages;
                }
                return noOfPage;
            }
        }
        public string NotesTitle
        {
            get
            {
                return notes[0].name;
            }
        }
        public string NotesOwnerName
        {
            get
            {
                return notes[0].user.student_name;
            }
        }
        public string NotesOwnerPic
        {
            get
            {
                return notes[0].user.profile_image;
            }
        }
        private string _noteThumnail = string.Empty;
        public string NoteThumnail { get => _noteThumnail; set { SetProperty(ref _noteThumnail, value); } }
    }
}
