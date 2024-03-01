namespace FloatingEquality
{
	internal class Program
	{
		static void Main(string[] args)
		{
			double num1 = double.Parse(Console.ReadLine());
			double num2 = double.Parse(Console.ReadLine());
			double precisionEps = 0.000001;

			double result = Math.Abs(num1 - num2);
			if (result >= precisionEps)
			{
				Console.WriteLine("False");
			}
			else
			{
                Console.WriteLine("True");
            }

		}	
	}
}