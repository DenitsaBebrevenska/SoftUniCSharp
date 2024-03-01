namespace GroceriesManagement
{
    public class GroceriesStore
    {
        public int Capacity { get; set; }
        public double Turnover { get; set; }
        public List<Product> Stall { get; set; }

        public GroceriesStore(int capacity)
        {
            Capacity = capacity;
            Turnover = 0;
            Stall = new List<Product>(capacity);
        }

        public void AddProduct(Product product)
        {
            if (Stall.Count < Capacity)
            {
                if (!Stall.Any(p => p.Name == product.Name))
                {
                    Stall.Add(product);
                }
            }
        }

        public bool RemoveProduct(string name)
        {
            Product product = Stall.FirstOrDefault(p => p.Name == name);

            if (product != null)
            {
                Stall.Remove(product);
                return true;
            }

            return false;
        }

        public string SellProduct(string name, double quantity)
        {
            Product product = Stall.FirstOrDefault(p => p.Name == name);

            if (product == null)
            {
                return "Product not found";
            }

            double totalPrice = quantity * product.Price;
            Turnover += totalPrice;
            return $"{product.Name} - {totalPrice:F2}$";
        }

        public string GetMostExpensive()
        {
            Product product = Stall.OrderByDescending(p => p.Price).FirstOrDefault();
            return product.ToString();
        }

        public string CashReport()
        {
            return $"Total Turnover: {Turnover:F2}$";
        }

        public string PriceList()
        {
            return $"Groceries Price List:" +
                   Environment.NewLine +
                   $"{string.Join(Environment.NewLine, Stall)}";
        }
    }
}
