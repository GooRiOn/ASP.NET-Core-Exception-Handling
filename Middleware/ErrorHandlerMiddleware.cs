using System;
using System.Threading.Tasks;
using ExceptionHandling.Common;
using ExceptionHandling.Exceptions;
using ExceptionHandling.Executors;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Reflection;

namespace ExceptionHandling.Middleware
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IExceptionHandlerExecutor _exceptionHandlerExecutor;

        public ErrorHandlerMiddleware(RequestDelegate next, IExceptionHandlerExecutor exceptionHandlerExecutor)
        {
            _next = next;
            _exceptionHandlerExecutor = exceptionHandlerExecutor;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                var myCustomExcecption = ex as MyCustomException;

                if (myCustomExcecption != null)
                {
                    var errorResult = GetErrorResult(myCustomExcecption);
                    context.Response.StatusCode = errorResult.ResponseStatusCode;
                    await context.Response.WriteAsync(JsonConvert.SerializeObject(errorResult.ResponseBody));
                }
                else
                {
                    throw ex;
                }
            }
        }

        private IErrorResult GetErrorResult(MyCustomException exception)
        {
            var exceptionType = exception.GetType();
            var executorType = _exceptionHandlerExecutor.GetType();

            return (IErrorResult) executorType
                .GetMethod(nameof(IExceptionHandlerExecutor.Execute))
                .MakeGenericMethod(exceptionType)
                .Invoke(_exceptionHandlerExecutor, new []{ exception });
        }

    }
}
