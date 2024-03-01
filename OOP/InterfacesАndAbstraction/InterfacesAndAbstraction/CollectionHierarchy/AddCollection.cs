using CollectionHierarchy.Contracts;

namespace CollectionHierarchy
{
    public class AddCollection : IAddCollection
    {
        private List<string> collection = new(100);
        public int Add(string item)
        {
            collection.Add(item);
            return collection.Count - 1;
        }
    }
}
