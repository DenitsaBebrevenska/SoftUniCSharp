using System;
using System.Collections.Generic;
using System.Linq;

namespace TheFightForGondor
{
    internal class Program
    {
        static void Main()
        {
            int waves = int.Parse(Console.ReadLine());
            Queue<int> plates = new Queue<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            Stack<int> orcs = new Stack<int>();

            for (int i = 1; i <= waves; i++)
            {
                List<int> currentOrcWave = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList();
                currentOrcWave.ForEach(o => orcs.Push(o));

                if (i % 3 == 0)
                {
                    int newPlate = int.Parse(Console.ReadLine());
                    plates.Enqueue(newPlate);
                }

                while (orcs.Count > 0 && plates.Count > 0)
                {
                    int currentOrc = orcs.Peek();
                    int currentPlate = plates.Peek();

                    if (currentPlate < currentOrc)
                    {
                        plates.Dequeue();
                        orcs.Push(orcs.Pop() - currentPlate);

                    }
                    else if (currentPlate > currentOrc)
                    {
                        List<int> tempPlates = plates.Skip(1).ToList();
                        plates.Clear();
                        plates.Enqueue(currentPlate - orcs.Pop());
                        tempPlates.ForEach(p => plates.Enqueue(p));
                    }
                    else
                    {
                        orcs.Pop();
                        plates.Dequeue();
                    }
                }

                if (plates.Count == 0)
                {
                    break;
                }
            }

            if (plates.Count == 0)
            {
                Console.WriteLine("The orcs successfully destroyed the Gondor's defense.");
                Console.WriteLine($"Orcs left: {string.Join(", ", orcs)}");
            }
            else
            {
                Console.WriteLine("The people successfully repulsed the orc's attack.");
                Console.WriteLine($"Plates left: {string.Join(", ", plates)}");
            }
        }
    }
}
