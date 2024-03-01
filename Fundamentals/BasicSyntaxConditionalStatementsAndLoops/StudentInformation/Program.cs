namespace StudentInformation
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string name = Console.ReadLine();
			int age = int.Parse(Console.ReadLine());
			double averageScore = double.Parse(Console.ReadLine());

			Console.WriteLine($"Name: {name}, Age: {age}, Grade: {averageScore:f2}");
		}
	} 
}