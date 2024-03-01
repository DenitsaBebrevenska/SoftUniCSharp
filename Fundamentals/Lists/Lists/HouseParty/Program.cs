namespace HouseParty
{
	internal class Program
	{
		static void Main()
		{
			int numberOfLines = int.Parse(Console.ReadLine());
			List<string> guests = new List<string>();

			for (int i = 1; i <= numberOfLines; i++)
			{
				string line = Console.ReadLine();
				string[] tokens = line.Split(' ');
				string guestName = tokens[0];
				if (line.Contains("not"))
				{
					if (guests.Contains(guestName))
					{
						guests.Remove(guestName);
					}
					else
					{
						Console.WriteLine($"{guestName} is not in the list!");
					}
				}
				else
				{
					if (guests.Contains(guestName))
					{
						Console.WriteLine($"{guestName} is already in the list!");
					}
					else
					{
						guests.Add(guestName);
					}
				}
			}
			foreach (string name in guests)
			{
                Console.WriteLine(name);
            }
        }
	}
}