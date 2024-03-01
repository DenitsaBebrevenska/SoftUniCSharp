namespace WildFarm.Models.Animals
{
    public class Cat : Feline
    {
        public Cat(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
        {
        }

        protected override double WeightGain => 0.3;
        protected override string[] Menu => new string[] { "Vegetable", "Meat" };
        public override string AskForFood() => "Meow";

    }
}
