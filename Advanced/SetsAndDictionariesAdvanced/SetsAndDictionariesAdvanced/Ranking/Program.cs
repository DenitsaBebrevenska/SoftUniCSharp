namespace Ranking
{
    internal class Program
    {
        static void Main()
        {
            Dictionary<string, string> contests = new();
            PopulateContestDictionary(contests);
            List<Contestant> contestantList = new();
            string input;

            while ((input = Console.ReadLine()) != "end of submissions")
            {
                string[] submissionDetails = input.Split("=>");
                string contest = submissionDetails[0];
                string password = submissionDetails[1];
                string username = submissionDetails[2];
                int userPoints = int.Parse(submissionDetails[3]);

                if (!contests.ContainsKey(contest))
                {
                   continue;
                }

                if (contests[contest] != password)
                {
                    continue;
                }

                Contestant currentContestant = contestantList.FirstOrDefault(c => c.Name == username);

                if (currentContestant == null)
                {
                    contestantList.Add(currentContestant = new Contestant(username));
                }
                
                if (!currentContestant.Contests.ContainsKey(contest))
                {
                    currentContestant.Contests.Add(contest, userPoints);
                }
                else if (currentContestant.Contests.ContainsKey(contest) && currentContestant.Contests[contest] < userPoints)
                {
                    currentContestant.Contests[contest] = userPoints;
                }
            }

            PrintContestantsRanking(contestantList);
        }

        static void PrintContestantsRanking(List<Contestant> contestantList)
        {
            Contestant bestContestant = contestantList.OrderByDescending(c => c.TotalScore).First();
            Console.WriteLine($"Best candidate is {bestContestant.Name} with total {bestContestant.TotalScore} points.");
            Console.WriteLine("Ranking:");

            foreach (Contestant contestant in contestantList.OrderBy(c => c.Name))
            {
                Console.WriteLine(contestant);
            }
        }

        static void PopulateContestDictionary(Dictionary<string, string> contests)
        {
            string input;
            while ((input = Console.ReadLine()) != "end of contests")
            {
                string[] contestDetails = input.Split(':');
                string contestName = contestDetails[0];
                string contestPassword = contestDetails[1];
                contests.Add(contestName, contestPassword);
            }
        }
    }
}
