using Handball.Core.Contracts;
using Handball.Models;
using Handball.Models.Contracts;
using Handball.Models.Players;
using Handball.Repositories;
using Handball.Repositories.Contracts;
using Handball.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Handball.Core
{
    public class Controller : IController
    {
        private IRepository<IPlayer> _playerRepository;
        private IRepository<ITeam> _teamRepository;

        public Controller()
        {
            _playerRepository = new PlayerRepository();
            _teamRepository = new TeamRepository();
        }
        public string NewTeam(string name)
        {
            if (_teamRepository.ExistsModel(name))
            {
                return string.Format(OutputMessages.TeamAlreadyExists, name, _teamRepository.GetType().Name);
            }

            _teamRepository.AddModel(new Team(name));

            return string.Format(OutputMessages.TeamSuccessfullyAdded, name, _teamRepository.GetType().Name);
        }

        public string NewPlayer(string typeName, string name)
        {
            var children = Assembly.GetAssembly(typeof(Player))
                .GetTypes()
                .Where(t => !t.IsAbstract && t.IsClass && typeof(Player).IsAssignableFrom(t))
                .Select(t => t.Name);

            if (!children.Contains(typeName))
            {
                return string.Format(OutputMessages.InvalidTypeOfPosition, typeName);
            }

            if (_playerRepository.ExistsModel(name))
            {
                return string.Format(OutputMessages.PlayerIsAlreadyAdded, name, _playerRepository.GetType().Name,
                    typeName);
            }

            Type type = Assembly
                .GetAssembly(typeof(Player))
                .GetTypes().First(t => !t.IsAbstract && t.IsClass && typeof(Player).IsAssignableFrom(t) && t.Name == typeName);
            ConstructorInfo constructor = type.GetConstructor(new Type[] { typeof(string) });
            object instance = constructor.Invoke(new object[] { name });
            IPlayer player = instance as IPlayer;
            _playerRepository.AddModel(player);

            return string.Format(OutputMessages.PlayerAddedSuccessfully, name);
        }

        public string NewContract(string playerName, string teamName)
        {
            if (!_playerRepository.ExistsModel(playerName))
            {
                return string.Format(OutputMessages.PlayerNotExisting, playerName, _playerRepository.GetType().Name);
            }

            if (!_teamRepository.ExistsModel(teamName))
            {
                return string.Format(OutputMessages.TeamNotExisting, teamName, _teamRepository.GetType().Name);
            }

            IPlayer player = _playerRepository.Models.First(p => p.Name == playerName);

            if (player.Team != null)
            {
                return string.Format(OutputMessages.PlayerAlreadySignedContract, playerName, player.Team);
            }

            player.JoinTeam(teamName);

            ITeam team = _teamRepository.Models.First(t => t.Name == teamName);
            team.SignContract(player);
            return string.Format(OutputMessages.SignContract, playerName, teamName);
        }

        public string NewGame(string firstTeamName, string secondTeamName)
        {
            ITeam teamOne = _teamRepository.Models.First(t => t.Name == firstTeamName);
            ITeam teamTwo = _teamRepository.Models.First(t => t.Name == secondTeamName);
            List<ITeam> teams = new List<ITeam>()
            {
                teamOne,
                teamTwo
            };

            if (teamOne.OverallRating.Equals(teamTwo.OverallRating))
            {
                teams.ForEach(t => t.Draw());
                return string.Format(OutputMessages.GameIsDraw, firstTeamName, secondTeamName);
            }

            teams = teams.OrderBy(t => t.OverallRating).ToList();
            teams[0].Lose();
            teams[1].Win();

            return string.Format(OutputMessages.GameHasWinner, teams[1].Name, teams[0].Name);
        }

        public string PlayerStatistics(string teamName)
        {
            StringBuilder statistics = new StringBuilder();
            statistics.AppendLine($"***{teamName}***");
            ITeam team = _teamRepository.Models.First(t => t.Name == teamName);

            foreach (var player in team.Players
                         .OrderByDescending(p => p.Rating)
                         .ThenBy(p => p.Name))
            {
                statistics.AppendLine(player.ToString());
            }

            return statistics.ToString().TrimEnd();
        }

        public string LeagueStandings()
        {
            StringBuilder standings = new StringBuilder();
            standings.AppendLine("***League Standings***");

            foreach (var team in _teamRepository.Models
                         .OrderByDescending(t => t.PointsEarned)
                         .ThenByDescending(t => t.OverallRating)
                         .ThenBy(t => t.Name))
            {
                standings.AppendLine(team.ToString());
            }

            return standings.ToString().TrimEnd();
        }
    }
}
