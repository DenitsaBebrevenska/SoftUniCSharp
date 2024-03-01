namespace LogsAggregator
{
	internal class Program
	{
		static void Main()
		{
			List<UserName> userNameList = new List<UserName>();
			ushort numberOfLines = ushort.Parse(Console.ReadLine());

			for (ushort i = 0; i < numberOfLines; i++)
			{
				string[] logDetails = Console.ReadLine().Split();
				string ip = logDetails[0];
				string username = logDetails[1];
				uint duration = uint.Parse(logDetails[2]);
				int indexUser = userNameList.FindIndex(x => x.Name == username);

				if (indexUser < 0)
				{
					UserName userName = new UserName(username, duration);
					userNameList.Add(userName);
					userName.IpList.Add(ip);
					continue;
				}

				userNameList[indexUser].TotalDuration += duration;

				if (!userNameList[indexUser].IpList.Contains(ip))
				{
					userNameList[indexUser].IpList.Add(ip);
				}
			}

			foreach (UserName un in userNameList.OrderBy(x => x.Name))
			{
				Console.WriteLine($"{un.Name}: {un.TotalDuration} {un.PrintListOfIps()}");
			}
		}
	}
}
