namespace PlayCatch
{
	internal class Program
	{
		static void Main()
		{
			int[] numbers = Console.ReadLine().
				Split().
				Select(int.Parse).
				ToArray();

			byte exceptionsThrown = 0;

			while (exceptionsThrown < 3)
			{
				string[] commandArgs = Console.ReadLine().Split();
				
				string command = commandArgs[0];

				if (command == "Replace" || command == "Print")
				{
					int index;
					int value;

					try
					{
						index = int.Parse(commandArgs[1]);
						value = int.Parse(commandArgs[2]);
					}
					catch (Exception)
					{
						Console.WriteLine("The variable is not in the correct format!");
						exceptionsThrown++;
						continue;
					}

					if (command == "Replace")
					{
						try
						{
							numbers[index] = value;
						}
						catch (Exception)
						{
							Console.WriteLine("The index does not exist!");
							exceptionsThrown++; 
						}
					}
					else if (command == "Print")
					{

						try
						{
							int start = numbers[index];
							int end = numbers[value];

							for (int i = index; i <= value; i++)
							{
								if (i == value)
								{
									Console.WriteLine(numbers[i]);
									break;
								}
								Console.Write(numbers[i] + ", ");
							}
							
						}
						catch (Exception)
						{
							Console.WriteLine("The index does not exist!");
							exceptionsThrown++;
						}
					}
				}
				else if (command == "Show")
				{
					int indexShow;
					try
					{
						indexShow = int.Parse(commandArgs[1]);
						
					}
					catch (Exception)
					{
						Console.WriteLine("The variable is not in the correct format!");
						exceptionsThrown++;
						continue;
					}
					
					try
					{
						Console.WriteLine(numbers[indexShow]);
					}
					catch (Exception)
					{
						Console.WriteLine("The index does not exist!");
						exceptionsThrown++;
					}
				}

			}

			Console.WriteLine(string.Join(", ", numbers));
		}
	}
}
