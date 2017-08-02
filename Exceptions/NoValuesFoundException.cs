using System;
namespace ExceptionHandling.Exceptions
{
    public class NoValuesFoundException : MyCustomException
    {
        public NoValuesFoundException() : base("No values has been found")
        {

        }

        public NoValuesFoundException(string message) : base(message)
        {
        }
    }
}
