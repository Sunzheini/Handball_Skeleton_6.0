using Handball.Models.Contracts;
using Handball.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;


namespace Handball.Repositories
{
    public class PlayerRepository : IRepository<IPlayer>
    {
        // --------------------------------------------------------
        // Fields
        // --------------------------------------------------------
        private List<IPlayer> players;

        // --------------------------------------------------------
        // Constructors
        // --------------------------------------------------------
        public PlayerRepository()
        {
            players = new List<IPlayer>();
        }

        // --------------------------------------------------------
        // Getters and Setters
        // --------------------------------------------------------
        public IReadOnlyCollection<IPlayer> Models
        {
            get => players.AsReadOnly();
        }

        // --------------------------------------------------------
        // Methods
        // --------------------------------------------------------
        public void AddModel(IPlayer player)
        {
            if (player != null)
            {
                players.Add(player);
            }   
        }

        public bool ExistsModel(string name)
        {
            return players.Any(p => p.Name == name);
        }

        public IPlayer GetModel(string name)
        {
            IPlayer player = players.FirstOrDefault(p => p.Name == name);

            return player;
        }

        public bool RemoveModel(string name)
        {
            IPlayer player = GetModel(name);

            return players.Remove(player);
        }
    }
}
