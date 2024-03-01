using System;
using System.Collections.Generic;
using System.Linq;

namespace Blacksmith
{
    internal class Program
    {
        static void Main()
        {
            Queue<int> steel = new Queue<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            Stack<int> carbon = new Stack<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            Dictionary<int, string> valueSwords = new Dictionary<int, string>()
            {
                {70, "Gladius"},
                {80, "Shamshir"},
                {90, "Katana"},
                {110, "Sabre"},
                {150, "Broadsword"}
            };

            Dictionary<string, int> forgedItems = new Dictionary<string, int>()
            {
                { "Gladius", 0 },
                { "Shamshir", 0 },
                { "Katana", 0 },
                { "Sabre", 0 },
                { "Broadsword", 0 }
            };

            while (steel.Count > 0 && carbon.Count > 0)
            {
                int currentSteel = steel.Dequeue();
                int currentCarbon = carbon.Pop();
                int result = currentSteel + currentCarbon;
                string swordFound = valueSwords.FirstOrDefault(vs => vs.Key == result).Value;

                if (swordFound != null)
                {
                    forgedItems[swordFound]++;
                }
                else
                {
                    carbon.Push(currentCarbon + 5);
                }
            }

            int swordsForged = forgedItems.Sum(fi => fi.Value);

            Console.WriteLine(swordsForged == 0 ? "You did not have enough resources to forge a sword."
                : $"You have forged {swordsForged} swords.");
            Console.WriteLine(steel.Count == 0 ? "Steel left: none"
                : $"Steel left: {string.Join(", ", steel)}");
            Console.WriteLine(carbon.Count == 0 ? "Carbon left: none"
                : $"Carbon left: {string.Join(", ", carbon)}");

            foreach (var kvp in forgedItems.Where(fi => fi.Value > 0)
                         .OrderBy(fi => fi.Key))
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }
        }
    }
}
