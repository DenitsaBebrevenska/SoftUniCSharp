namespace PersonalException
{
	internal class Program
	{
		static void Main()
		{
			try
			{
				while (true)
				{
					int currentNumber = int.Parse(Console.ReadLine());

					if (currentNumber >= 0)
					{
						Console.WriteLine(currentNumber);
					}
					else
					{
						throw new NegativeNumberException();
					}

				}
			}
			catch (NegativeNumberException e)
			{
				Console.WriteLine(e.Message);
			}
			
		}
	}

	internal class NegativeNumberException : System.Exception
	{
		public NegativeNumberException()
			: base("My first exception is awesome!!!")
		{

		}
	}
}
