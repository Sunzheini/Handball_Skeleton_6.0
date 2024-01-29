using Handball.Models.Contracts;
using Handball.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;


namespace Handball.Models
{
    public class Team : ITeam
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            private set {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.TeamNameNull);
                }
                _name = value;
            }
        }

        private int _pointsEarned = 0;

        public int PointsEarned
        {
            get { return _pointsEarned; }
            private set { _pointsEarned = value; }
        }

        private double _overallRating;

        public double OverallRating
        {
            get 
            {
                if (Players.Count == 0)
                {
                    return 0;
                }
                else
                {
                    double average = 0;
                    foreach (var player in Players)
                    {
                        average += player.Rating;
                    }
                    average /= Players.Count;
                    return Math.Round(average, 2);
                }
            }
        }

        private readonly List<IPlayer> _players;

        public List<IPlayer> Players
        {
            get { return _players; }
        }

        public void Draw()
        {
            this.PointsEarned += 1;

            IPlayer goalkeeper = _players.First(p => p is Goalkeeper);

            if (goalkeeper != null)
            {
                goalkeeper.IncreaseRating();
            }
        }

        public void Lose()
        {
            foreach (var player in this._players)
            {
                player.DecreaseRating();
            }
        }

        public void SignContract(IPlayer player)
        {
            this.Players.Add(player);
        }

        public void Win()
        {
            this.PointsEarned += 3;

            foreach (var player in this._players)
            {
                player.IncreaseRating();
            }
        }

        private string FormattedPlayerList
        {
            get
            {
                if (Players.Count == 0)
                {
                    return "none";
                }
                else
                {
                    string playerList = string.Join(", ", Players.Select(player => player.Name));
                    return playerList;
                }
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine($"Team: {Name} Points: {PointsEarned}");
            result.AppendLine($"--Overall rating: {OverallRating}");
            result.AppendLine($"--Players: {this.FormattedPlayerList}");

            return result.ToString().Trim();
        }

        public Team(string name)
        {
            this.Name = name;
            this._players = new List<IPlayer>();
        }
    }
}
