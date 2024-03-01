namespace FashionBoutique
{
	internal class Program
	{
		static void Main()
		{
			Stack<ushort> clothes = new Stack<ushort>(Console.ReadLine().Split().Select(ushort.Parse));
			ushort rackCapacity = ushort.Parse(Console.ReadLine());

			ushort sumCurrent = 0;
			byte rackCount = 1;

			while (clothes.Count > 0)
			{
				ushort currentClothing = clothes.Pop();

				if (sumCurrent + currentClothing < rackCapacity)
				{
					sumCurrent += currentClothing;
				}
				else if (sumCurrent + currentClothing == rackCapacity)
				{
					sumCurrent = 0;

					if (clothes.Count > 0)
					{
						rackCount++;
					}
					
				}
				else
				{
					sumCurrent = currentClothing;
					rackCount++;
				}
			}

			Console.WriteLine(rackCount);
		}
	}
}
