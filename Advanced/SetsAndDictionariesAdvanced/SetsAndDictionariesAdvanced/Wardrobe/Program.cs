namespace Wardrobe
{
    internal class Program
    {
        static void Main()
        {
            Dictionary<string, Dictionary<string, int>> wardrobe =
                new Dictionary<string, Dictionary<string, int>>();
            byte entryCount = byte.Parse(Console.ReadLine());

            for (int i = 0; i < entryCount; i++)
            {
                string[] entryDetails = Console.ReadLine().Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                string color = entryDetails[0];

                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe.Add(color, new Dictionary<string, int>());
                }

                string[] clothes = entryDetails[1].Split(',');

                for (int j = 0; j < clothes.Length; j++)
                {
                    if (!wardrobe[color].ContainsKey(clothes[j]))
                    {
                        wardrobe[color].Add(clothes[j], 1);
                        continue;
                    }

                    wardrobe[color][clothes[j]]++;
                }
            }

            PrintWardrobe(wardrobe);
        }

        static void PrintWardrobe(Dictionary<string, Dictionary<string, int>> wardrobe)
        {
            string[] itemDetails = Console.ReadLine().Split();
            string itemColor = itemDetails[0];
            string pieceOfClothing = itemDetails[1];

            foreach (var kvp in wardrobe)
            {
                Console.WriteLine($"{kvp.Key} clothes:");

                foreach (var kvp2 in kvp.Value)
                {
                    if (kvp.Key == itemColor && kvp2.Key == pieceOfClothing)
                    {
                        Console.WriteLine($"* {kvp2.Key} - {kvp2.Value} (found!)");
                        continue;
                    }

                    Console.WriteLine($"* {kvp2.Key} - {kvp2.Value}");
                }
            }
        }
    }
}
