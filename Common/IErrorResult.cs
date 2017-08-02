using System;
namespace ExceptionHandling.Common
{
    public interface IErrorResult
    {
        int ResponseStatusCode { get; }
        IErrorResponseBody ResponseBody { get; }
    }
}
