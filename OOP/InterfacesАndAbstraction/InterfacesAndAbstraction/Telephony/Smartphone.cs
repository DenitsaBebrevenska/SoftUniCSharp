namespace Telephony
{
    public class Smartphone : ISmartphone
    {
        public void Call(string number)
        {
            if (!number.All(char.IsDigit))
            {
                Console.WriteLine("Invalid number!");
                return;
            }

            Console.WriteLine($"Calling... {number}");
        }

        public void Browse(string website)
        {
            if (website.Any(char.IsDigit))
            {
                Console.WriteLine("Invalid URL!");
                return;
            }

            Console.WriteLine($"Browsing: {website}!");
        }
    }
}
