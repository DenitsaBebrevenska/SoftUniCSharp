namespace Listy
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] listContent = Console.ReadLine().
                Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Skip(1)
                .ToArray();
            ListyIterator<string> listy = new ListyIterator<string>(listContent);

            string command;

            while ((command = Console.ReadLine()) != "END")
            {
                switch (command)
                {
                    case "Move":
                        Console.WriteLine(listy.Move());
                        break;
                    case "Print":
                        listy.Print();
                        break;
                    case "HasNext":
                        Console.WriteLine(listy.HasNext());
                        break;
                    case "PrintAll":
                        listy.PrintAll();
                        break;
                }
            }

        }
    }
}
