using System;
using System.Collections.Generic;
using System.Text;

namespace SportDirect.Data.Models.Response
{
    public class UpdateAddressResponseModel
    {
        public UpdateDataModel data { get; set; }
    }
    public class UpdateCustomerAddress
    {
        public string id { get; set; }
    }

    public class UpdateCustomerAddressUpdate
    {
        public UpdateCustomerAddress customerAddress { get; set; }
        public List<QueryErrorModel> customerUserErrors { get; set; }
    }

    public class UpdateDataModel
    {
        public UpdateCustomerAddressUpdate customerAddressUpdate { get; set; }
    }
    public class QueryErrorModel
    {
        public string code { get; set; }
        public string field { get; set; }
        public string message { get; set; }
    }
}
