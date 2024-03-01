using System.Text.RegularExpressions;

namespace WinningTicket
{
	internal class Program
	{
		static void Main()
		{
			string[] tickets = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
			string winningTicket = @"(?<symbol>[@#$^])\1{5,9}";

			for (int i = 0; i < tickets.Length; i++)
			{
				if (tickets[i].Length != 20)
				{
					Console.WriteLine("invalid ticket");
					continue;
				}

				string ticketLeftSide = string.Join("", tickets[i].Take(10));
				string ticketRightSide = string.Join("", tickets[i].Skip(10));
				Match leftMatch = Regex.Match(ticketLeftSide, winningTicket);
				Match rightMatch = Regex.Match(ticketRightSide, winningTicket);

				if (leftMatch.Success && rightMatch.Success )
				{
					int ticketLength = Math.Min(leftMatch.Length, rightMatch.Length);
					string output = $"ticket \"{tickets[i]}\" - {ticketLength}{leftMatch.Groups["symbol"].Value[0]}";

					if (ticketLength == 10)
					{
						output += " Jackpot!";
					}
					Console.WriteLine(output);

					continue;
				}

				Console.WriteLine($"ticket \"{tickets[i]}\" - no match");

			}

		}
	}
}