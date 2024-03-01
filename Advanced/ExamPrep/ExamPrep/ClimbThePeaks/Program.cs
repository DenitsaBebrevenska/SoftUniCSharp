namespace ClimbThePeaks
{
    internal class Program
    {
        static void Main()
        {
            Stack<int> food = new(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            Queue<int> stamina = new(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            Dictionary<string, int> peaks = new()
            {
                {"Vihren",80},
                {"Kutelo",90},
                {"Banski Suhodol",100},
                {"Polezhan", 60},
                {"Kamenitza",70}
            };
            List<string> conqueredPeaks = new();

            while (food.Count > 0 && stamina.Count > 0)
            {
                var currentPeek = peaks.First();
                int sumTokens = food.Pop() + stamina.Dequeue();

                if (sumTokens < currentPeek.Value)
                {
                    continue;
                }

                conqueredPeaks.Add(currentPeek.Key);
                peaks.Remove(currentPeek.Key);

                if (peaks.Count == 0)
                {
                    Console.WriteLine("Alex did it! He climbed all top five Pirin peaks in one week -> @FIVEinAWEEK");
                    break;
                }
            }

            if (peaks.Count > 0)
            {
                Console.WriteLine("Alex failed! He has to organize his journey better next time -> @PIRINWINS");
            }

            if (conqueredPeaks.Count > 0)
            {
                Console.WriteLine("Conquered peaks:");
                foreach (var peak in conqueredPeaks)
                {
                    Console.WriteLine(peak);
                }
            }
        }
    }
}
