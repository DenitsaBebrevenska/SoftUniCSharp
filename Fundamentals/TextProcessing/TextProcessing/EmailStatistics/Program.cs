using System.Text.RegularExpressions;

namespace EmailStatistics
{
	internal class Program
	{
		static void Main()
		{
			List<Domain> domainList = new List<Domain>();
			byte emailCount = byte.Parse(Console.ReadLine());
			string patternValidEmails = @"^(?<username>[A-Za-z]{5,})@(?<domain>[a-z]{3,}\.(com|org|bg))$";

			for (int i = 0; i < emailCount; i++)
			{
				string email = Console.ReadLine();
				Match matchEmail = Regex.Match(email, patternValidEmails);

				if (!matchEmail.Success)
				{
					continue;
				}

				string username = matchEmail.Groups["username"].Value;
				string domain = matchEmail.Groups["domain"].Value;
				Domain currentDomain = domainList.FirstOrDefault(d => d.Name == domain);

				if (currentDomain == null)
				{
					currentDomain = new Domain(domain)
					{
						Usernames = new List<string>()
					{
						username
					}
					};

					domainList.Add(currentDomain);
					continue;
				}

				if (currentDomain.Usernames.Contains(username))
				{
					continue;
				}

				currentDomain.Usernames.Add(username);
			}

			foreach (Domain domain in domainList.OrderByDescending(d => d.Usernames.Count))
			{
				Console.WriteLine(domain);
			}
		}
	}

	internal class Domain
	{
		public string Name { get; set; }

		public List<string> Usernames { get; set; }

		public Domain(string name)
		{
			Name = name;
			Usernames = new List<string>();
		}

		public override string ToString()
		{
			return $"{Name}:\n### {string.Join("\n### ",Usernames)}";
		}
	}
}
