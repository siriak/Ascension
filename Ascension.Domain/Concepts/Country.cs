using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Ascension.Domain.DTO;
using Ascension.Domain.Internal;
using Ascension.Domain.Projects;

namespace Ascension.Domain.Concepts
{
    public abstract class Country
    {
        public Resources GDP { get; private set; }

        public ICollection<Territory> Lands { get; } = new HashSet<Territory>();

        public ICollection<Army> Armies { get; } = new List<Army>();

        public ICollection<GlobalProject> Projects { get; } = new List<GlobalProject>();

        private readonly ResourceStorage resourceStorage = new ResourceStorage(default(Resources));

        /// <summary>
        /// Updates info about country, adds income to the budget and allocates resources to projects.
        /// </summary>
        public void ProcessTurn()
        {
            UpdateInfo();

            ProcessLands();
            ProcessProjects();

            UpdateInfo();
        }

        /// <summary>
        /// Moves units, builds buildings, makes decisions, etc.
        /// </summary>
        /// <returns>Returns when the player finishes the turn.</returns>
        public abstract Task MakeTurn();

        private void UpdateInfo()
        {
            UpdateGDP();
            UpdateStorageCapacity();
        }

        private void UpdateGDP()
        {
            var newGDP = default(Resources);
            foreach (var territory in Lands)
            {
                newGDP += territory.Income;
            }

            GDP = newGDP;
        }

        private void UpdateStorageCapacity()
        {
            var newCapacity = default(Resources);
            foreach (var territory in Lands)
            {
                newCapacity += territory.Capacity;
            }

            resourceStorage.Capacity = newCapacity;
        }

        private void ProcessLands()
        {
            var toBudget = default(Resources);
            foreach (var territory in Lands)
            {
                var res = territory.ProcessTurn(new TerritoryProcessTurnArgs());
                toBudget += res.ResourcesToCountryBudget;
            }

            resourceStorage.PutResources(toBudget);
        }

        private void ProcessProjects()
        {
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
        }
    }
}
