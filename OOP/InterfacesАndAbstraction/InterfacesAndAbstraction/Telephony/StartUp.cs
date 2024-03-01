namespace Telephony
{
    public class StartUp
    {
        static void Main()
        {
            string[] phoneNumbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string[] websites = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            IPhone phone;

            foreach (string number in phoneNumbers)
            {
                if (number.Length == 7)
                {
                    phone = new StationaryPhone();
                }
                else
                {
                    phone = new Smartphone();
                }
                phone.Call(number);
            }

            ISmartphone smartPhone = new Smartphone();
            foreach (string website in websites)
            {
                smartPhone.Browse(website);
            }
        }
    }
}
