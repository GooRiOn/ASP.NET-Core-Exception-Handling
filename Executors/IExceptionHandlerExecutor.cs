using System;
using ExceptionHandling.Common;
using ExceptionHandling.Exceptions;

namespace ExceptionHandling.Executors
{
    public interface IExceptionHandlerExecutor
    {
        IErrorResult Execute<TException>(TException exception) where TException : MyCustomException;
    }
}
