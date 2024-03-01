namespace BirthdayCelebrations
{
    public class Robot : IIdentifiable
    {
        public string Id { get; }
        public string Model { get; }

        public Robot(string model, string id)
        {
            Model = model;
            Id = id;
        }

        public bool HasValidId(string fakeIdFilter) => !Id.EndsWith(fakeIdFilter);
    }
}
