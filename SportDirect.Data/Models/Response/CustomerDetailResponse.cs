using System;
using System.Collections.Generic;
using System.Text;

namespace SportDirect.Data.Models.Response
{
    public class CustomerDetailResponse
    {
        public Data_Cus data { get; set; }
    }

    public class Node
    {
        public string id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string city { get; set; }
        public string company { get; set; }
        public string province { get; set; }
        public string country { get; set; }
        public string zip { get; set; }
        public string phone { get; set; }
        public int quantity { get; set; }
        public string title { get; set; }
        public Variant variant { get; set; }

    }
    public class Variant
    {
        public string id { get; set; }
        public VariantImage image { get; set; }

        public string price { get; set; }
        public List<CollectionProductListDataSelectedOption> selectedOptions { get; set; }
    }
    public class VariantImage
    {
        public string id { get; set; }
        public string originalSrc { get; set; }
    }

    public class Edges
    {
        public Node node { get; set; }

    }
    public class Addresses
    {
        public IList<Edges> edges { get; set; }

    }

    public class Customer_Cus
    {
        public string id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public DateTime createdAt { get; set; }
        public LastIncompleteCheckout lastIncompleteCheckout { get; set; }
        public Addresses addresses { get; set; }
        public Orders orders { get; set; }
    }

    public class LastIncompleteCheckout
    {
        public string id { get; set; }
        public DateTime createdAt { get; set; }
        public string webUrl { get; set; }
        public LineItems lineItems { get; set; }
    }

    public class LineItems
    {
        public List<EdgeInfo> edges { get; set; }
    }
    public class EdgeInfo
    {
        public Node node { get; set; }
    }
    public class Orders
    {
        public List<object> edges { get; set; }
    }
    public class Data_Cus
    {
        public Customer_Cus customer { get; set; }

    }


}
