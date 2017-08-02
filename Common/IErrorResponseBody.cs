using System;
using System.Collections.Generic;

namespace ExceptionHandling.Common
{
    public interface IErrorResponseBody
    {
        IEnumerable<ErrorCodes> ErrorCodes { get; }
    }
}
