namespace WildFarm.Models.Animals
{

    public class Owl : Bird
    {
        public Owl(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }

        protected override double WeightGain => 0.25;
        protected override string[] Menu => new string[] { "Meat" };
        public override string AskForFood() => "Hoot Hoot";
    }
}
