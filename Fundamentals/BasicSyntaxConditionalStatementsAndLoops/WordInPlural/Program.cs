namespace WordInPlural
{
	internal class Program
	{
		static void Main()
		{
			string noun = Console.ReadLine();
			string nounPlural = string.Empty;
			if (noun.EndsWith('y'))
			{
				nounPlural = noun.Remove(noun.Length - 1);
				nounPlural += "ies";
			}
			else if (noun.EndsWith('o') || noun.EndsWith("ch") || noun.EndsWith('s') ||
			         noun.EndsWith("sh") || noun.EndsWith('x') || noun.EndsWith('z'))
			{
				nounPlural = noun + "es";
			}
			else
			{
				nounPlural = noun + "s";
			}

			Console.WriteLine(nounPlural);
		}
	}
}