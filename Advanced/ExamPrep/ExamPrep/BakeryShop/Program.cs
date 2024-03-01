using System;
using System.Collections.Generic;
using System.Linq;

namespace BakeryShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<double> water = new Queue<double>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse));
            Stack<double> flour = new Stack<double>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse));
            Dictionary<string, double> productWaterPercentages = new Dictionary<string, double>()
            {
                {"Croissant", 50},
                {"Muffin", 40},
                {"Baguette", 30},
                {"Bagel", 20}
            };

            Dictionary<string, int> bakedGoods = new Dictionary<string, int>()
            {
                {"Croissant", 0},
                {"Muffin", 0},
                {"Baguette", 0},
                {"Bagel", 0}
            };

            while (water.Count > 0 && flour.Count > 0)
            {
                double currentWater = water.Dequeue();
                double currentFlour = flour.Pop();
                double waterPercentage = (currentWater * 100) / (currentFlour + currentWater);


                string product = productWaterPercentages.FirstOrDefault(p => p.Value.Equals(waterPercentage)).Key;

                if (product != null)
                {
                    bakedGoods[product]++;
                }
                else
                {
                    bakedGoods["Croissant"]++;
                    flour.Push(currentFlour - currentWater);
                }
            }

            foreach (var kvp in bakedGoods.Where(bg => bg.Value > 0)
                         .OrderByDescending(bg => bg.Value)
                         .ThenBy(bg => bg.Key))
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }

            Console.WriteLine(water.Count > 0 ? $"Water left: {string.Join(", ", water)}" : "Water left: None");
            Console.WriteLine(flour.Count > 0 ? $"Flour left: {string.Join(", ", flour)}" : "Flour left: None");
        }
    }
}
