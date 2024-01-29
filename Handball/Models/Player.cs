using Handball.Models.Contracts;
using Handball.Utilities.Messages;
using System;
using System.Text;


namespace Handball.Models
{
    public abstract class Player : IPlayer
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.PlayerNameNull);
                }
                _name = value;
            }
        }

        private double _rating;

        public double Rating
        {
            get { return _rating; }
            protected set
            {
                if (value < 1 || value > 10)
                {
                    return;
                }
                _rating = value;
            }
        }

        private string _team;

        public string Team
        {
            get { return _team; }
        }

        public abstract void DecreaseRating();

        public abstract void IncreaseRating();

        public void JoinTeam(string name)
        {
            this._team = name;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"{this.GetType().Name}: {Name}");
            result.AppendLine($"--Rating: {Rating}");
            return result.ToString().Trim();
        }

        public Player(string name, double rating)
        {
            this.Name = name;
            this.Rating = rating;
        }
    }
}
