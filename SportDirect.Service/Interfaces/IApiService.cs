using SportDirect.Data.Models.Request;
using SportDirect.Data.Models.Response;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
namespace SportDirect.Service.Interfaces
{
    public interface IApiService
    {
        //Task<DashboardResponseModel> GetDashboardAync();
        //Task<SaveResumeResponseModel> SaveResumeAync(SaveResumeRequestModel saveResumeRequestModel)
        Task<DashboardResponseModel> GetDashboardAync();
        Task<SaveResumeResponseModel> SaveResumeAync(SaveResumeRequestModel saveResumeRequestModel);
        //  Task<LoginResponseModal> Login(string Email, string Password);
        Task<HttpResponseMessage> CreateCustomerPostAsyn(CreateCustomerRequest obj_custrequest);
        Task<GetProductResponse> GetProduct(string query);
        Task<CustLoginResponse> CustomerLogin(string query, LoginRequest obj_create);
        Task<GraphqlResponse> CreateCusmerbyGraphql(string query, CreateCusomerRequest obj_create);
        Task<CustomerAccessTokenResponse> RenewCustomerToken(string query, CustomerAccRequest obj_create);
        Task<CustomerDetailResponse> GetCustomer(string query);
        Task<CreateCusResponse> CreateAddress(string query, CreateAddressReequest createAddressReequest);
        Task<CustomerDetailResponse> GetAddress(string query);
        Task<DeleteCustResponse> DeleteAddress(string query, DeleteCusRequest deleteCusRequest);
        Task<UpdateAddressResponseModel> UpdateAddres(string query, UpdateAddressRequest createAddressReequest);
        Task<CustomerUpdateResponse> CustomerUpdate(string query, CustomerUpdateRequest createAddressReequest);
        Task<CreateCusResponse> GetCartItem(string query, CreateAddressReequest createAddressReequest);


        Task<CollectionResponse> GetCollection(string query);
        Task<GetProductResponse> SortListOfProduct(string query);
        Task<GetCollectionProductResponseModel> GetCollectionListData(string query);
        Task<CheckoutResponseModel> CheckOutData(string queryId, CheckoutRequestModel request);
        Task<CheckOutCustomerResponseModel> CheckOutAssociate(string queryCustomerAssociate, CheckOutCustomerRequestModel checkOut);
        Task<LineItemResponse> LineItemData(string query, LineItemRequest lineItemRequest);
        Task<CartUpdateResponseModel> UpdateCart(string query, CartUpdateRequestModel request);
        Task<CartUpdateResponseModel> DeleteCart(string query, CartDeleteRequestModel request);
        Task GetFeatureCollection(string queryid_id);
        Task<ForgetModelResponse> ForgetPassword(string query, ForgetModelRequest obj_create);
        Task<CustomerDetailResponse> CustomerInfo(string queryid_id);
    }
}

