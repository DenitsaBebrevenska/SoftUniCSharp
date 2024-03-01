namespace FoodShortage
{
    public class Rebel : IBuyer
    {
        private const int foodIncrement = 5;
        public string Name { get; }
        public int Age { get; }
        public int Food { get; private set; }

        public string Group { get; }

        public Rebel(string name, int age, string group)
        {
            Name = name;
            Age = age;
            Group = group;
        }
        public void BuyFood() => Food += foodIncrement;
    }
}
