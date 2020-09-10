using SportDirect.Data.Models.Request;
using SportDirect.Data.Models.Response;
using SportDirect.Service.Helpers;
using SportDirect.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SportDirect.Service.Services
{
    public class ApiService : BaseApiServices, IApiService
    {
        public async Task<DashboardResponseModel> GetDashboardAync()
        {
            var dict = new Dictionary<string, string>();
            var res = await GetAsync<DashboardResponseModel>(Urls.DashboardUrl, dict);
            return res;
        }
        public async Task<SaveResumeResponseModel> SaveResumeAync(SaveResumeRequestModel saveResumeRequestModel)
        {
            var dict = new Dictionary<string, string>();
            dict.Add("jobId", saveResumeRequestModel.jobId);
            dict.Add("name", saveResumeRequestModel.name);
            dict.Add("email", saveResumeRequestModel.email);
            dict.Add("phone", saveResumeRequestModel.phone);
            dict.Add("description", saveResumeRequestModel.description);
            var res = await PostAsyncMultipartFormData<SaveResumeResponseModel>(Urls.SaveResumeUrl, saveResumeRequestModel.resume, saveResumeRequestModel.FileName, dict);
            return res;
        }
        //public async Task<LoginResponseModal> Login(string Email, string Password)
        //{
        //    var res = await GetAsyncWithUserPassword<LoginResponseModal>(Urls.Login_Url, Email, Password);
        //    return res;
        //}
        public async Task<HttpResponseMessage> CreateCustomerPostAsyn(CreateCustomerRequest obj_custrequest)
        {
            var res = await PostAsyncWithAccessToken<CreateCustomerRequest>(Urls.CreateCustomer_Url, obj_custrequest);
            return res;
        }
        public async Task<GetProductResponse> GetProduct(string query)
        {
            var res = await PostAsynWithOutvariable<GetProductResponse>(query);
            return res;
        }
        public async Task<CustLoginResponse> CustomerLogin(string query, LoginRequest obj_create)
        {
            var res = await PostAsynGraphql<LoginRequest, CustLoginResponse>(query, obj_create);
            return res;
        }
        public async Task<GraphqlResponse> CreateCusmerbyGraphql(string query, CreateCusomerRequest obj_create)
        {
            var res = await PostAsynGraphql<CreateCusomerRequest, GraphqlResponse>(query, obj_create);
            return res;
        }
        public async Task<CustomerUpdateResponse> CustomerUpdate(string query, CustomerUpdateRequest obj_create)
        {
            var res = await PostAsynGraphql<CustomerUpdateRequest, CustomerUpdateResponse>(query, obj_create);
            return res;
        }
        public async Task<CustomerAccessTokenResponse> RenewCustomerToken(string query, CustomerAccRequest obj_create)
        {
            var res = await PostAsynGraphql<CustomerAccRequest, CustomerAccessTokenResponse>(query, obj_create);
            return res;
        }
        public async Task<CustomerDetailResponse> GetCustomer(string query)
        {
            var res = await PostAsynWithOutvariable<CustomerDetailResponse>(query);
            return res;
        }
        public async Task<CreateCusResponse> CreateAddress(string query, CreateAddressReequest createAddressReequest)
        {
            var res = await PostAsynGraphql<CreateAddressReequest, CreateCusResponse>(query, createAddressReequest);
            return res;
        }
        public async Task<GetProductResponse> SortListOfProduct(string query)
        {
            var res = await PostAsynWithOutvariable<GetProductResponse>(query);
            return res;
        }
        public async Task<CustomerDetailResponse> GetAddress(string query)
        {
            var res = await PostAsynWithOutvariable<CustomerDetailResponse>(query);
            return res;
        }
        public async Task<DeleteCustResponse> DeleteAddress(string query, DeleteCusRequest deleteCusRequest)
        {
            var res = await PostAsynGraphql<DeleteCusRequest, DeleteCustResponse>(query, deleteCusRequest);
            return res;
        }
        public async Task<UpdateAddressResponseModel> UpdateAddres(string query, UpdateAddressRequest createAddressReequest)
        {
            var res = await PostAsynGraphql<UpdateAddressRequest, UpdateAddressResponseModel>(query, createAddressReequest);
            return res;
        }
        public async Task<CreateCusResponse> GetCartItem(string query, CreateAddressReequest createAddressReequest)
        {
            var res = await PostAsynGraphql<CreateAddressReequest, CreateCusResponse>(query, createAddressReequest);
            return res;
        }

        public async Task<CollectionResponse> GetCollection(string query)
        {
            var res = await PostAsynWithOutvariable<CollectionResponse>(query);
            return res;
        }
        public async Task<GetCollectionProductResponseModel> GetCollectionListData(string query)
        {
            var res = await PostAsynWithOutvariable<GetCollectionProductResponseModel>(query);
            return res;
        }

        public async Task<CheckoutResponseModel> CheckOutData(string queryId, CheckoutRequestModel request)
        {
            var res = await PostAsynGraphql<CheckoutRequestModel, CheckoutResponseModel>(queryId, request);
            return res;
        }

        public async Task<CheckOutCustomerResponseModel> CheckOutAssociate(string queryCustomerAssociate, CheckOutCustomerRequestModel checkOut)
        {
            var res = await PostAsynGraphql<CheckOutCustomerRequestModel, CheckOutCustomerResponseModel>(queryCustomerAssociate, checkOut);
            return res;
        }

        public async Task<LineItemResponse> LineItemData(string query, LineItemRequest lineItemRequest)
        {
            var res = await PostAsynGraphql<LineItemRequest, LineItemResponse>(query, lineItemRequest);
            return res;
        }

        public async Task<CartUpdateResponseModel> UpdateCart(string query, CartUpdateRequestModel request)
        {
            var res = await PostAsynGraphql<CartUpdateRequestModel, CartUpdateResponseModel>(query, request);
            return res;
        }

        public async Task<CartUpdateResponseModel> DeleteCart(string query, CartDeleteRequestModel request)
        {
            var res = await PostAsynGraphql<CartDeleteRequestModel, CartUpdateResponseModel>(query, request);
            return res;
        }

        public Task GetFeatureCollection(string queryid_id)
        {
            throw new NotImplementedException();
        }
    }
}