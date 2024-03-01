namespace ExplicitInterfaces
{
    public class StartUp
    {
        static void Main()
        {
            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] citizenDetails = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                Citizen citizen = new(citizenDetails[0]);
                IPerson person = citizen;
                IResident resident = citizen;
                Console.WriteLine(person.GetName());
                Console.WriteLine(resident.GetName());
            }
        }
    }
}
