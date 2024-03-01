using System.Globalization;

namespace BookLibraryModification
{
	internal class Program
	{
		static void Main()
		{
			byte numberOfLines = byte.Parse(Console.ReadLine());
			List<Book> books = PopulateBookList(numberOfLines);
			string date = Console.ReadLine();
			DateTime dateToCompare = DateTime.ParseExact(date, "dd.MM.yyyy", CultureInfo.InvariantCulture);

			foreach (Book book in books.Where(b => b.ReleaseDate > dateToCompare).
				         OrderBy(b => b.ReleaseDate).
				         ThenBy(b => b.Title))
			{
				Console.WriteLine($"{book.Title} -> {book.ReleaseDate.Day:D2}.{book.ReleaseDate.Month:D2}.{book.ReleaseDate.Year}");
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
					Title = bookName,
					Author = bookAuthor,
					Publisher = bookPublisher,
					ISBN = bookISBN,
					Price = bookPrice,
					ReleaseDate = bookPublishDate
				});
			}

			return books;
		}
	}
}
