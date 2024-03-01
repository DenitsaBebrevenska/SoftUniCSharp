namespace Animals
{
    public class Cat : Animal
    {
        public override string Type => "Cat";
        public Cat(string name, int age, string gender) : base(name, age, gender)
        {
        }

        public override string ProduceSound() => "Meow meow";


    }
}
