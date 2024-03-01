namespace BirthdayCelebrations
{
    public class Pet : ILiving
    {
        public string Name { get; }
        public string Birthdate { get; }

        public Pet(string name, string birthdate)
        {
            Name = name;
            Birthdate = birthdate;
        }
    }
}
