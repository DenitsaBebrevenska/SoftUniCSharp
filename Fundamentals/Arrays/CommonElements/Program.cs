namespace CommonElements
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string[] input1 = Console.ReadLine().Split(" ");
			string[] input2 = Console.ReadLine().Split(" ");
			string commonElements = string.Empty;
			for (int i = 0; i < input2.Length; i++)
			{
				for (int j = 0; j < input1.Length; j++)
				{
					if (input2[i] == input1[j])
					{
						commonElements += input2[i] + " ";
					}
				}
			}
            Console.WriteLine(commonElements);
        }
	}
}