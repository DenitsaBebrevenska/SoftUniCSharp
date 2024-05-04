using System.Globalization;
using System.Text;

namespace BookShop;

using BookShop.Models.Enums;
using Data;
using Initializer;
using Microsoft.EntityFrameworkCore;

public class StartUp
{
    public static void Main()
    {
        using var db = new BookShopContext();
        DbInitializer.ResetDatabase(db);

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
        //string input = Console.ReadLine().ToLower();
        //Console.WriteLine(GetBooksByCategory(db, input));

        //task 07
        //string date = Console.ReadLine();
        //Console.WriteLine(GetBooksReleasedBefore(db, date));

        //task 08
        //string input = Console.ReadLine();
        //Console.WriteLine(GetAuthorNamesEndingIn(db, input));
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
        string[] categories = input
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .ToArray();

        var books = context.Books
            .AsNoTracking()
            .Where(b => b.BookCategories.Any(c => categories.Contains(c.Category.Name.ToLower())))
            .Select(b => b.Title)
            .OrderBy(t => t)
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
}


