using CollectionHierarchy.Contracts;

namespace CollectionHierarchy
{
    public class AddRemoveCollection : IAddRemoveCollection
    {
        private List<string> collection = new(100);
        public int Add(string item)
        {
            collection.Insert(0, item);
            return 0;
        }

        public string Remove()
        {
            if (collection.Count > 0)
            {
                string returnString = collection[^1];
                collection.RemoveAt(collection.Count - 1);
                return returnString;
            }

            return default;
        }
    }
}
