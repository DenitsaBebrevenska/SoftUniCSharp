namespace DateModifier
{
    internal class StartUp
    {
        static void Main()
        {
            string firstDate = Console.ReadLine();
            string secondDate = Console.ReadLine();

            Console.WriteLine(DateModifier.GetDifferenceInDays(firstDate, secondDate));
        }
    }
}
