using System;
namespace SportDirect.Core.Models
{
    public class Urls
    {
#if DEBUG
        public const string BASE_URL = "http://54.210.238.184:8000/api/v1";
#else
        public const string BASE_URL = "http://54.210.238.184:8000/api/v1"; // TODO: change this to a production url when ready
#endif
        public const string LOGIN = BASE_URL + "/users/login";
        public const string SIGNUP = BASE_URL + "/users/SignUp";
        public const string VERIFY_ACCOUNT = BASE_URL + "/users/verifyAccount";
        public const string CREATE_NEW_PASSWORD = BASE_URL + "/users/createPassword";
        public const string Get_University = BASE_URL + "/users/getUniversity";
        public const string GET_COURSE = BASE_URL + "/users/getCourse";
        public const string GET_NOTES = BASE_URL + "/users/getNotes";
        public const string GET_ALl_SEARCH_NOTES = BASE_URL + "/users/searchNotes";
        public const string UPDATE_PROFILE = BASE_URL + "/users/updateProfile";
        public const string GET_ACCOUNT_DETAILS = BASE_URL + "/users/getAccountDetail";
        public const string UPLOAD_NOTES = BASE_URL + "/users/uploadNotes";
        public const string GET_CART = BASE_URL + "/users/cartList";
        public const string DELETE_CART = BASE_URL + "/users/deleteCart";
        public const string ADDITEM_CART = BASE_URL + "/users/addToCart";
    }
}
