namespace SumOfCoins
{
    using System.Collections.Generic;

    public class StartUp
    {
        //Create a program, which gathers a sum of money, using the least possible number of coins. The range of possible coin values is 1, 2, 5,
        //10, 20, 50. The goal is to reach the desired sum using as few coins as possible.
        //You can solve the task by using a greedy approach. 

        public static void Main(string[] args)
        {
            List<int> coins = new List<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .OrderByDescending(c => c));
            int targetSum = int.Parse(Console.ReadLine());
            Dictionary<int, int> result = new();

            try
            {
                result = ChooseCoins(coins, targetSum);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Environment.Exit(1);
            }

            Console.WriteLine($"Number of coins to take: {result.Sum(x => x.Value)}");
            
            foreach (var kvp in result)
            {
                Console.WriteLine($"{kvp.Value} coin(s) with value {kvp.Key}");
            }
        }

        public static Dictionary<int, int> ChooseCoins(List<int> coins, int targetSum)
        {
            Dictionary<int, int> result = new Dictionary<int, int>();

            for (int i = 0; i < coins.Count; i++)
            {
                if (targetSum >= coins[i])
                {
                    targetSum -= coins[i];

                    if (!result.ContainsKey(coins[i]))
                    {
                        result.Add(coins[i], 0);
                    }

                    result[coins[i]]++;
                    i--;
                    continue;
                }

                if (i == coins.Count - 1 && targetSum > 0)
                {
                    throw new Exception("Error");
                }
            }

            return result;
        }
    }
}
