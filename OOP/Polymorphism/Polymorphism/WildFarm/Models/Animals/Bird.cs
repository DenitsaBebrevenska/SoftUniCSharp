namespace WildFarm.Models.Animals
{
    public abstract class Bird : Animal
    {
        public double WingSize { get; private set; }
        protected Bird(string name, double weight, double wingSize) : base(name, weight)
        {
            WingSize = wingSize;
        }

        public override string ToString() => base.ToString() + $"{WingSize}, {Weight}, {FoodEaten}]";
    }
}
