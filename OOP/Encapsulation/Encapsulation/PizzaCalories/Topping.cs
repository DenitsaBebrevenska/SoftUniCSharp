namespace PizzaCalories
{
    public class Topping
    {
        private const double BasalCaloriesPerGram = 2;
        private const double MeatModifier = 1.2;
        private const double VeggiesModifier = 0.8;
        private const double CheeseModifier = 1.1;
        private const double SauceModifier = 0.9;

        private string type;
        private int weight;

        public string Type
        {
            get => type;
            private set
            {
                if (value.ToLower() != "meat" && value.ToLower() != "veggies" && value.ToLower() != "cheese" && value.ToLower() != "sauce")
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }
                type = value;
            }
        }

        public int Weight
        {
            get => weight;
            private set
            {
                if (value < 1 || value > 50)
                {
                    throw new ArgumentException($"{Type} weight should be in the range [1..50].");
                }
                weight = value;
            }
        }

        public double TotalCalories => CalculateCalories();


        public Topping(string type, int weight)
        {
            Type = type;
            Weight = weight;
        }

        private double CalculateCalories()
        {
            double calories = weight * BasalCaloriesPerGram;

            if (type.ToLower() == "meat")
            {
                calories *= MeatModifier;
            }
            else if (type.ToLower() == "veggies")
            {
                calories *= VeggiesModifier;
            }
            else if (type.ToLower() == "cheese")
            {
                calories *= CheeseModifier;
            }
            else
            {
                calories *= SauceModifier;
            }

            return calories;
        }
    }
}
