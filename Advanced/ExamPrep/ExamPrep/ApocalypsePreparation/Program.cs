namespace ApocalypsePreparation
{
    internal class Program
    {
        static void Main()
        {
            Queue<int> textiles = new(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            Stack<int> medicaments = new(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            Dictionary<string, int> createdItems = new()
            {
                {"Patch",0},
                {"Bandage", 0},
                {"MedKit", 0}
            };

            while (textiles.Count > 0 && medicaments.Count > 0)
            {
                int currentTextile = textiles.Dequeue();
                int currentMedicament = medicaments.Pop();
                int sum = currentTextile + currentMedicament;

                switch (sum)
                {
                    case 30:
                        createdItems["Patch"]++;
                        break;
                    case 40:
                        createdItems["Bandage"]++;
                        break;
                    case 100:
                        createdItems["MedKit"]++;
                        break;
                    case > 100:
                        createdItems["MedKit"]++;
                        sum -= 100;
                        medicaments.Push(medicaments.Pop() + sum);
                        break;
                    default:
                        medicaments.Push(currentMedicament + 10);
                        break;
                }
            }

            if (medicaments.Count == 0 && textiles.Count == 0)
            {
                Console.WriteLine("Textiles and medicaments are both empty.");
            }
            else if (medicaments.Count == 0 && textiles.Count > 0)
            {
                Console.WriteLine("Medicaments are empty.");
            }
            else
            {
                Console.WriteLine("Textiles are empty.");
            }

            foreach (var kvp in createdItems.OrderByDescending(i => i.Value)
                         .ThenBy(i => i.Key).Where(i => i.Value > 0))
            {
                Console.WriteLine($"{kvp.Key} - {kvp.Value}");
            }

            if (medicaments.Count > 0)
            {
                Console.WriteLine($"Medicaments left: {string.Join(", ", medicaments)}");
            }

            if (textiles.Count > 0)
            {
                Console.WriteLine($"Textiles left: {string.Join(", ", textiles)}");
            }
        }
    }
}
