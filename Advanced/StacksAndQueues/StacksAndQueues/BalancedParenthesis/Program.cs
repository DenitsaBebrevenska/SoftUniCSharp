namespace BalancedParenthesis
{
	internal class Program
	{
		static void Main()
		{
			string input = Console.ReadLine();
			char[] openingBrackets = new char[] { '{', '(', '[' };
			Stack<char> openingBracketsStack = new Stack<char>();
			
			if (input.Length % 2 != 0)
			{
				Console.WriteLine("NO");
				return;
			}

			foreach (char bracket in input)
			{
				if (!openingBrackets.Contains(bracket) && openingBracketsStack.Count == 0) 
				{
					//The Judge tests actually missed on this scenario but I think it must be included
					//otherwise brackets like this ")))" will generate "YES"
					Console.WriteLine("NO");
					return;
				}

				if (openingBrackets.Contains(bracket))
				{
					openingBracketsStack.Push(bracket);
					continue;
				}


				if ((openingBracketsStack.Peek() == '{' && bracket != '}') ||
				    (openingBracketsStack.Peek() == '(' && bracket != ')') ||
				    (openingBracketsStack.Peek() == '[' && bracket != ']'))
				{
					Console.WriteLine("NO");
					return;
				}

				openingBracketsStack.Pop();
			}

			Console.WriteLine(openingBracketsStack.Count > 0 ? "NO" : "YES");
		}
	}
}