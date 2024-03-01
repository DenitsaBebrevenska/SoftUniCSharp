namespace Elevator
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int numberOfPeople = int.Parse(Console.ReadLine());
			int capacity = int.Parse(Console.ReadLine());
			//how many courses of elevator lifts will be needed to bring all ppl up

			double courses = (double)numberOfPeople / capacity;
            Console.WriteLine(Math.Ceiling(courses));

        }
	}
}