namespace ExplicitInterfaces
{
    public class Citizen : IPerson, IResident
    {
        public Citizen()
        {

        }
        public Citizen(string name)
        {
            Name = name;
        }

        public string Name { get; }
        public string Country { get; }
        public int Age { get; }
        string IResident.GetName() => $"Mr/Ms/Mrs {Name}";

        string IPerson.GetName() => Name;
    }
}
