namespace GenericArrayCreator
{
    public class StartUp
    {
        static void Main()
        {
            string[] arrayOfStrings = ArrayCreator.Create(5, "Gosho");
            Console.WriteLine(string.Join(", ", arrayOfStrings));
            int[] arrayOfNumbers = ArrayCreator.Create(5, 100);
            Console.WriteLine(string.Join(", ", arrayOfNumbers));
        }
    }
}
