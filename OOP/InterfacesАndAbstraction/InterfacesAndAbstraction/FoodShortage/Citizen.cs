namespace FoodShortage
{
    public class Citizen : IBuyer
    {
        private const int foodIncrement = 10;
        public string Name { get; }
        public int Age { get; }
        public int Food { get; private set; }

        public string Id { get; }
        public string Birthdate { get; }

        public Citizen(string name, int age, string id, string birthdate)
        {
            Name = name;
            Age = age;
            Id = id;
            Birthdate = birthdate;
        }
        public void BuyFood() => Food += foodIncrement;
    }
}
