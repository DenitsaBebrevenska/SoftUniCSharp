using System.Text;

namespace ShoeStore
{
    public class ShoeStore
    {
        private List<Shoe> shoes;
        public string Name { get; private set; }
        public int StorageCapacity { get; private set; }
        public IReadOnlyCollection<Shoe> Shoes => shoes.AsReadOnly();

        public ShoeStore(string name, int storageCapacity)
        {
            Name = name;
            StorageCapacity = storageCapacity;
            shoes = new List<Shoe>();
        }

        public int Count => shoes.Count;

        public string AddShoe(Shoe shoe)
        {
            if (shoes.Count < StorageCapacity)
            {
                shoes.Add(shoe);
                return $"Successfully added {shoe.Type} {shoe.Material} pair of shoes to the store.";
            }

            return "No more space in the storage room.";
        }

        public int RemoveShoes(string material)
        {
            int shoeCount = shoes.Count(s => s.Material == material);
            shoes.RemoveAll(s => s.Material == material);
            return shoeCount;
        }

        public List<Shoe> GetShoesByType(string type) => shoes.Where(s => s.Type.ToLower().Equals(type.ToLower())).ToList();
        public Shoe GetShoeBySize(double size) => shoes.FirstOrDefault(s => s.Size.Equals(size));

        public string StockList(double size, string type)
        {
            if (!shoes.Any(s => s.Size.Equals(size) && s.Type == type))
            {
                return "No matches found!";
            }

            StringBuilder stockBuilder = new();
            stockBuilder.AppendLine($"Stock list for size {size} - {type} shoes:");

            foreach (var shoe in shoes.Where(s => s.Size.Equals(size) && s.Type == type))
            {
                stockBuilder.AppendLine(shoe.ToString());
            }

            return stockBuilder.ToString().TrimEnd();
        }
    }
}
