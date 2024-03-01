namespace AppendArrays
{
	internal class Program
	{
		static void Main()
		{
			string[] arrays = Console.ReadLine().Split('|');
			List<int> currentList = new List<int>();

			for (int i = arrays.Length - 1; i >= 0; i--)
			{
				string[] currentArray = arrays[i].Split(' ', StringSplitOptions.RemoveEmptyEntries);

				for (int j = 0; j < currentArray.Length; j++)
				{
                    currentList.Add(int.Parse(currentArray[j]));
				}
			}
			Console.WriteLine(string.Join(' ', currentList));
		}
	}
}