using System;
using System.Collections.Generic;
using System.Text;

namespace SportDirect.Data.Models.Response
{
    public class CollectionResponse
    {
        public CollectionData data { get; set; }
    }
    public class CollectionNode2
    {
        public string id { get; set; }
        public string title { get; set; }
    }

    public class CollectionEdge2
    {
        public CollectionNode2 node { get; set; }
    }

    public class CollectionProducts
    {
        public List<CollectionEdge2> edges { get; set; }
    }

    public class CollectionNode
    {
        public string id { get; set; }
        public string title { get; set; }
        public string handle { get; set; }
        public CollectionImageData image { get; set; }
        public CollectionProducts products { get; set; }
    }
    public class CollectionImageData
    {
        public string id { get; set; }
        public string originalSrc { get; set; }
    }

    public class CollectionEdge
    {
        public CollectionNode node { get; set; }
    }

    public class Collections
    {
        public List<CollectionEdge> edges { get; set; }
    }

    public class CollectionShop
    {
        public string name { get; set; }
        public Collections collections { get; set; }
    }

    public class CollectionData
    {
        public CollectionShop shop { get; set; }
    }



}
