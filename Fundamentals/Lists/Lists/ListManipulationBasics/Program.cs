namespace ListManipulationBasics
{
	internal class Program
	{
		static void Main()
		{
			List<int> numbers = Console.ReadLine().
				Split().
				Select(int.Parse).
				ToList();
			string command;

			while ((command = Console.ReadLine()) != "end")
			{
				string[] arguments = command.Split(' ');
				switch (arguments[0])
				{
					case "Add":
						int numberToAdd = int.Parse(arguments[1]);
						numbers.Add(numberToAdd);
						break;
					case "Remove":
						int numberToRemove = int.Parse(arguments[1]);
						numbers.Remove(numberToRemove);
						break;
					case "RemoveAt":
						int indexRemoveNumber = int.Parse(arguments[1]);
						numbers.RemoveAt(indexRemoveNumber);
						break;
					case "Insert":
						int numberToInsert = int.Parse(arguments[1]);
						int indexInsert = int.Parse(arguments[2]);
						numbers.Insert(indexInsert, numberToInsert);
						break;
				}
			}
            Console.WriteLine(string.Join(' ', numbers));
        }
	}
}