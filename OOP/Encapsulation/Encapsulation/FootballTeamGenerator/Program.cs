namespace FootballTeamGenerator
{
    public class Program
    {
        static void Main()
        {
            List<Team> teams = new();

            string command;

            while ((command = Console.ReadLine()) != "END")
            {
                string[] commandArgs = command.Split(';');

                try
                {
                    if (commandArgs[0] == "Team")
                    {
                        teams.Add(new Team(commandArgs[1]));
                        continue;
                    }

                    Team team = teams.FirstOrDefault(t => t.Name == commandArgs[1]);

                    if (commandArgs[0] == "Add")
                    {
                        if (team == null)
                        {
                            Console.WriteLine($"Team {commandArgs[1]} does not exist.");
                            continue;
                        }

                        team.AddPlayer(new Player(commandArgs[2], int.Parse(commandArgs[3]), int.Parse(commandArgs[4]),
                            int.Parse(commandArgs[5]), int.Parse(commandArgs[6]), int.Parse(commandArgs[7])));
                    }
                    else if (commandArgs[0] == "Remove")
                    {
                        Player player = team.Players.FirstOrDefault(p => p.Name == commandArgs[2]);

                        if (player == null)
                        {
                            Console.WriteLine($"Player {commandArgs[2]} is not in {commandArgs[1]} team.");
                            continue;
                        }

                        team.RemovePlayer(commandArgs[2]);
                    }
                    else //Rating
                    {
                        if (team == null)
                        {
                            Console.WriteLine($"Team {commandArgs[1]} does not exist.");
                            continue;
                        }

                        Console.WriteLine(team);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }
        }
    }
}
