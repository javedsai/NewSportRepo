using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SportDirect.Assets
{
    class SQlliteClass
    {
    }

    public class Customer_Add
    {
        [PrimaryKey, AutoIncrement]
        public int Cus_id { get; set; }
        public string id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public DateTime createdAt { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string city { get; set; }
        public string company { get; set; }
        public string country { get; set; }
        public string zip { get; set; }
    }
    public class Customer_Sqlite
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public DateTime createdAt { get; set; }
        public string Customer_Access_Token { get; set; }
        public string customerID { get; set; }
    }
    public class Mycart
    {
        [PrimaryKey, AutoIncrement]
        public long Id { get; set; }
        public long VariantId { get; set; }
        public string NewArrivalImages { get; set; }
        public int quantity { get; set; }
        public string MinusImage { get; set; }
        public string PlusImage { get; set; }
        public string TitleName { get; set; }
        public string Rating { get; set; }
        public string AddProduct { get; set; }
        public string Price { get; set; }
        public string ProductID { get; set; }
        public string ImageUrl { get; set; }
        public string variants { get; set; }
    }
}
