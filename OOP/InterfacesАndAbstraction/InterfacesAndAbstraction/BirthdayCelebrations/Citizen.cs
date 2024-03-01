namespace BirthdayCelebrations
{
    public class Citizen : IIdentifiable, ILiving
    {
        public Citizen(string name, int age, string id, string birthdate)
        {
            Name = name;
            Age = age;
            Id = id;
            Birthdate = birthdate;
        }

        public string Id { get; }
        public string Name { get; }
        public string Birthdate { get; }
        public int Age { get; }

        public bool HasValidId(string fakeIdFilter) => !Id.EndsWith(fakeIdFilter);
    }
}
