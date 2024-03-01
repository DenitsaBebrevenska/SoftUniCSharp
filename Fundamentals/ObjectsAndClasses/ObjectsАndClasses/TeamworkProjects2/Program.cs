namespace TeamworkProjects2
{
	internal class Program
	{
		static void Main() //my first code without finding out most of the LINQ and with two classes...
		{
			int teamsCount = int.Parse(Console.ReadLine());
			List<Team> teams = new List<Team>();
			for (int i = 0; i < teamsCount; i++)
			{
				string[] teamCreationDetails = Console.ReadLine().Split('-');
				string creator = teamCreationDetails[0];
				string teamName = teamCreationDetails[1];

				if (TeamExists(teams, teamName))
				{
					Console.WriteLine($"Team {teamName} was already created!");
					continue;
				}

				if (UserIsCreator(teams, creator))
				{
					Console.WriteLine($"{creator} cannot create another team!");
					continue;
				}

				teams.Add(new Team(creator, teamName));
				Console.WriteLine($"Team {teamName} has been created by {creator}!");
			}

			string input;
			while ((input = Console.ReadLine()) != "end of assignment")
			{
				string[] membershipApprovalDetails = input.Split("->");
				string user = membershipApprovalDetails[0];
				string teamName = membershipApprovalDetails[1];

				if (!TeamExists(teams, teamName))
				{
					Console.WriteLine($"Team {teamName} does not exist!");
					continue;
				}

				if (IsAMember(teams, user) || UserIsCreator(teams, user))
				{
					Console.WriteLine($"Member {user} cannot join team {teamName}!");
					continue;
				}

				AddMember(teams, teamName, user);
			}
			PrintValidTeams(teams);
			PrintTeamsToDisband(teams);
		}

		static void PrintValidTeams(List<Team> teams)
		{
			foreach (Team team in teams.OrderByDescending(t => t.Members.Count).
				         ThenBy(t => t.Name).Where(t => t.Members.Count > 0))
			{
				Console.WriteLine(team.Name);
				Console.WriteLine($"- {team.Creator}");
				foreach (Member member in team.Members.OrderBy(m => m.Name))
				{
					Console.WriteLine($"-- {member.Name}");
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

		static bool UserIsCreator(List<Team> teams, string creator) 
		{
			foreach (Team team in teams.Where(t => t.Creator == creator))
			{
				return true;
			}
			return false;
		}

		static void AddMember(List<Team> teams, string teamName, string user)
		{
			Team selectedTeam = teams.Find(t => t.Name == teamName);
			Member currentMember = new Member(user);
			selectedTeam.Members.Add(currentMember);
		}

		static bool TeamExists(List<Team> teams, string teamName)
		{
			foreach (Team team in teams.Where(t => t.Name == teamName))
			{
				return true;
			}
			return false;
		}

		static bool IsAMember(List<Team> teams, string name)
		{
			foreach (Team team in teams)
			{
				List<Member> teamMembers = team.Members;

				foreach (Member member in teamMembers.Where(m => m.Name == name))
				{
					return true;
				}
			}
			return false;
		}
	}
}