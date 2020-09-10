using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SportDirect.Data.Models.Response
{
    class CreateCustomerResponse
    {
        public Customer customer { get; set; }
    }
    public class Addresses_CreaRes
    {
        public long id { get; set; }
        public long customer_id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string company { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string city { get; set; }
        public string province { get; set; }
        public string country { get; set; }
        public string zip { get; set; }
        public string phone { get; set; }
        public string name { get; set; }
        public string province_code { get; set; }
        public string country_code { get; set; }
        public string country_name { get; set; }
        [JsonProperty("default")]
        public bool default_t { get; set; }

    }
    public class Default_address_CustReq
    {
        public long id { get; set; }
        public long customer_id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string company { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string city { get; set; }
        public string province { get; set; }
        public string country { get; set; }
        public string zip { get; set; }
        public string phone { get; set; }
        public string name { get; set; }
        public string province_code { get; set; }
        public string country_code { get; set; }
        public string country_name { get; set; }
        [JsonProperty("default")]
        public bool default_2 { get; set; }

    }
    public class Customer
    {
        public long id { get; set; }
        public string email { get; set; }
        public bool accepts_marketing { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public int orders_count { get; set; }
        public string state { get; set; }
        public string total_spent { get; set; }
        public string last_order_id { get; set; }
        public string note { get; set; }
        public bool verified_email { get; set; }
        public string multipass_identifier { get; set; }
        public bool tax_exempt { get; set; }
        public string phone { get; set; }
        public string tags { get; set; }
        public string last_order_name { get; set; }
        public string currency { get; set; }
        public IList<Addresses_CreaRes> addresses { get; set; }
        public DateTime accepts_marketing_updated_at { get; set; }
        public IList<object> marketing_opt_in_level { get; set; }
        public IList<object> tax_exemptions { get; set; }
        public string admin_graphql_api_id { get; set; }
        public Default_address_CustReq default_address { get; set; }

    }
}
