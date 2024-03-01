namespace GenericCountMethod
{
    public class StartUp
    {
        static void Main()
        {
            int entryCount = int.Parse(Console.ReadLine());
            List<double> list = new List<double>();

            for (int i = 0; i < entryCount; i++)
            {
                list.Add(double.Parse(Console.ReadLine()));
            }

            GenericCount<double> counter = new GenericCount<double>();
            Console.WriteLine(counter.CountGreaterValues(list, double.Parse(Console.ReadLine())));
            
        }
    }
}
