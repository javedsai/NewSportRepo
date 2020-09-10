using System;
namespace SportDirect.Core.Models.StudentCart
{
    public class AddItemToCartRequestModel
    {
        public string noteID { get; set; }
        public string userID { get; set; }
        public string price { get; set; }
        public string quantity { get; set; }
        public string totalAmount { get; set; }
    }
}
