namespace Articles
{
	internal class Program
	{
		static void Main()
		{
			string[] articleDetails = Console.ReadLine().Split(", ");
			int numberOfIterations = int.Parse(Console.ReadLine());

			string title = articleDetails[0];
			string content = articleDetails[1];
			string author = articleDetails[2];
			Article article = new Article(title, content, author);

			for (int i = 0; i < numberOfIterations; i++)
			{
				string[] command = Console.ReadLine().Split(": ");
				switch (command[0])
				{
					case "Edit":
						article.Edit(command[1]);
						break;
					case "ChangeAuthor":
						article.ChangeAuthor(command[1]);
						break;
					case "Rename":
						article.Rename(command[1]);
						break;
				}
			}

			Console.WriteLine(article);
		}
	}
}