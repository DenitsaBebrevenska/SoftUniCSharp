namespace Singleton
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Who are you?");
            string name = Console.ReadLine();
            LoggedUserSingleton loggedUser = LoggedUserSingleton.Instance;
            LoggedUserSingleton.Instance.Name = name;
            Console.WriteLine($"{LoggedUserSingleton.Instance.Name} is logged in");
        }
    }
}
