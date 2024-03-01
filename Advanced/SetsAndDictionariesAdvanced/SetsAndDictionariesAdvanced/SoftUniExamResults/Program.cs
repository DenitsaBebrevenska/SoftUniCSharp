namespace SoftUniExamResults
{
    internal class Program
    {
        static void Main()
        {
            Dictionary<string, int> contestants = new();
            Dictionary<string, int> languages = new();
            string input;

            while ((input = Console.ReadLine()) != "exam finished")
            {
                string[] contestDetails = input.Split('-');

                if (contestDetails.Length == 2)
                {
                    string contestantToRemove = contestDetails[0];
                    contestants.Remove(contestantToRemove);
                    continue;
                }

                string contestant = contestDetails[0];
                string language = contestDetails[1];
                int points = int.Parse(contestDetails[2]);

                if (!contestants.ContainsKey(contestant))
                {
                    contestants.Add(contestant, 0);
                }

                if (contestants[contestant] < points)
                {
                    contestants[contestant] = points;
                }

                if (!languages.ContainsKey(language))
                {
                    languages.Add(language, 0);
                }

                languages[language]++;
            }

            PrintContestantsResults(contestants);
            PrintLanguageSubmissions(languages);

        }

        static void PrintContestantsResults(Dictionary<string, int> contestants)
        {
            Console.WriteLine("Results:");

            foreach (var kvp in contestants.OrderByDescending(c => c.Value).
                         ThenBy(c => c.Key))
            {
                Console.WriteLine($"{kvp.Key} | {kvp.Value}");
            }
        }

        static void PrintLanguageSubmissions(Dictionary<string, int> languages)
        {
            Console.WriteLine("Submissions:");

            foreach (var kvp in languages.OrderByDescending(l => l.Value).
                         ThenBy(l => l.Key))
            { 
                Console.WriteLine($"{kvp.Key} - {kvp.Value}");
            }
        }
    }
}
