using INStock.Exceptions;
using INStock.Models.Contracts;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace INStock.Models
{
    public class Stock : IProductStock
    {
        private List<IProduct> products;

        public Stock()
        {
            products = new List<IProduct>();
        }
        public IEnumerator<IProduct> GetEnumerator()
        {
            foreach (var product in products)
            {
                yield return product;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public int Count => products.Count;

        public IProduct this[int index]
        {
            get
            {
                if (index < 0 || index >= products.Count)
                {
                    throw new InvalidIndexException();
                }
                return products[index];
            }

            set
            {
                if (index < 0 || index >= products.Count)
                {
                    throw new InvalidIndexException();
                }
                products[index] = value;
            }
        }

        public bool Contains(IProduct product)
           => products.Contains(product);

        public void Add(IProduct product)
        => products.Add(product);

        public bool Remove(IProduct product)
        {
            IProduct foundProduct = products.FirstOrDefault(p => p.Label == product.Label);

            if (foundProduct != null)
            {
                products.Remove(foundProduct);
                return true;
            }

            return false;
        }

        public IProduct Find(int index)
        => this[index];

        public IProduct FindByLabel(string label)
        {
            IProduct product = products.FirstOrDefault(p => p.Label == label);

            if (product is null)
            {
                throw new NonExistentProductInStockException();
            }

            return product;
        }

        public IProduct FindMostExpensiveProduct()
            => products.MaxBy(p => p.Price);

        public IEnumerable<IProduct> FindAllInRangeAll(double lo, double hi)
        => products.OrderByDescending(p => p.Price)
            .Where(p => p.Price >= (decimal)lo && p.Price <= (decimal)hi);

        public IEnumerable<IProduct> FindAllByPrice(double price)
            => products.Where(p => p.Price == (decimal)price);

        public IEnumerable<IProduct> FindAllByQuantity(int quantity)
            => products.Where(p => p.Quantity == quantity);
    }
}
