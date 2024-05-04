using System.Globalization;
using System.Text;
using Z.EntityFramework.Plus;

namespace BookShop;

using BookShop.Models.Enums;
using Data;
using Microsoft.EntityFrameworkCore;

public class StartUp
{
    public static void Main()
    {
        using var db = new BookShopContext();
        //DbInitializer.ResetDatabase(db);

        //task 02
        //string? command = Console.ReadLine();
        //Console.WriteLine(GetBooksByAgeRestriction(db, command));

        //task 03
        //Console.WriteLine(GetGoldenBooks(db));

        //task 04
        //Console.WriteLine(GetBooksByPrice(db));

        //task 05
        //int year = int.Parse(Console.ReadLine());
        //Console.WriteLine(GetBooksNotReleasedIn(db, year));

        //task 06
        //string input = Console.ReadLine();
        //Console.WriteLine(GetBooksByCategory(db, input));


        //task 07
        //string date = Console.ReadLine();
        //Console.WriteLine(GetBooksReleasedBefore(db, date));

        //task 08
        //string input = Console.ReadLine();
        //Console.WriteLine(GetAuthorNamesEndingIn(db, input));

        //task 09
        string input = Console.ReadLine();
        Console.WriteLine(GetBookTitlesContaining(db, input));

        //task 10
        //string input = Console.ReadLine();
        //Console.WriteLine(GetBooksByAuthor(db, input));

        //task 11
        //int length = int.Parse(Console.ReadLine());
        //Console.WriteLine($"There are {CountBooks(db, length)} books with longer title than {length} symbols");

        //task 12
        //Console.WriteLine(CountCopiesByAuthor(db));

        //task 13
        //Console.WriteLine(GetTotalProfitByCategory(db));

        //task 14
        //Console.WriteLine(GetMostRecentBooks(db));

        //task 15
        //IncreasePrices(db);

        //task 16
        //Console.WriteLine(RemoveBooks(db));

    }

    //task 02
    public static string GetBooksByAgeRestriction(BookShopContext context, string command)
    {
        try
        {
            AgeRestriction commandEnum = (AgeRestriction)Enum.Parse(typeof(AgeRestriction), command, true);
            var books = context.Books
                .AsNoTracking()
                .Where(b => b.AgeRestriction == commandEnum)
                .OrderBy(b => b.Title)
                .Select(b => b.Title)
                .ToArray();

            return string.Join(Environment.NewLine, books);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

        return null;
    }

    //task 03
    public static string GetGoldenBooks(BookShopContext context)
    {
        EditionType goldenEdition = EditionType.Gold;
        var books = context.Books
            .AsNoTracking()
            .Where(b => b.EditionType == goldenEdition && b.Copies < 5_000)
            .OrderBy(b => b.BookId)
            .Select(b => b.Title)
            .ToArray();

        return string.Join(Environment.NewLine, books);
    }

    //task 04
    public static string GetBooksByPrice(BookShopContext context)
    {
        var books = context.Books
            .AsNoTracking()
            .Where(b => b.Price > 40)
            .OrderByDescending(b => b.Price)
            .Select(b => new
            {
                b.Title,
                Price = $"${b.Price:F2}"
            })
            .ToArray();

        StringBuilder sb = new StringBuilder();

        foreach (var book in books)
        {
            sb.AppendLine($"{book.Title} - {book.Price}");
        }

        return sb.ToString().TrimEnd();
    }

    //task 05
    public static string GetBooksNotReleasedIn(BookShopContext context, int year)
    {
        var books = context.Books
            .AsNoTracking()
            .Where(b => b.ReleaseDate.Value.Year != year)
            .OrderBy(b => b.BookId)
            .Select(b => b.Title)
            .ToArray();

        return string.Join(Environment.NewLine, books);
    }

    //task 06
    public static string GetBooksByCategory(BookShopContext context, string input)
    {
        //ToLower of the input must be inside the method because unit test of Judge will fail
        string[] categories = input
            .ToLower()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .ToArray();

        var books = context.Books
            .AsNoTracking()
            .Where(b => b.BookCategories
                .Any(bc => categories
                    .Contains(bc.Category.Name.ToLower())))
            .OrderBy(b => b.Title)
            .Select(b => b.Title)
            .ToArray();

        return string.Join(Environment.NewLine, books);
    }

    //task 07
    public static string GetBooksReleasedBefore(BookShopContext context, string date)
    {
        DateTime resultDate = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None);

        var books = context.Books
            .AsNoTracking()
            .Where(b => b.ReleaseDate < resultDate)
            .OrderByDescending(b => b.ReleaseDate)
            .Select(b => new
            {
                b.Title,
                b.EditionType,
                Price = $"${b.Price:F2}"
            })
            .ToArray();

        StringBuilder sb = new StringBuilder();

        foreach (var book in books)
        {
            sb.AppendLine($"{book.Title} - {book.EditionType} - {book.Price}");
        }

        return sb.ToString().TrimEnd();
    }

