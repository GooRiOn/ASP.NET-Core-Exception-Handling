using System;
namespace ExceptionHandling.Exceptions
{
    public abstract class MyCustomException : Exception
    {
        public MyCustomException(string message) : base(message)
        {
        }
    }
}
