namespace ProductShop
{
    internal class Program
    {
        static void Main()
        {
            SortedDictionary<string, Dictionary<string, double>> shopsDictionary =
                new SortedDictionary<string, Dictionary<string, double>>();
            //must use nested dictionaries
            string input;

            while ((input = Console.ReadLine()) != "Revision")
            {
                string[] shopDetails = input.Split(", ");
                string shopName = shopDetails[0];
                string productName = shopDetails[1];
                double productPrice = double.Parse(shopDetails[2]);

                if (!shopsDictionary.ContainsKey(shopName))
                {
                    shopsDictionary.Add(shopName, new Dictionary<string, double>());
                }

                shopsDictionary[shopName].Add(productName, productPrice);
            }

            foreach (var kvp in shopsDictionary)
            {
                Console.WriteLine($"{kvp.Key}->");

                foreach (var kvp2 in kvp.Value)
                {
                    Console.WriteLine($"Product: {kvp2.Key}, Price: {kvp2.Value}");
                }
            }
        }
    }
}
