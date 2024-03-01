namespace Animals
{
    public class Kitten : Cat
    {
        public override string Type => "Kitten";
        public Kitten(string name, int age) : base(name, age, "Female")
        {
        }

        public override string ProduceSound() => "Meow";
    }
}
