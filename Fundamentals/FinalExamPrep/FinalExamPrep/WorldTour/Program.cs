namespace WorldTour
{
	internal class Program
	{
		static void Main()
		{
			string travelInformation = Console.ReadLine();
			string input;

			while ((input = Console.ReadLine()) != "Travel")
			{
				string[] tokens = input.Split(':');
				string command = tokens[0];
				switch (command)
				{
					case "Add Stop":
						int index = int.Parse(tokens[1]);
						string newLocation = tokens[2];
						if (IndexIsValid(index, travelInformation))
						{
							travelInformation = travelInformation.Insert(index, newLocation);
						}
						break;
					case "Remove Stop":
						int startIndex = int.Parse(tokens[1]);
						int endIndex = int.Parse(tokens[2]);
						if (IndexIsValid(startIndex, travelInformation) &&
						    IndexIsValid(endIndex, travelInformation))
						{
							travelInformation = travelInformation.Remove(startIndex, endIndex - startIndex + 1);
						}
						break;
					case "Switch":
						string oldString = tokens[1];
						string newString = tokens[2];
						if (travelInformation.Contains(oldString))
						{
							travelInformation = travelInformation.Replace(oldString, newString);
						}
						break;
				}

				Console.WriteLine(travelInformation);
			}

			Console.WriteLine($"Ready for world tour! Planned stops: {travelInformation}");
		}

		static bool IndexIsValid(int index, string travelInformation)
		{
			return index >= 0 && index < travelInformation.Length;
		}
	}
}