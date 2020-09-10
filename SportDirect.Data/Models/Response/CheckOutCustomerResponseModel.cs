using System;
using System.Collections.Generic;
using System.Text;

namespace SportDirect.Data.Models.Response
{
    public class CheckOutCustomerResponseModel
    {
        public DataInformation data { get; set; }
    }

    public class CheckoutInfo
    {
        public string id { get; set; }
    }

    public class CustomerInformation
    {
        public string id { get; set; }
    }

    public class CheckoutCustomerAssociateV2
    {
        public CheckoutInfo checkout { get; set; }
        public List<object> checkoutUserErrors { get; set; }
        public CustomerInformation customer { get; set; }
    }

    public class DataInformation
    {
        public CheckoutCustomerAssociateV2 checkoutCustomerAssociateV2 { get; set; }
    }

}
