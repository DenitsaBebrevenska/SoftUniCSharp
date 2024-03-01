namespace Zoo
{
    public class StartUp
    {
        static void Main()
        {
            Animal animal = new("Rory");
            Console.WriteLine(animal.Name);
            Reptile reptile = new("Speedy");
            Console.WriteLine(reptile.Name);
            Gorilla gorilla = new("Elizabeth");
            Console.WriteLine(gorilla.Name);
        }
    }
}
