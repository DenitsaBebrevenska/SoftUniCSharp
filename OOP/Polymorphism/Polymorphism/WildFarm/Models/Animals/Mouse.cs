namespace WildFarm.Models.Animals
{
    public class Mouse : Mammal
    {
        public Mouse(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
        }

        protected override double WeightGain => 0.1;
        protected override string[] Menu => new string[] { "Vegetable", "Fruit" };
        public override string AskForFood() => "Squeak";
    }
}
