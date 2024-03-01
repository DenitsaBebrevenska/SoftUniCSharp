namespace TeamworkProjects
{
	internal class Program
	{
		static void Main()
		{
			int teamsCount = int.Parse(Console.ReadLine());
			List<Team> teams = new List<Team>();
			for (int i = 0; i < teamsCount; i++)
			{
				string[] teamCreationDetails = Console.ReadLine().Split('-');
				string creator = teamCreationDetails[0];
				string teamName = teamCreationDetails[1];

				Team currentTeam = new Team(creator, teamName);
				if (teams.Select(t => t.Name).Contains(currentTeam.Name))
				{
					Console.WriteLine($"Team {teamName} was already created!");
					continue;
				}

				if (teams.Select(t => t.Creator).Contains(currentTeam.Creator))
				{
					Console.WriteLine($"{creator} cannot create another team!");
					continue;
				}

				teams.Add(currentTeam);
				Console.WriteLine($"Team {teamName} has been created by {creator}!");
			}

			string input;
			while ((input = Console.ReadLine()) != "end of assignment")
			{
				string[] membershipApprovalDetails = input.Split("->");
				string user = membershipApprovalDetails[0];
				string teamName = membershipApprovalDetails[1];

				if (!teams.Select(t => t.Name).Contains(teamName))
				{
					Console.WriteLine($"Team {teamName} does not exist!");
					continue;
				}

				if (teams.Any(t => t.Members.Contains(user)) || teams.Any(t => t.Creator == user))
				{
					Console.WriteLine($"Member {user} cannot join team {teamName}!");
					continue;
				}

				teams.Find(t => t.Name == teamName).Members.Add(user);
			}
			PrintValidTeams(teams);
			PrintTeamsToDisband(teams);
		}

		static void PrintValidTeams(List<Team> teams)
		{
			foreach (Team team in teams.OrderByDescending(t => t.Members.Count).
				         ThenBy(t => t.Name).
				         Where(t => t.Members.Count > 0))
			{
				Console.WriteLine(team.Name);
				Console.WriteLine($"- {team.Creator}");
				foreach (string member in team.Members.OrderBy(m => m))
				{
					Console.WriteLine($"-- {member}");
				}
			}
		}

		static void PrintTeamsToDisband(List<Team> teams)
		{
			Console.WriteLine("Teams to disband:");
			foreach (Team team in teams.OrderBy(t => t.Name).Where(t => t.Members.Count == 0))
			{
				Console.WriteLine(team.Name);
			}
		}
	}

}