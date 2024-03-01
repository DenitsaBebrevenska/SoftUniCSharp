namespace GenericScale
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            EqualityScale<int> scale = new EqualityScale<int>(1, 1);
            Console.WriteLine(scale.AreEqual());

            EqualityScale<int> scale2 = new EqualityScale<int>(2, 3);
            Console.WriteLine(scale2.AreEqual());
        }
    }
}
