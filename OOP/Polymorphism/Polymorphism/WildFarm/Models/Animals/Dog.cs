namespace WildFarm.Models.Animals
{
    public class Dog : Mammal
    {
        public Dog(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
        }

        protected override double WeightGain => 0.4;
        protected override string[] Menu => new string[] { "Meat" };
        public override string AskForFood() => "Woof!";

    }
}
