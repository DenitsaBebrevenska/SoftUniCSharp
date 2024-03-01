namespace HTML
{
	internal class Program
	{
		static void Main()
		{
			string article = Console.ReadLine();
			string content = Console.ReadLine();
			string input;
			List<string> comments = new List<string>();
			while ((input = Console.ReadLine()) != "end of comments")
			{
				comments.Add(input);
			}
			PrintArticle(article);
			PrintContent(content);
			PrintComment(comments);
		}

		static void PrintArticle(string article)
		{
			Console.WriteLine("<h1>");
			Console.WriteLine($"\t {article}");
			Console.WriteLine("</h1>");
		}
		static void PrintContent(string content)
		{
			Console.WriteLine("<article>");
			Console.WriteLine($"\t {content}");
			Console.WriteLine("</article>");
		}
		static void PrintComment(List<string> comments)
		{
			foreach (string comment in comments)
			{
				Console.WriteLine("<div>");
				Console.WriteLine($"\t {comment}");
				Console.WriteLine("</div>");
			}
		}
	}
}