namespace CommandPatternLab;

public class Program
{
    public static void Main()
    {
        var modifyPrice = new ModifyPrice();
        var product = new Product("Cheese", 20);

        Execute(product, modifyPrice, new ProductCommand(product, PriceAction.Increase, 20));

        Execute(product, modifyPrice, new ProductCommand(product, PriceAction.Decrease, 30));

        Console.WriteLine(product);
    }

    private static void Execute(Product product, ModifyPrice modifyPrice, ICommand productCommand)
    {
        modifyPrice.SetCommand(productCommand);
        modifyPrice.Invoke();
    }
}



