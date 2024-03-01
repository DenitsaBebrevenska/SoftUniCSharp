using System.Text.RegularExpressions;

namespace ParkingValidation
{
	internal class Program
	{
		static void Main()
		{
			Dictionary<string, string> platesDictionary = new Dictionary<string, string>();
			string validPlatePattern = @"[A-Z]{2}\d{4}[A-Z]{2}";
			int numberOfLines = int.Parse(Console.ReadLine());

			for (int i = 0; i < numberOfLines; i++)
			{
				string[] commandArgs = Console.ReadLine().Split();
				string action = commandArgs[0];
				string username = commandArgs[1];

				if (action == "register")
				{
					string licensePlate = commandArgs[2];
					Match matchPlate = Regex.Match(licensePlate, validPlatePattern);

					
					if (platesDictionary.ContainsKey(username) && (platesDictionary[username] != licensePlate))
					{

						Console.WriteLine($"ERROR: already registered with plate number {platesDictionary[username]}");
						continue;
					}

					if (!matchPlate.Success)
					{
						Console.WriteLine($"ERROR: invalid license plate {licensePlate}");
						continue;
					}

					if (platesDictionary.Values.Contains(licensePlate))
					{
						Console.WriteLine($"ERROR: license plate {licensePlate} is busy");
						continue;
					}

					platesDictionary.Add(username, licensePlate);
					Console.WriteLine($"{username} registered {licensePlate} successfully");

				}
				else
				{
					if (!platesDictionary.ContainsKey(username))
					{
						Console.WriteLine($"ERROR: user {username} not found");
						continue;
					}

					Console.WriteLine($"user {username} unregistered successfully");
					platesDictionary.Remove(username);
				}
			}

			foreach (var kvp in platesDictionary)
			{
				Console.WriteLine($"{kvp.Key} => {kvp.Value}");
			}
		}
	}
}
