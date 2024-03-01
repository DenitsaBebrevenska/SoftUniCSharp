namespace SoftUniParking
{
	internal class Program
	{
		static void Main()
		{
			int numberOfCommands = int.Parse(Console.ReadLine());
			Dictionary<string, string> dataParking = new Dictionary<string, string>();
			
			for (int i = 0; i < numberOfCommands; i++)
			{
				string[] commandDetails = Console.ReadLine().Split();
				string command = commandDetails[0];
				string user = commandDetails[1];
				

				if (command == "register")
				{
					HandleRegistration(commandDetails, dataParking);
				}
				else //unregister
				{
					HandleDeregistration(commandDetails, dataParking);
				}
			}

			foreach (var kvp in dataParking)
			{
				Console.WriteLine($"{kvp.Key} => {kvp.Value}");
			}
		}

		static void HandleRegistration(string[] commandDetails, Dictionary<string, string> dataParking)
		{
			string user = commandDetails[1];
			string licensePlate = commandDetails[2];
			if (dataParking.ContainsKey(user))
			{
				Console.WriteLine($"ERROR: already registered with plate number {licensePlate}");
				return;
			}

			dataParking.Add(user, licensePlate);
			Console.WriteLine($"{user} registered {licensePlate} successfully");
		}

		static void HandleDeregistration(string[] commandDetails, Dictionary<string, string> dataParking)
		{
			string command = commandDetails[0];
			string user = commandDetails[1];

			if (!dataParking.ContainsKey(user))
			{
				Console.WriteLine($"ERROR: user {user} not found");
				return;
			}

			dataParking.Remove(user);
			Console.WriteLine($"{user} unregistered successfully");
		}
	}
}