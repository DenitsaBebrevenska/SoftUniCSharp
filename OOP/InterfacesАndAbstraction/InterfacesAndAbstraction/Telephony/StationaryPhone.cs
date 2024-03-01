namespace Telephony
{
    public class StationaryPhone : IPhone
    {
        public void Call(string number)
        {
            if (!number.All(char.IsDigit))
            {
                Console.WriteLine("Invalid number!");
                return;
            }

            Console.WriteLine($"Dialing... {number}");
        }
    }
}
