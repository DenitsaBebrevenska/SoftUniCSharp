using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CocktailParty
{
    public class Cocktail
    {
        private List<Ingredient> ingredients;

        public Cocktail(string name, int capacity, int maxAlcoholLevel)
        {
            Name = name;
            Capacity = capacity;
            MaxAlcoholLevel = maxAlcoholLevel;
            ingredients = new List<Ingredient>();
        }

        public string Name { get; private set; }
        public int Capacity { get; private set; }
        public int MaxAlcoholLevel { get; private set; }

        public int CurrentAlcoholLevel => ingredients.Sum(i => i.Alcohol);
        public void Add(Ingredient ingredient)
        {
            if (ingredients.All(i => i.Name != ingredient.Name)
                && ingredients.Count < Capacity
                && MaxAlcoholLevel >= ingredient.Alcohol + ingredients.Sum(i => i.Alcohol))
            {
                ingredients.Add(ingredient);
            }
        }

        public bool Remove(string name)
        {
            Ingredient ingredient = ingredients.FirstOrDefault(i => i.Name == name);

            if (ingredient != null)
            {
                ingredients.Remove(ingredient);
                return true;
            }

            return false;
        }

        public Ingredient FindIngredient(string name) => ingredients.FirstOrDefault(i => i.Name == name);

        public Ingredient GetMostAlcoholicIngredient() =>
            ingredients.OrderByDescending(i => i.Alcohol).FirstOrDefault();

        public string Report()
        {
            StringBuilder reportBuilder = new StringBuilder();
            reportBuilder.AppendLine($"Cocktail: {Name} - Current Alcohol Level: {CurrentAlcoholLevel}");
            ingredients.ForEach(i => reportBuilder.AppendLine(i.ToString()));

            return reportBuilder.ToString().TrimEnd();
        }
    }
}
