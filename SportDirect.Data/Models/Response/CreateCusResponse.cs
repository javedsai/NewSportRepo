using System;
using System.Collections.Generic;
using System.Text;

namespace SportDirect.Data.Models.Response
{

    public class CustomerAddress
    {
        public string id { get; set; }

    }
    public class CustomerAddressCreate
    {
        public CustomerAddress customerAddress { get; set; }
        public IList<CustomerUserErrors> customerUserErrors { get; set; }


    }
    public class Data_Custo
    {
        public CustomerAddressCreate customerAddressCreate { get; set; }

    }
    public class CreateCusResponse
    {
        public Data_Custo data { get; set; }

    }


}
