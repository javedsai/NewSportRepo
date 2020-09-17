using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace SportDirect.Data.Models.Response
{
    public class GetCollectionProductResponseModel
    {
        public CollectionProductListDataData data { get; set; }
    }
    public class CollectionProductListDataPageInfo
    {
        public bool hasNextPage { get; set; }
        public bool hasPreviousPage { get; set; }
    }

    public class CollectionProductListDataSelectedOption
    {
        public string name { get; set; }
        public string value { get; set; }
    }

    public class CollectionProductListDataImage
    {
        public string id { get; set; }
        public string originalSrc { get; set; }
    }

    public class CollectionProductListDataNode2
    {
        public string id { get; set; }
        public bool available { get; set; }
        public string title { get; set; }
        public IList<CollectionProductListDataSelectedOption> selectedOptions { get; set; }
        public string price { get; set; }
        public CollectionProductListDataImage image { get; set; }
    }

    public class CollectionProductListDataEdge2
    {
        public CollectionProductListDataNode2 node { get; set; }
    }

    public class CollectionProductListDataVariants
    {
        public IList<CollectionProductListDataEdge2> edges { get; set; }
    }

    public class CollectionProductListDataNode
    {
        public string id { get; set; }
        public string productType { get; set; }
        public string description { get; set; }
        public ProductImages images { get; set; }

        public CollectionProductListDataVariants variants { get; set; }
        public string title { get; set; }
    }
    public class ProductNode
    {
        public string id { get; set; }
        public string originalSrc { get; set; }
    }

    public class ProductEdge
    {
        public ProductNode node { get; set; }
    }

    public class ProductImages
    {
        public List<ProductEdge> edges { get; set; }
    }
    public class CollectionProductListDataEdge
    {
        public string cursor { get; set; }
        public CollectionProductListDataNode node { get; set; }
    }

    public class CollectionProductListDataProducts : BindableObject
    {
        public CollectionProductListDataPageInfo pageInfo { get; set; }
        private ObservableCollection<CollectionProductListDataEdge> _edges;

        public ObservableCollection<CollectionProductListDataEdge> edges
        {
            get { return _edges; }
            set { _edges = value;OnPropertyChanged(nameof(edges)); }
        }
    }

    public class CollectionProductListDataCollectionByHandle
    {
        public string title { get; set; }
        public CollectionProductListDataProducts products { get; set; }
    }

    public class CollectionProductListDataShop
    {
        public string name { get; set; }
        public CollectionProductListDataCollectionByHandle collectionByHandle { get; set; }
    }

    public class CollectionProductListDataData
    {
        public CollectionProductListDataShop shop { get; set; }
    }
}
