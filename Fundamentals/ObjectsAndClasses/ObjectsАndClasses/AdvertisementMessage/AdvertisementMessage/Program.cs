namespace AdvertisementMessage
{
	internal class Program
	{
		static void Main()
		{
			int inputMessageCount = int.Parse(Console.ReadLine());

			string[] phrases = new string[]
			{
				"Excellent product.", "Such a great product.","I always use that product.", 
				"Best product of its category.", "Exceptional product.", "I can't live without this product."
			};
			string[] events = new string[]
			{
				"Now I feel good.", "I have succeeded with this product.", "Makes miracles. I am happy of the results!", 
				"I cannot believe but now I feel awesome.", "Try it yourself, I am very satisfied.", "I feel great!"
			};
			string[] authors = new string[]
			{
				"Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva"
			};
			string[] cities = new string[]
			{
				"Burgas", "Sofia", "Plovdiv", "Varna", "Ruse"
			};

			for (int i = 0; i < inputMessageCount; i++)
			{
				Console.WriteLine(ConstructRandomMessage(phrases, events, authors, cities));
			}
		}

		static string ConstructRandomMessage(string[] phrases, string[] events, string[] authors, string[] cities)
		{
			Random random = new Random();
			int randomPhrase = random.Next(phrases.Length);
			int randomEvents = random.Next(events.Length);
			int randomAuthors = random.Next(authors.Length);
			int randomCity = random.Next(cities.Length);

			return $"{phrases[randomPhrase]} {events[randomEvents]} {authors[randomAuthors]} - {cities[randomCity]}.";

		}
	}
	}