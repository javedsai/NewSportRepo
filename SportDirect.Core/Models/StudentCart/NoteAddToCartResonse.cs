using System;
namespace SportDirect.Core.Models.StudentCart
{
    public class NoteAddToCartResonse
    {
        public bool is_order { get; set; }
        public bool is_payment { get; set; }
        public int id { get; set; }
        public string transID { get; set; }
        public string userID { get; set; }
        public string noteID { get; set; }
        public string price { get; set; }
        public string quantity { get; set; }
        public string totalAmount { get; set; }
        public DateTime updatedAt { get; set; }
        public DateTime createdAt { get; set; }
    }
}
