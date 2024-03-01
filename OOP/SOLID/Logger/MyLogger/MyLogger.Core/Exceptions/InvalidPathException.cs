namespace MyLogger.Core.Exceptions
{
    public class InvalidPathException : Exception
    {
        private const string DefaultMessage = "File path is invalid";

        public InvalidPathException(string message) : base(message)
        {

        }

        public InvalidPathException() : base(DefaultMessage)
        {

        }
    }
}
