namespace BorderControl
{
    public class Citizen : IIdentifiable
    {
        public string Id { get; }
        public string Name { get; }
        public int Age { get; }

        public Citizen(string name, int age, string id)
        {
            Name = name;
            Age = age;
            Id = id;
        }

        public bool HasValidId(string fakeIdFilter) => !Id.EndsWith(fakeIdFilter);

    }
}
