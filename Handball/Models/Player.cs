using Handball.Models.Contracts;
using Handball.Utilities.Messages;
using System;
using System.Text;


namespace Handball.Models
{
    public abstract class Player : IPlayer
    {
        // --------------------------------------------------------
        // Fields
        // --------------------------------------------------------
        private string name;
        private double rating;
        private string team;

        private int maximumRatingValue = 10;
        private int minimumRatingValue = 1;

        // --------------------------------------------------------
        // Constructors
        // --------------------------------------------------------
        public Player(string name, double rating)
        {
            this.Name = name;
            this.Rating = rating;
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
                    throw new ArgumentException(ExceptionMessages.PlayerNameNull);
                }
                name = value;
            }
        }

        public double Rating
        {
            get => rating;
            protected set
            {
                if (value < minimumRatingValue || value > maximumRatingValue)
                {
                    return;
                }
                else
                {
                    rating = value;
                }
            }
        }

        public string Team
        {
            get => team;
        }

        // --------------------------------------------------------
        // Methods
        // --------------------------------------------------------
        public abstract void IncreaseRating();

        public abstract void DecreaseRating();

        public void JoinTeam(string name)
        {
            this.team = name;
        }

        // --------------------------------------------------------
        // Overrides
        // --------------------------------------------------------
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine($"{this.GetType().Name}: {this.Name}");
            result.AppendLine($"--Rating: {this.Rating}");

            return result.ToString().TrimEnd();
        }
    }
}
