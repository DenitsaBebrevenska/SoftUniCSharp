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
        //Console.WriteLine(GetBooksByAgeRestriction(db, command.ToLower()));

        //task 03
        //Console.WriteLine(GetGoldenBooks(db));
    }

    //task 02
    public static string GetBooksByAgeRestriction(BookShopContext context, string command)
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
}


