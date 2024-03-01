namespace Animals
{
    public class Dog : Animal
    {
        public override string Type => "Dog";
        public Dog(string name, int age, string gender) : base(name, age, gender)
        {
        }

        public override string ProduceSound() => "Woof!";
    }
}
