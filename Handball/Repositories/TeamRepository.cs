using Handball.Models.Contracts;
using Handball.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;


namespace Handball.Repositories
{
    public class TeamRepository : IRepository<ITeam>
    {
        // --------------------------------------------------------
        // Fields
        // --------------------------------------------------------
        private List<ITeam> teams;

        // --------------------------------------------------------
        // Constructors
        // --------------------------------------------------------
        public TeamRepository()
        {
            teams = new List<ITeam>();
        }

        // --------------------------------------------------------
        // Getters and Setters
        // --------------------------------------------------------
        public IReadOnlyCollection<ITeam> Models
        {
            get => teams.AsReadOnly();
        }

        // --------------------------------------------------------
        // Methods
        // --------------------------------------------------------
        public void AddModel(ITeam team)
        {
            if (team != null)
            {
                teams.Add(team);
            }
        }

        public bool ExistsModel(string name)
        {
            return teams.Any(t => t.Name == name);
        }

        public ITeam GetModel(string name)
        {
            ITeam team = teams.FirstOrDefault(t => t.Name == name);

            return team;
        }

        public bool RemoveModel(string name)
        {
            ITeam team = GetModel(name);

            return teams.Remove(team);
        }
    }
}
