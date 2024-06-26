using Handball.Core.Contracts;
using Handball.Models;
using Handball.Models.Contracts;
using Handball.Repositories;
using Handball.Repositories.Contracts;
using Handball.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Handball.Core
{
    public class Controller : IController
    {
        // --------------------------------------------------------
        // Fields
        // --------------------------------------------------------
        private IRepository<IPlayer> players;
        private IRepository<ITeam> teams;
        List<string> correctPlayerTypes = new List<string>
            {
                "CenterBack",
                "ForwardWing",
                "Goalkeeper"
            };

        // --------------------------------------------------------
        // Constructors
        // --------------------------------------------------------
        public Controller() 
        { 
            players = new PlayerRepository();
            teams = new TeamRepository();
        }

        // --------------------------------------------------------
        // Methods
        // --------------------------------------------------------


        public IPlayer playerFactory(string typeName, string name)
        {
            IPlayer player = null;

            switch (typeName)
            {
                case "CenterBack":
                    player = new CenterBack(name);
                    break;
                case "ForwardWing":
                    player = new ForwardWing(name);
                    break;
                case "Goalkeeper":
                    player = new Goalkeeper(name);
                    break;
            }

            return player;
        }

        public string NewPlayer(string typeName, string name)
        {
            if (!correctPlayerTypes.Contains(typeName))
            {
                return String.Format(OutputMessages.InvalidTypeOfPosition, typeName);
            }

            if (players.ExistsModel(name))
            {
                return String.Format(OutputMessages.PlayerIsAlreadyAdded, name, players.GetType().Name, typeName);
            }

            IPlayer player = playerFactory(typeName, name);
            players.AddModel(player);
            return String.Format(OutputMessages.PlayerAddedSuccessfully, name);
        }

        public string NewTeam(string name)
        {
            if (teams.ExistsModel(name))
            {
                return String.Format(OutputMessages.TeamAlreadyExists, name, teams.GetType().Name);
            }

            teams.AddModel(new Team(name));
            return String.Format(OutputMessages.TeamSuccessfullyAdded, name, "TeamRepository");
        }

        public string NewContract(string playerName, string teamName)
        {
            if(!players.ExistsModel(playerName))
            {
                return String.Format(OutputMessages.PlayerNotExisting, playerName, players.GetType().Name);
            }

            if (!teams.ExistsModel(teamName))
            {
                return String.Format(OutputMessages.TeamNotExisting, teamName, teams.GetType().Name);
            }

            IPlayer player = players.GetModel(playerName);
            if (player.Team != null)
            {
                return String.Format(OutputMessages.PlayerAlreadySignedContract, playerName, player.Team.Name);
            }

            ITeam teamToSign = teams.GetModel(teamName);
            player.JoinTeam(teamName);
            teamToSign.SignContract(player);

            return String.Format(OutputMessages.SignContract, playerName, teamName);
        }

        public string NewGame(string firstTeamName, string secondTeamName)
        {
            ITeam firstTeam = teams.GetModel(firstTeamName);
            ITeam secondTeam = teams.GetModel(secondTeamName);

            if (firstTeam.OverallRating > secondTeam.OverallRating)
            {
                firstTeam.Win();
                secondTeam.Lose();
                return String.Format(OutputMessages.GameHasWinner, firstTeamName, secondTeamName);
            }
            else if (firstTeam.OverallRating < secondTeam.OverallRating)
            {
                firstTeam.Lose();
                secondTeam.Win();
                return String.Format(OutputMessages.GameHasWinner, secondTeamName, firstTeamName);
            }
            else
            {
                firstTeam.Draw();
                secondTeam.Draw();
                return String.Format(OutputMessages.GameIsDraw, firstTeamName, secondTeamName);
            }
        }

        public string PlayerStatistics(string teamName)
        {
            throw new NotImplementedException();
        }

        public string LeagueStandings()
        {
            throw new NotImplementedException();
        }
    }
}
