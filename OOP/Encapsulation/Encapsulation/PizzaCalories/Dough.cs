namespace PizzaCalories
{
    public class Dough
    {
        private const double BasalCaloriesPerGram = 2;
        private const double WhiteFlourModifier = 1.5;
        private const double WholeGrainModifier = 1;
        private const double CrispyModifier = 0.9;
        private const double ChewyModifier = 1.1;
        private const double HomemadeModifier = 1;
        private string type;
        private string bakingTechnique;
        private int weight;
        public string Type
        {
            get => type;
            private set
            {
                if (value.ToLower() != "white" && value.ToLower() != "wholegrain")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                type = value.ToLower();
            }
        }

        public string BakingTechnique
        {
            get => bakingTechnique;
            private set
            {
                if (value.ToLower() != "crispy" && value.ToLower() != "chewy" && value.ToLower() != "homemade")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                bakingTechnique = value.ToLower();
            }
        }

        public int Weight
        {
            get => weight;
            private set
            {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }
                weight = value;
            }
        }

        public double TotalCalories => CalculateCalories();
        public Dough(string type, string bakingTechnique, int weight)
        {
            Type = type;
            BakingTechnique = bakingTechnique;
            Weight = weight;
        }

        private double CalculateCalories()
        {
            double calories = weight * BasalCaloriesPerGram;

            if (type == "white")
            {
                calories *= WhiteFlourModifier;
            }
            else
            {
                calories *= WholeGrainModifier;
            }

            if (bakingTechnique == "crispy")
            {
                calories *= CrispyModifier;
            }
            else if (bakingTechnique == "chewy")
            {
                calories *= ChewyModifier;
            }
            else
            {
                calories *= HomemadeModifier;
            }

            return calories;
        }
    }
}
