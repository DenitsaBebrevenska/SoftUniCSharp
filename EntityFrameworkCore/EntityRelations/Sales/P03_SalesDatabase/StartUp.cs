using P03_SalesDatabase.Data;

namespace P03_SalesDatabase;

public class StartUp
{
    public static void Main()
    {
        using var context = new SalesContext();
        context.SeedData();
    }
}
