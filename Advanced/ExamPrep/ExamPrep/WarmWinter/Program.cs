using System;
using System.Collections.Generic;
using System.Linq;

namespace WarmWinter
{
    internal class Program
    {
        static void Main()
        {
            Stack<int> hats = new Stack<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            Queue<int> scarves = new Queue<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            List<int> createdSets = new List<int>();

            while (hats.Count > 0 && scarves.Count > 0)
            {
                int currentHat = hats.Peek();
                int currentScarf = scarves.Peek();

                if (currentHat > currentScarf)
                {
                    createdSets.Add(hats.Pop() + scarves.Dequeue());
                }
                else if (currentScarf > currentHat)
                {
                    hats.Pop();
                }
                else //equality
                {
                    scarves.Dequeue();
                    hats.Push(hats.Pop() + 1);
                }
            }

            Console.WriteLine($"The most expensive set is: {createdSets.OrderByDescending(x => x).First()}");
            Console.WriteLine(string.Join(' ', createdSets));
        }
    }
}