    //task 08 
    public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
    {
        var authors = context.Authors
            .AsNoTracking()
            .Where(a => a.FirstName.EndsWith(input))
            .Select(a => new
            {
                FullName = $"{a.FirstName} {a.LastName}"
            })
            .Select(fn => fn.FullName)
            .OrderBy(fn => fn)
            .ToArray();

        return string.Join(Environment.NewLine, authors);
    }

    //task 09
    public static string GetBookTitlesContaining(BookShopContext context, string input)
    {
        var titles = context.Books
            .AsNoTracking()
            .Where(b => b.Title.ToLower().Contains(input.ToLower()))
            .OrderBy(b => b.Title)
            .Select(b => b.Title)
            .ToArray();

        return string.Join(Environment.NewLine, titles);
    }

    //task 10
    public static string GetBooksByAuthor(BookShopContext context, string input)
    {
        var books = context.Books
            .AsNoTracking()
            .Where(b => b.Author.LastName.ToLower().StartsWith(input.ToLower()))
            .OrderBy(b => b.BookId)
            .Select(b => new
            {
                b.Title,
                b.Author.FirstName,
                b.Author.LastName
            })
            .Select(b => $"{b.Title} ({b.FirstName} {b.LastName})")
            .ToArray();

        return string.Join(Environment.NewLine, books);
    }

    //task 11
    public static int CountBooks(BookShopContext context, int lengthCheck)
    {
        int count = context.Books
            .Count(b => b.Title.Length > lengthCheck);

        return count;
    }

    //task 12
    public static string CountCopiesByAuthor(BookShopContext context)
    {
        var copiesAuthors = context.Authors
            .AsNoTracking()
            .Select(a => new
            {
                a.FirstName,
                a.LastName,
                CopyCount = a.Books.Sum(b => b.Copies)
            })
            .OrderByDescending(a => a.CopyCount)
            .Select(ca => $"{ca.FirstName} {ca.LastName} - {ca.CopyCount}")
            .ToArray();

        return string.Join(Environment.NewLine, copiesAuthors);
    }

    //task 13
    public static string GetTotalProfitByCategory(BookShopContext context)
    {
        var categoriesProfits = context.Categories
            .AsNoTracking()
            .Select(c => new
            {
                c.Name,
                Profit = c.CategoryBooks.Sum(cb => cb.Book.Copies * cb.Book.Price)
            })
            .OrderByDescending(cp => cp.Profit)
            .ThenBy(cp => cp.Name)
            .Select(cp => $"{cp.Name} ${cp.Profit:F2}")
            .ToArray();

        return string.Join(Environment.NewLine, categoriesProfits);
    }

    //task 14
    public static string GetMostRecentBooks(BookShopContext context)
    {
        var categoriesRecentBooks = context.Categories
            .AsNoTracking()
            .OrderBy(c => c.Name)
            .Select(c => new
            {
                c.Name,
                c.CategoryId,
                MostRecentBooks = c.CategoryBooks
                    .Where(bc => bc.CategoryId == c.CategoryId)
                    .OrderByDescending(b => b.Book.ReleaseDate)
                    .Take(3)
                    .Select(b => new
                    {
                        BookTitle = b.Book.Title,
                        ReleaseYear = b.Book.ReleaseDate.Value.Year
                    })
                    .ToArray()
            })
            .ToArray();

        StringBuilder sb = new StringBuilder();

        foreach (var category in categoriesRecentBooks)
        {
            sb.AppendLine($"--{category.Name}");

            foreach (var book in category.MostRecentBooks)
            {
                sb.AppendLine($"{book.BookTitle} ({book.ReleaseYear})");
            }
        }

        return sb.ToString().TrimEnd();
    }

    //task 15
    public static void IncreasePrices(BookShopContext context)
    {
        //apparently judge is not happy about batch update even tho it was present in the lecture
        var books = context.Books
            .Where(b => b.ReleaseDate.Value.Year < 2010)
            .ToArray();

        foreach (var book in books)
        {
            book.Price += 5;
        }

        context.SaveChanges();
    }

    //task 16
    public static int RemoveBooks(BookShopContext context)
    {
        //again not using batch delete because of Judge

        var books = context.Books
            .Where(b => b.Copies < 4_200)
            .ToArray();

        context.RemoveRange(books);
        context.SaveChanges();
        return books.Length;
    }
}


