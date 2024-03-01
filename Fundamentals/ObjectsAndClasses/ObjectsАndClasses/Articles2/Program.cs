namespace Articles2
{
	internal class Program
	{
		static void Main()
		{
			
			int numberOfArticles = int.Parse(Console.ReadLine());
			List<Article> articles = new List<Article>();

			for (int i = 0; i < numberOfArticles; i++)
			{
				string[] articleDetails = Console.ReadLine().Split(", ");
				string title = articleDetails[0];
				string content = articleDetails[1];
				string author = articleDetails[2];
				Article article = new Article(title, content, author);
				articles.Add(article);
			}

			foreach (Article article in articles)
			{
				Console.WriteLine(article);
			}
		}
	}

	
}