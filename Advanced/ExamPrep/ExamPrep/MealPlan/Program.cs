using System;
using System.Collections.Generic;
using System.Linq;

namespace MealPlan
{
    internal class Program
    {
        static void Main()
        {
            Queue<string> meals = new Queue<string>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries));
            Stack<int> calories = new Stack<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            Dictionary<string, int> caloriesPerMeals = new Dictionary<string, int>()
            {
                {"salad", 350},
                {"soup", 490},
                {"pasta", 680},
                {"steak", 790}
            };
            int mealsConsumed = 0;

            while (meals.Count > 0 && calories.Count > 0)
            {
                string currentMeal = meals.Dequeue();
                int currentCalories = calories.Pop();

                if (currentCalories >= caloriesPerMeals[currentMeal])
                {
                    currentCalories -= caloriesPerMeals[currentMeal];

                    if (currentCalories > 0)
                    {
                        calories.Push(currentCalories);
                    }

                    mealsConsumed++;
                }
                else
                {
                    if (calories.Count > 0)
                    {
                        int difference = caloriesPerMeals[currentMeal] - currentCalories;
                        calories.Push(calories.Pop() - difference);
                    }

                    mealsConsumed++;
                }
            }

            if (meals.Count == 0)
            {
                Console.WriteLine($"John had {mealsConsumed} meals.");
                Console.WriteLine($"For the next few days, he can eat {string.Join(", ", calories)} calories.");
            }
            else
            {
                Console.WriteLine($"John ate enough, he had {mealsConsumed} meals.");
                Console.WriteLine($"Meals left: {string.Join(", ", meals)}.");
            }
        }
    }
}
