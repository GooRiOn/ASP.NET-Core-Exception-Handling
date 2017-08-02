using System;
using ExceptionHandling.Common;
using ExceptionHandling.Exceptions;

namespace ExceptionHandling.ExceptionHandlers
{
    public interface IExceptionHandler<TException> where TException : MyCustomException
    {
        IErrorResult Handle(TException exception);
    }
}
