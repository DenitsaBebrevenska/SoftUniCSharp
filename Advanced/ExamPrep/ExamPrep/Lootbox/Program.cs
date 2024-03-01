using System;
using System.Collections.Generic;
using System.Linq;

namespace Lootbox
{
    internal class Program
    {
        static void Main()
        {
            Queue<int> firstBox = new Queue<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            Stack<int> secondBox = new Stack<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            int sumLoot = 0;

            while (firstBox.Count > 0 && secondBox.Count > 0)
            {
                int firstLoot = firstBox.Peek();
                int secondLoot = secondBox.Peek();
                int result = firstLoot + secondLoot;

                if (result % 2 == 0)
                {
                    sumLoot += result;
                    firstBox.Dequeue();
                    secondBox.Pop();
                }
                else
                {
                    firstBox.Enqueue(secondBox.Pop());
                }
            }

            if (firstBox.Count == 0)
            {
                Console.WriteLine("First lootbox is empty");
            }

            if (secondBox.Count == 0)
            {
                Console.WriteLine("Second lootbox is empty");
            }

            Console.WriteLine(sumLoot >= 100 ? $"Your loot was epic! Value: {sumLoot}"
                : $"Your loot was poor... Value: {sumLoot}");
        }
    }
}
