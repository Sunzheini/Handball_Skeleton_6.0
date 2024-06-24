using Handball.Models.Contracts;
using Handball.Utilities.Messages;
using System;
using System.Text;


namespace Handball.Models
{
    public abstract class Player : IPlayer
    {
        public string Name
        {
            get { return Name; }
            set 
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidName);
                }
                Name = value;
            }
        }

        public void DecreaseRating()
        {
            throw new NotImplementedException();
        }

        public void IncreaseRating()
        {
            throw new NotImplementedException();
        }

        public void JoinTeam(string name)
        {
            throw new NotImplementedException();
        }
    }
}
