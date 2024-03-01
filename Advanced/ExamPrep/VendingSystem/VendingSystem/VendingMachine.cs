namespace VendingSystem
{
    public class VendingMachine
    {
        public int ButtonCapacity { get; set; }
        public List<Drink> Drinks { get; set; }
        public int GetCount => Drinks.Count;

        public VendingMachine(int buttonCapacity)
        {
            ButtonCapacity = buttonCapacity;
            Drinks = new List<Drink>();
        }

        public void AddDrink(Drink drink)
        {
            if (Drinks.Count < ButtonCapacity)
            {
                Drinks.Add(drink);
            }
        }

        public bool RemoveDrink(string name)
        {
            Drink drink = Drinks.FirstOrDefault(x => x.Name == name);

            if (drink != null)
            {
                Drinks.Remove(drink);
                return true;
            }

            return false;
        }

        public Drink GetLongest() => Drinks.OrderByDescending(d => d.Volume).First();

        public Drink GetCheapest() => Drinks.OrderBy(d => d.Price).First();

        public string BuyDrink(string name) => Drinks.FirstOrDefault(d => d.Name == name).ToString();

        public string Report() => $"Drinks available:{Environment.NewLine}{string.Join(Environment.NewLine, Drinks)}";
    }
}
