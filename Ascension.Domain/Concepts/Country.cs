using System.Collections.Generic;
using System.Linq;

using Ascension.Domain.DTO;
using Ascension.Domain.Internal;
using Ascension.Domain.Projects;

namespace Ascension.Domain.Concepts
{
    public abstract class Country
    {
        public Resources Income { get; private set; }

        public ICollection<Territory> Lands { get; } = new HashSet<Territory>();

        public ICollection<Army> Armies { get; } = new List<Army>();

        public ICollection<GlobalProject> Projects { get; } = new List<GlobalProject>();

        private readonly ResourceStorage resourceStorage = new ResourceStorage(default);

        public void ProcessTurn()
        {
            foreach (var territory in Lands)
            {
                territory.ProcessTurn(new TerritoryProcessTurnArgs());
            }

            UpdateIncome();

            resourceStorage.PutResources(Income);
            var availableResources = resourceStorage.Available;

            var projects = new List<Project>(Projects);

            foreach (var tile in Lands)
            {
                projects.Add(tile.Project);
            }

            var orderedProjects = projects.Where(x => x != null).OrderBy(x => x.Priority);

            foreach (var project in orderedProjects)
            {
                availableResources = project.Consume(availableResources);
            }

            UpdateIncome();
        }

        private void UpdateIncome()
        {
            Income = default;
            foreach (var tile in Lands)
            {
                Income += tile.FullIncome;
            }
        }
    }
}
