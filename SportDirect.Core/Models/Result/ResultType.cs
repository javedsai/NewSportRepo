using System;
namespace SportDirect.Core.Models.Result
{
    /// <summary>
    /// A type of result from a response.
    /// </summary>
    public enum ResultType
    {
        Ok,
        Invalid,
        Unauthorized,
        InternalError,
        PartialOk,
        NotFound,
        Unexpected
    }
}
