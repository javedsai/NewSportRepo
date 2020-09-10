using System;
using System.Collections.Generic;
using System.Text;

namespace SportDirect.Data.Enum
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
