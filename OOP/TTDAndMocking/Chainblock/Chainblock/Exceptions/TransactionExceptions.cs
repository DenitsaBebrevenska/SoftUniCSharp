namespace Chainblock.Exceptions
{
    public class TransactionExceptions
    {
        public const string IdMustBePositive = "Transaction Id must be a positive number";
        public const string SenderMustNotBeNullOrWhiteSpace = "Transaction sender cannot be null or whitespace";
        public const string ReceiverMustNotBeNullOrWhiteSpace = "Transaction receiver cannot be null or whitespace";
        public const string AmountMustBePositive = "Transaction amount must be a positive number";
    }
}
