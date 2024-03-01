namespace TextFilter
{
	internal class Program
	{
		static void Main()
		{
			string[] bannedList = Console.ReadLine().Split(", ");
			string text = Console.ReadLine();

			for (int i = 0; i < bannedList.Length; i++)
			{
				while (text.Contains(bannedList[i]))
				{
					text = text.Replace(bannedList[i], new string('*', bannedList[i].Length));
				}
			}

			Console.WriteLine(text);
		}
	}
}