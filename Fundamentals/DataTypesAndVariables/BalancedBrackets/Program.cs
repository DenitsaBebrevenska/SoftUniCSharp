namespace BalancedBrackets
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int n = int.Parse(Console.ReadLine());
			bool isBalanced = true;
			bool openedBracket = false;

			for (int i= 0; i < n; i++)
			{
				string input = Console.ReadLine();
				if (input == "(")
				{
					if (openedBracket)
					{
						isBalanced = false;
					}
					else
					{
						openedBracket = true;
					}
				}
				else if (input == ")")
				{
					if (openedBracket)
					{
						openedBracket = false;
					}
					else
					{
						isBalanced = false;
					}
				}
			}
			if (openedBracket)
			{
				isBalanced = false;
			}
			Console.WriteLine(isBalanced ? "BALANCED" : "UNBALANCED");
		}
		
	}
}