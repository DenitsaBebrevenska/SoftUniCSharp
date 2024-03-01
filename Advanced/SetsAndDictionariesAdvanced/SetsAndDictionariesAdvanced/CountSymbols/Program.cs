namespace CountSymbols
{
    internal class Program
    {
        static void Main()
        {
            string text = Console.ReadLine();
            SortedDictionary<char, int> symbols = new SortedDictionary<char, int>();

            foreach (char symbol in text)
            {
                if (!symbols.ContainsKey(symbol))
                {
                    symbols.Add(symbol, 1);
                    continue;
                }

                symbols[symbol]++;
            }

            foreach (var kvp in symbols)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value} time/s");
            }
        }
    }
}
