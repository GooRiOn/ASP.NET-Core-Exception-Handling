using System;
using ExceptionHandling.Common;
using ExceptionHandling.Exceptions;
using Microsoft.AspNetCore.Http;

namespace ExceptionHandling.ExceptionHandlers
{
    public class NoValuesFoundExceptionHandler : IExceptionHandler<NoValuesFoundException>
    {

        public IErrorResult Handle(NoValuesFoundException exception)
        {
            //handle error in your system (Event, Logging etc.)
            Console.WriteLine("I handled custom exception!");
            return new ErrorResult(StatusCodes.Status404NotFound, ErrorCodes.ValuesNotFound);
        }
    }
}
