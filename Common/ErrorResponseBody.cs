using System;
using System.Collections.Generic;

namespace ExceptionHandling.Common
{
    public class ErrorResponseBody : IErrorResponseBody
    {
        public IEnumerable<ErrorCodes> ErrorCodes { get; private set; }

        public ErrorResponseBody(ErrorCodes errorCode)
		{
            ErrorCodes = new List<ErrorCodes> { errorCode };
		}

        public ErrorResponseBody(IEnumerable<ErrorCodes> errorCodes)
        {
            ErrorCodes = errorCodes;
        }

    }
}
