namespace StringExplosion
{
	internal class Program
	{
		static void Main()
		{
			string explosiveString = Console.ReadLine();

			int leftOverPower = 0;
			for (int i = 0; i < explosiveString.Length; i++)
			{
				if (explosiveString[i] == '>')
				{
					int power = explosiveString[i + 1] - '0' + leftOverPower;

					for (int j = 0; j < power && i + 1 < explosiveString.Length; j++) //prevent out of bound
					{
						if (explosiveString[i + 1] == '>')
						{
							leftOverPower = power - j;
							break;
						}

						explosiveString = explosiveString.Remove(i + 1, 1);

						if (j == power) //if all the power is used make the leftOver = 0 to prevent miscalculations
						{
							leftOverPower = 0;
						}
					}
				}
			}

			Console.WriteLine(explosiveString);
		}
	}
}
