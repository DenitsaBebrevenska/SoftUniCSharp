namespace SimpleCalculator
{
	internal class Program
	{
		static void Main()
		{
			//must use stack
			Stack<string> expression = new Stack<string>(Console.ReadLine().Split().Reverse()); 
			int sum = int.Parse(expression.Pop());

			while (expression.Count > 0)
			{
				string currentOperator = expression.Pop();
				int number = int.Parse(expression.Pop());

				if (currentOperator == "+")
				{
					sum += number;
				}
				else // extraction
				{
					sum -= number;
				}
			}

			Console.WriteLine(sum);
		}
	}
}
