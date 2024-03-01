namespace ForeignLanguages
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string country = Console.ReadLine();

			string languauge = "";
			if (country == "England" || country == "USA")
			{
				languauge = "English";
			}
			else if (country == "Spain" || country == "Argentina" || country == "Mexico")
			{
				languauge = "Spanish";
			}
			else  
			{
				languauge = "unknown";
			}
            Console.WriteLine(languauge);
        }
	}
}