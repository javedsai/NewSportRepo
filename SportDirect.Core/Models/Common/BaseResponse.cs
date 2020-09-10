using System;
namespace SportDirect.Core.Models.Common
{
    public class BaseResponse
    {
        public string message { get; set; }
        public int status { get; set; }
    }

    public class ApiData<T> : BaseResponse
    {
        public T data { get; set; }
    }
}
