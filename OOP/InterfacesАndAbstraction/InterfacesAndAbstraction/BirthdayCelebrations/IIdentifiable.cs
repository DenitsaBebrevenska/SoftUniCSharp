namespace BirthdayCelebrations
{
    public interface IIdentifiable
    {
        public string Id { get; }

        bool HasValidId(string fakeIdFilter);
    }
}
