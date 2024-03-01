namespace WildFarm.Models.Animals
{
    public class Hen : Bird
    {
        public Hen(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }

        protected override double WeightGain => 0.35;
        protected override string[] Menu => new string[] { "Vegetable", "Meat", "Seeds", "Fruit" };
        public override string AskForFood() => "Cluck";
    }
}
