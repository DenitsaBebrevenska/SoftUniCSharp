using System.Numerics;

namespace CenturiesToNanoseconds
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int centuries = int.Parse(Console.ReadLine());

			int years = centuries * 100;
			int days = (int)(years * 365.2422);
			int hours = days * 24;
			int minutes = hours * 60;
			BigInteger seconds = (BigInteger)minutes * 60;
			BigInteger miliseconds = seconds * 1000;
			BigInteger microseconds = miliseconds * 1000;
			BigInteger nanoseconds = microseconds  * 1000;
			Console.WriteLine($"{centuries} centuries = {years} years = {days:F0}" +
			                  $" days = {hours} hours = {minutes} minutes =" +
			                  $" {seconds} seconds = {miliseconds} milliseconds = {microseconds}" +
			                  $" microseconds = {nanoseconds} nanoseconds");
		}
	}
}