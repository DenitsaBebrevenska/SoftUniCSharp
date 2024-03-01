using CollectionHierarchy.Contracts;

namespace CollectionHierarchy
{
    internal class StartUp
    {
        static void Main()
        {
            AddCollection addCollection = new AddCollection();
            AddRemoveCollection addRemoveCollection = new AddRemoveCollection();
            MyList myList = new MyList();
            List<IAddCollection> addCollections = new List<IAddCollection> { addCollection, addRemoveCollection, myList };

            string[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < addCollections.Count; i++)
            {
                for (int j = 0; j < input.Length; j++)
                {
                    Console.Write(addCollections[i].Add(input[j]) + " ");
                }

                Console.WriteLine();
            }

            List<IAddRemoveCollection> removeCollections = new List<IAddRemoveCollection> { addRemoveCollection, myList };
            int removeCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < removeCollections.Count; i++)
            {
                for (int j = 0; j < removeCount; j++)
                {
                    Console.Write(removeCollections[i].Remove() + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
