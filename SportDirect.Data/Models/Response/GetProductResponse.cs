using System;
using System.Collections.Generic;
using System.Text;

namespace SportDirect.Data.Models.Response
{

    public class GetProductResponse
    {
        public ProductData data { get; set; }
    }
    public partial class ProductData
    {
        public Shop shop { get; set; }
    }

    public partial class Shop
    {
        public CollectionProductListDataProducts products { get; set; }
    }
}
