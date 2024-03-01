namespace ImmuneSystem
{
	internal class Program
	{
		static void Main()
		{
			Dictionary<Virus, int> virusMap = new Dictionary<Virus, int>();
			int immuneSystemHealth = int.Parse(Console.ReadLine());
			int immuneSystemInitial = immuneSystemHealth;
			string virus;

			while ((virus = Console.ReadLine()) != "end")
			{
				int virusStrength = virus.ToCharArray().Sum(c => c) / 3;
				int timeToDefeat = virusStrength * virus.Length;
				
				Virus currentVirus = virusMap.Keys.FirstOrDefault(v => v.Name == virus);

				if (currentVirus is null)
				{
					virusMap.Add((new Virus(virus, timeToDefeat)), 1);
				}
				else
				{
					if (virusMap[currentVirus] == 1)
					{
						currentVirus.DefeatTime /= 3;
						virusMap[currentVirus]++;
					}
				}

				currentVirus = virusMap.Keys.FirstOrDefault(v => v.Name == virus);
				int minutes = currentVirus.DefeatTime / 60;
				int remainingSeconds = currentVirus.DefeatTime % 60;
				immuneSystemHealth -= currentVirus.DefeatTime;

				Console.WriteLine($"Virus {virus}: {virusStrength} => {currentVirus.DefeatTime} seconds");

				if (immuneSystemHealth > 0)
				{
					Console.WriteLine($"{virus} defeated in {minutes}m {remainingSeconds}s.");
					Console.WriteLine($"Remaining health: {immuneSystemHealth}");

					immuneSystemHealth += (int)(immuneSystemHealth * 0.2);

					if (immuneSystemHealth > immuneSystemInitial)
					{
						immuneSystemHealth = immuneSystemInitial;
					}
				}
				else
				{
					Console.WriteLine("Immune System Defeated.");
					return;
				}
			}

			Console.WriteLine($"Final Health: {immuneSystemHealth}");
		}
	}
}
