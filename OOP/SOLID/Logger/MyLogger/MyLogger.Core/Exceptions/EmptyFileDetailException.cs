namespace MyLogger.Core.Exceptions
{
    public class EmptyFileDetailException : Exception
    {
        private const string DefaultMessage = "The file name or extension cannot be null or whitespace";

        public EmptyFileDetailException(string message) : base(message)
        {

        }

        public EmptyFileDetailException() : base(DefaultMessage)
        {

        }
    }
}
