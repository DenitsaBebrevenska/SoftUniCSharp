using System;
using System.Collections.Generic;
using System.Linq;

namespace Masterchef
{
    internal class Program
    {
        static void Main()
        {
            Queue<int> ingredients = new Queue<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            Stack<int> freshness = new Stack<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            Dictionary<int, string> freshnessDishes = new Dictionary<int, string>()
            {
                {150, "Dipping sauce"},
                {250, "Green salad"},
                {300, "Chocolate cake"},
                {400, "Lobster"}
            };
            Dictionary<string, int> madeDishes = new Dictionary<string, int>()
            {
                { "Dipping sauce", 0},
                { "Green salad", 0},
                {"Chocolate cake", 0},
                {"Lobster", 0}
            };

            while (ingredients.Count > 0 && freshness.Count > 0)
            {
                int currentIngredient = ingredients.Dequeue();

                if (currentIngredient == 0)
                {
                    continue;
                }

                int currentFreshness = freshness.Pop();
                int result = currentIngredient * currentFreshness;
                string dishFound = freshnessDishes.FirstOrDefault(fd => fd.Key == result).Value;

                if (dishFound != null)
                {
                    madeDishes[dishFound]++;
                }
                else
                {
                    ingredients.Enqueue(currentIngredient + 5);
                }
            }

            bool success = madeDishes.All(d => d.Value >= 1);
            Console.WriteLine(success ? "Applause! The judges are fascinated by your dishes!"
                : "You were voted off. Better luck next year.");

            if (ingredients.Count > 0)
            {
                Console.WriteLine($"Ingredients left: {ingredients.Sum()}");
            }

            foreach (var dishKvp in madeDishes.Where(d => d.Value >= 1)
                         .OrderBy(d => d.Key))
            {
                Console.WriteLine($" # {dishKvp.Key} --> {dishKvp.Value}");
            }
        }
    }
}
