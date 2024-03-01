namespace UserLogs
{
	internal class Program
	{
		static void Main()
		{
			SortedDictionary<string, List<Ip>> serverFloodInformation = new SortedDictionary<string, List<Ip>>();
			//•	IP=(IP.Address) message=(A&sample&message) user=(username)
			string input;

			while ((input = Console.ReadLine()) != "end")
			{
				string[] tokens = input.Split();
				string ip = tokens[0].Remove(0,3);
				string username = tokens[2].Remove(0,5);

				if (!serverFloodInformation.ContainsKey(username))
				{
					serverFloodInformation.Add(username, new List<Ip>());
				}

				Ip currentIp = serverFloodInformation[username].FirstOrDefault(x => x.Number == ip);

				if (currentIp is null)
				{
					serverFloodInformation[username].Add(new Ip(ip, 1));
				}
				else
				{
					currentIp.MessageCount++;
				}
			}

			foreach (var kvp in serverFloodInformation)
			{
				Console.WriteLine($"{kvp.Key}: ");
				Console.WriteLine($"{string.Join(", ", kvp.Value)}.");
			}
		}
	}
}
