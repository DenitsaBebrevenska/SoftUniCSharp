namespace StringsAndObjects
{
	internal class Program
	{
		static void Main()
		{
			string myString = "Hello";
			string myString2 = "World";

			var concatenation = myString + " " + myString2;
			string output = (string) concatenation;
			Console.WriteLine(output);
		}
	}
}