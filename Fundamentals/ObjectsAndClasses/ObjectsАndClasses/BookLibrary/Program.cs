using System.Globalization;
namespace BookLibrary
{
	internal class Program
	{
		static void Main()
		{
			byte numberOfLines = byte.Parse(Console.ReadLine());
			List<Book> books = PopulateBookList(numberOfLines);
			Library library = new Library()
			{
				Books = books
			};

			Dictionary<string, decimal> authorDictionary = PopulateAuthorDictionary(library.Books);

			foreach (var kvp in authorDictionary.OrderByDescending(x => x.Value).
				         ThenBy(x => x.Key))
			{
				Console.WriteLine($"{kvp.Key} -> {kvp.Value:F2}");
			}
		}

		static List<Book> PopulateBookList(byte numberOfLines)
		{
			List<Book> books = new List<Book>();

			for (byte i = 0; i < numberOfLines; i++)
			{
				//{title} {author} {publisher} {release date} {ISBN} {price}
				string[] bookArgs = Console.ReadLine().Split();
				string bookName = bookArgs[0];
				string bookAuthor = bookArgs[1];
				string bookPublisher = bookArgs[2];
				DateTime bookPublishDate = DateTime.ParseExact(bookArgs[3], "dd.MM.yyyy", CultureInfo.InvariantCulture);
				string bookISBN = bookArgs[4];
				decimal bookPrice = decimal.Parse(bookArgs[5]);

				books.Add(new Book()
				{
					Name = bookName,
					Author = bookAuthor,
					Publisher = bookPublisher,
					ISBN = bookISBN,
					Price = bookPrice,
					ReleaseDate = bookPublishDate
				});
			}

			return books;
		}

		static Dictionary<string, decimal> PopulateAuthorDictionary(List<Book> books)
		{
			Dictionary<string, decimal> authorDictionary = new Dictionary<string, decimal>();

			foreach (Book book in books)
			{
				if (!authorDictionary.ContainsKey(book.Author))
				{
					authorDictionary.Add(book.Author, book.Price);
				}
				else
				{
					authorDictionary[book.Author] += book.Price;
				}
			}
			
			return authorDictionary;
		}
	}
}
