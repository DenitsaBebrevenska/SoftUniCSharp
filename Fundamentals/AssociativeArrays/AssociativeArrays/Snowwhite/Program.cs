namespace Snowwhite
{
	internal class Program
	{
		static void Main()
		{
			string input;
			List<Dwarf> dwarves = new List<Dwarf>();

			while ((input = Console.ReadLine()) != "Once upon a time")
			{
				string[] dwarfDetails = input.Split();
				string name = dwarfDetails[0];
				string hatColor = dwarfDetails[2];
				int physics = int.Parse(dwarfDetails[4]);

				Dwarf dwarf = dwarves.FirstOrDefault(d => d.Name == name && d.HatColor == hatColor);

				if (dwarf == null)
				{
					dwarves.Add(new Dwarf(name, hatColor, physics));
				}
				else
				{
					int index = dwarves.FindIndex(d => d.Name == name && d.HatColor == hatColor);
					if (dwarf.Physics < physics)
					{
						dwarves[index].Physics = physics;
					}
				}

			}

			PrintDwarves(dwarves);
		}

		static void PrintDwarves(List<Dwarf> dwarves)
		{
			foreach (Dwarf dwarf in dwarves.OrderByDescending(d => d.Physics).
				         ThenByDescending(d => dwarves.Count(d2 => d2.HatColor == d.HatColor)))
			{
				Console.WriteLine($"({dwarf.HatColor}) {dwarf.Name} <-> {dwarf.Physics}");
			}
		}

	}
}