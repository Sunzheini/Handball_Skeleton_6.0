using Handball.Models.Contracts;
using Handball.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Handball.Models
{
    public class Team : ITeam
    {
        // --------------------------------------------------------
        // Fields
        // --------------------------------------------------------
        private string name;
        private int pointsEarned;
        private double overallRating;
        private List<IPlayer> players;

        // --------------------------------------------------------
        // Constructors
        // --------------------------------------------------------
        public Team(string name)
        {
            Name = name;
            PointsEarned = 0;
        }

        // --------------------------------------------------------
        // Getters and Setters
        // --------------------------------------------------------
        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.TeamNameNull);
                }
                name = value;
            }
        }

        public int PointsEarned
        {
            get => pointsEarned;
            private set
            {
                pointsEarned = value;
            }
        }

        private double GetAverageRatingOfAllPlayers()
        {
            if (players.Count == 0)
            {
                return 0;
            }

            return Math.Round(players.Average(p => p.Rating), 2);
        }

        public double OverallRating
        {
            get => GetAverageRatingOfAllPlayers();
        }

        public IReadOnlyCollection<IPlayer> Players
        {
            get => players.AsReadOnly();
        }

        // --------------------------------------------------------
        // Methods
        // --------------------------------------------------------
        private void IncreaseRatingOfAllPlayers()
        {
            foreach (var player in players)
            {
                player.IncreaseRating();
            }
        }

        private void DecreaseRatingOfAllPlayers()
        {
            foreach (var player in players)
            {
                player.DecreaseRating();
            }
        }

        private void IncreaseRatingOfGoalKeeper()
        {
            IPlayer goalkeeper = players.FirstOrDefault(p => p is Goalkeeper);

            if (goalkeeper != null)
            {
                goalkeeper.IncreaseRating();
            }
        }

        public void Win()
        {
            PointsEarned += 3;
            IncreaseRatingOfAllPlayers();
        }

        public void Lose()
        {
            DecreaseRatingOfAllPlayers();
        }

        public void Draw()
        {
            PointsEarned += 1;
            IncreaseRatingOfGoalKeeper();
        }

        public void SignContract(IPlayer player)
        {
            if (player != null)
            {
                players.Add(player);
            }
        }

        // --------------------------------------------------------
        // Overrides
        // --------------------------------------------------------
        public override string ToString()
        {
            string playerNames = "none";
            if (players.Count > 0)
            {
                playerNames = string.Join(", ", players.Select(p => p.Name));
            }

            StringBuilder result = new StringBuilder();

            result.AppendLine($"Team: {Name} Points: {PointsEarned}");
            result.AppendLine($"--Overall rating: {OverallRating}");
            result.AppendLine($"--Players: {playerNames}");

            return result.ToString().Trim();
        }
    }
}
