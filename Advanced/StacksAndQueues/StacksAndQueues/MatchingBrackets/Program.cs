namespace MatchingBrackets
{
	internal class Program
	{
		static void Main()
		{
			string expression = Console.ReadLine();
			Stack<int> indexesBrackets = new Stack<int>();

			for (int i = 0; i < expression.Length; i++)
			{
				if (expression[i] == '(')
				{
					indexesBrackets.Push(i);
				}
				else if (expression[i] == ')')
				{
					int startIndex = indexesBrackets.Pop();
					Console.WriteLine(expression.Substring(startIndex, i - startIndex + 1));
				}
			}
		}
	}
}
