using System.Text;

namespace MorsCodeUpgraded
{
	internal class Program
	{
		static void Main()
		{
			string[] messageTokens = Console.ReadLine().Split('|');
			
			StringBuilder messageBuilder = new StringBuilder();

			for (int i = 0; i < messageTokens.Length; i++)
			{
				int sum = 0;
				string[] zeroes = messageTokens[i].Split('1', StringSplitOptions.RemoveEmptyEntries);
				string[] ones = messageTokens[i].Split('0', StringSplitOptions.RemoveEmptyEntries);

				sum += zeroes.Sum(x => x.Length) * 3 + zeroes.Where(s => s.Length > 1).Sum(s => s.Length);
				sum += ones.Sum(x => x.Length) * 5 + ones.Where(s => s.Length > 1).Sum(s => s.Length);
				messageBuilder.Append((char)sum);
			}

			Console.WriteLine(messageBuilder.ToString());
		}
	}
}
