namespace MyLogger.Core.Exceptions
{
    public class EmptyMessageTextException : Exception
    {
        private const string DefaultMessage = "The text of the message cannot be null or whitespace";
        public EmptyMessageTextException(string message) : base(message)
        {

        }
        public EmptyMessageTextException() : base(DefaultMessage)
        {

        }
    }
}
