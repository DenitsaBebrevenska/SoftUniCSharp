using INStock.Models.Contracts;

namespace INStock.Models
{
    public abstract class Product : IProduct
    {
        protected Product(string label, decimal price, int quantity)
        {
            Label = label;
            Price = price;
            Quantity = quantity;
        }

        public int CompareTo(IProduct other)
         => Label.CompareTo(other.Label);

        public string Label { get; private set; }
        public decimal Price { get; private set; }
        public int Quantity { get; private set; }
    }
}
