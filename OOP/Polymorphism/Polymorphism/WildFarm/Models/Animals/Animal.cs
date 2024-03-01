using WildFarm.Models.Foods;
namespace WildFarm.Models.Animals
{
    public abstract class Animal
    {
        protected abstract double WeightGain { get; }
        protected abstract string[] Menu { get; }
        public string Name { get; private set; }
        public double Weight { get; private set; }
        public int FoodEaten { get; private set; }

        protected Animal(string name, double weight)
        {
            Name = name;
            Weight = weight;
        }

        public abstract string AskForFood();
        public void EatFood(Food food)
        {
            if (Menu.Any(f => f == food.GetType().Name))
            {
                FoodEaten += food.Quantity;
                Weight += food.Quantity * WeightGain;
            }
            else
            {
                throw new ArgumentException($"{GetType().Name} does not eat {food.GetType().Name}!");
            }
        }
        public override string ToString() => $"{GetType().Name} [{Name}, ";

    }
}
