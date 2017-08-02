using System;
using System.Collections.Generic;

namespace ExceptionHandling.Common
{
    public class ErrorResult : IErrorResult
    {
        public int ResponseStatusCode { get; private set; }
        public IErrorResponseBody ResponseBody { get; private set; }

        public ErrorResult(int responseStatusCode, ErrorCodes errorCode)
		{
			ResponseStatusCode = responseStatusCode;
			ResponseBody = new ErrorResponseBody(errorCode);
		}

        public ErrorResult(int responseStatusCode, IEnumerable<ErrorCodes> errorCodes)
        {
            ResponseStatusCode = responseStatusCode;
            ResponseBody = new ErrorResponseBody(errorCodes);
        }
    }
}

