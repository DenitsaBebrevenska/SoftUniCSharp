namespace ShoppingSpree
{
	internal class Program
	{
		static void Main()
		{
			string[] people = Console.ReadLine().Split(';',StringSplitOptions.RemoveEmptyEntries);
			string[] products = Console.ReadLine().Split(';',StringSplitOptions.RemoveEmptyEntries);
			List<Person> peopleList = new List<Person>();

			for (int i = 0; i < people.Length; i++)
			{
				string[] details = people[i].Split("=");
				string personName = details[0];
				int money = int.Parse(details[1]);
				peopleList.Add(new Person(personName, money));
			}

			List<Product> productsList = new List<Product>();
			for (int i = 0; i < products.Length; i++)
			{
				string[] details = products[i].Split("=");
				string productName = details[0];
				int price = int.Parse(details[1]);
				productsList.Add(new Product(productName, price));
			}

			string input;
			while ((input = Console.ReadLine()) != "END")
			{
				string[] commandDetails = input.Split();
				string personName = commandDetails[0];
				string productName = commandDetails[1];

				UpdatePersonsList(peopleList,productsList,personName,productName);
			}
			PrintResult(peopleList);
		}

		static void UpdatePersonsList(List<Person> peopleList, List<Product>productsList, string personName, string productName)
		{
			Person currentPerson = peopleList.FirstOrDefault(p => p.Name == personName);
			Product currentProduct = productsList.FirstOrDefault(p => p.Name == productName);

			if (currentProduct.Price > currentPerson.Money)
			{
				Console.WriteLine($"{currentPerson.Name} can't afford {currentProduct.Name}");
				return;
			}
			currentPerson.Money -= currentProduct.Price;
			currentPerson.Products.Add(currentProduct);
			Console.WriteLine($"{currentPerson.Name} bought {currentProduct.Name}");
		}

		static void PrintResult(List<Person> peopleList)
		{
			
			foreach (Person person in peopleList)
			{
				if (person.Products.Count == 0)
				{
					Console.WriteLine($"{person.Name} - Nothing bought");
				}
				else
				{
					List<string> products = person.Products.Select(p => p.Name).ToList();
					Console.WriteLine($"{person.Name} - {string.Join(", ", products)}");
				}
			}
		}
	}

}