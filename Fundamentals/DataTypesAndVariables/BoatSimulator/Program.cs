namespace BoatSimulator
{
	internal class Program
	{
		static void Main()
		{
			char boat1 = Console.ReadLine()[0];
			char boat2 = Console.ReadLine()[0];
			int linesCount = int.Parse(Console.ReadLine());
			int tilesBoat1 = 0, tilesBoat2 = 0;
			//odd = boat 1, even == boat2, winner is 50 tiles first, if neither has 50 tiles before the end, the one with most wins
			//UPGRADE += ASCII value chars
			for (int i = 1; i <= linesCount; i++)
			{
				string command = Console.ReadLine();
				if (command == "UPGRADE")
				{
					boat1 += (char)3;
					boat2 += (char)3;
					continue;
				}

				if (i % 2 != 0)
				{
					tilesBoat1 += command.Length;
				}
				else
				{
					tilesBoat2 += command.Length;
				}

				if (tilesBoat1 >= 50 || tilesBoat2 >= 50)
				{
					Console.WriteLine(tilesBoat1 >= 50 ? boat1 : boat2);
					return;
				}
			}

			Console.WriteLine(tilesBoat1 > tilesBoat2 ? boat1 : boat2);
		}
	}
}