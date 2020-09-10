using System;
using System.Collections.Generic;
using System.Text;

namespace SportDirect.Data.Models.Response
{
   
    public class CustomerAddressDelete
    {
        public IList<CustomerUserErrors> customerUserErrors { get; set; }
        public string deletedCustomerAddressId { get; set; }

    }
    public class Data_De
    {
        public CustomerAddressDelete customerAddressDelete { get; set; }

    }
    public class DeleteCustResponse
    {
        public Data_De data { get; set; }

    }


}
