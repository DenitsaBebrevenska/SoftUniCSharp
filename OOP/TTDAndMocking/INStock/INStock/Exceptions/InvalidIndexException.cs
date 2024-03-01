using System;

namespace INStock.Exceptions
{
    public class InvalidIndexException : Exception
    {
        private const string DefaultMessage = "Invalid index";
        public InvalidIndexException() : base(DefaultMessage)
        {

        }

        public InvalidIndexException(string message) : base(message)
        {

        }
    }
}
