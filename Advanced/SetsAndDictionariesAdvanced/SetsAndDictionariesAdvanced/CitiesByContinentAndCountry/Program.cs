namespace CitiesByContinentAndCountry
{
    internal class Program
    {
        static void Main()
        {
            //must use nested dictionaries
            Dictionary<string, Dictionary<string, List<string>>> continentMap =
                new Dictionary<string, Dictionary<string, List<string>>>();

            byte entryCount = byte.Parse(Console.ReadLine());

            for (int i = 0; i < entryCount; i++)
            {
                string[] entryDetails = Console.ReadLine().Split();
                string continent = entryDetails[0];
                string country = entryDetails[1];
                string city = entryDetails[2];

                if (!continentMap.ContainsKey(continent))
                {
                   continentMap.Add(continent,new Dictionary<string, List<string>>()); 
                }

                if (!continentMap[continent].ContainsKey(country))
                {
                    continentMap[continent].Add(country,new List<string>());
                }

                continentMap[continent][country].Add(city);
            }

            foreach (var kvp in continentMap)
            {
                Console.WriteLine($"{kvp.Key}:");

                foreach (var kvp2 in kvp.Value)
                {
                    Console.WriteLine($"\t{kvp2.Key} -> {string.Join(", ", kvp2.Value)}");
                }
            }
        }
    }
}
