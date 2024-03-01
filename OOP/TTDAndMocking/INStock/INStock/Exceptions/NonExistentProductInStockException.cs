using System;

namespace INStock.Exceptions
{
    public class NonExistentProductInStockException : Exception
    {
        private const string DefaultMessage = "There is no such product in stock.";
        public NonExistentProductInStockException() : base(DefaultMessage)
        {

        }

        public NonExistentProductInStockException(string message) : base(message)
        {

        }
    }
}
