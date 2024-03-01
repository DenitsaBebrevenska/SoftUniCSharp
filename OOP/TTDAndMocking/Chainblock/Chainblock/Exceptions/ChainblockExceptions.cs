namespace Chainblock.Exceptions
{
    public class ChainblockExceptions
    {
        public const string TransactionCannotBeAdded = "Transaction cannot be added. Another transaction with the same id {0} already exists";
        public const string TransactionDoesNotExist = "Transaction with that id {0} does not exist.";
        public const string NoTransactionsWithSuchStatusFound = "Cannot find transactions with status {0}";
        public const string NoTransactionsWithSuchSenderFound = "Cannot find transaction with sender {0}";
        public const string NoTransactionsWithSuchReceiverFound = "Cannot find transaction with receiver {0}";

        public const string NoTransactionsWithSuchSenderAndMinAmount =
            "Cannot find transaction with sender {0} and/or minimum amount of {1}";

        public const string NoTransactionsWithSuchReceiverAndAmountRangeFound =
            "Cannot find transaction with sender {0} and/or minimum amount of {1} and maximum amount of {2}.";

    }
}
