namespace DNASequences
{
	internal class Program
	{
		static void Main()
		{
			int matchNumber = int.Parse(Console.ReadLine());
			string nucleicAcid = "ACGT";

			for (int i = 0; i < 4; i++)
			{
				char a = nucleicAcid[i];

				for (int j = 0; j < 4; j++)
				{
					char b = nucleicAcid[j];

					for (int k = 0; k < 4; k++)
					{
						char c = nucleicAcid[k];
						int sum = i + 1 + j + 1 + k + 1;
						char additionalChar;

						if (sum >= matchNumber)
						{
							additionalChar = 'O';
						}
						else
						{
							additionalChar = 'X';
						}

						Console.Write($"{additionalChar}{a}{b}{c}{additionalChar} ");
					}

					if (i == 3 && j ==3) //prevent new line after the last print out
					{
						return;
					}
					Console.WriteLine();
				}
			}
		}
	}
}