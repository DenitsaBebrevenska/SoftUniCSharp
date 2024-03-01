using CollectionHierarchy.Contracts;

namespace CollectionHierarchy
{
    public class MyList : IMyList
    {
        private List<string> collection = new();
        public int Add(string item)
        {
            collection.Insert(0, item);
            return 0;
        }

        public string Remove()
        {
            if (collection.Count > 0)
            {
                string returnString = collection[0];
                collection.RemoveAt(0);
                return returnString;
            }

            return default;
        }

        public int Used => collection.Count;
    }
}
