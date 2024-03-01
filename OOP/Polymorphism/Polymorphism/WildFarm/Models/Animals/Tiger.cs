namespace WildFarm.Models.Animals
{
    public class Tiger : Feline
    {
        public Tiger(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
        {
        }

        protected override double WeightGain => 1;
        protected override string[] Menu => new string[] { "Meat" };
        public override string AskForFood() => "ROAR!!!";

    }
}
