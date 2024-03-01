namespace MyLogger.Core.Exceptions
{
    public class InvalidDateTimeFormatException : Exception
    {
        private const string DefaultMessage = "Invalid Date and Time format";
        public InvalidDateTimeFormatException(string message) : base(message)
        {

        }

        public InvalidDateTimeFormatException() : base(DefaultMessage)
        {

        }
    }
}
