namespace PokemonDontGo
{
	internal class Program
	{
		static void Main()
		{
			List<int> numbers = Console.ReadLine().
				Split(' ').
				Select(int.Parse).
				ToList();

			int score = 0;
			while (numbers.Count > 0)
			{
				int index = int.Parse(Console.ReadLine());
				int removedElement = 0;

				if (index < 0)
				{ 
					removedElement = numbers[0];
					numbers[0] = numbers[^1];
				}
				else if (index > numbers.Count - 1)
				{ 
					removedElement = numbers[^1];
					numbers[^1] = numbers[0];
				}
				else
				{
					removedElement = numbers[index];
					numbers.RemoveAt(index);
				}
				
				score += removedElement;

				for (int i = 0; i < numbers.Count; i++)
				{
					if (numbers[i] <= removedElement)
					{
						numbers[i] += removedElement;
					}
					else
					{
						numbers[i] -= removedElement;
					}
				}
			}
            Console.WriteLine(score);
        }
	}
}