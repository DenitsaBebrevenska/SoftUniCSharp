namespace MyLogger.Core.Exceptions
{
    public class DataAndTimeEmptyException : Exception
    {
        private const string DefaultMessage = "Data and time of message cannot be null or whitespace";
        public DataAndTimeEmptyException(string message) : base(message)
        {

        }
        public DataAndTimeEmptyException() : base(DefaultMessage)
        {

        }
    }
}
