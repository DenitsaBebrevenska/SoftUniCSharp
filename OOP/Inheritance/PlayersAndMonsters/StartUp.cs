namespace PlayersAndMonsters
{
    public class StartUp
    {
        static void Main()
        {
            BladeKnight knight = new("Goofy", 10);
            Console.WriteLine(knight);

            Wizard wizard = new("Gandalf", 10100);
            Console.WriteLine(wizard);
        }
    }
}
