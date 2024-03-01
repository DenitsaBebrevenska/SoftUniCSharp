namespace CompanyUsers
{
	internal class Program
	{
		static void Main()
		{
			string input;
			Dictionary<string, List<string>> usersDictionary = new Dictionary<string, List<string>>();

			while ((input = Console.ReadLine()) != "End")
			{
				string[] userDetails = input.Split(" -> ");
				string companyName = userDetails[0];
				string userId = userDetails[1];

				if (!usersDictionary.ContainsKey(companyName))
				{
					usersDictionary.Add(companyName, new List<string>());
				}

				List<string> currentCompany = usersDictionary[companyName];

				if (currentCompany.Contains(userId))
				{
					continue;
				}
				currentCompany.Add(userId);
			}

			foreach (var kvp in usersDictionary)
			{
				Console.WriteLine(kvp.Key);
				foreach (var id in kvp.Value)
				{
					Console.WriteLine($"-- {id}");
				}
			}
		}
	}
}