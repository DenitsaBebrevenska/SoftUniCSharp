namespace Shapes
{
    public class StartUp
    {
        static void Main()
        {
            //a typo in perimeter made me solve this problem 100 x times longer than it should have....
            Shape shape = new Rectangle(3, 2);
            Console.WriteLine($"{shape.CalculateArea():F2}");
            Console.WriteLine($"{shape.CalculatePerimeter():F2}");
            Console.WriteLine(shape.Draw());

            shape = new Circle(3);
            Console.WriteLine($"{shape.CalculateArea():F2}");
            Console.WriteLine($"{shape.CalculatePerimeter():F2}");
            Console.WriteLine(shape.Draw());
        }
    }
}
