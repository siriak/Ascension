using System.Collections.Generic;
using System.Linq;

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

        private readonly ResourceStorage resourceStorage = new ResourceStorage(default);

        public void ProcessTurn()
        {
            UpdateInfo();

            ProcessLands();
            ProcessProjects();

            UpdateInfo();
        }

        private void UpdateInfo()
        {
            UpdateGDP();
            UpdateStorageCapacity();
        }

        private void UpdateGDP()
        {
            Resources newGDP = default;
            foreach (var territory in Lands)
            {
                newGDP += territory.Income;
            }

            GDP = newGDP;
        }

        private void UpdateStorageCapacity()
        {
            Resources newCapacity = default;
            foreach (var territory in Lands)
            {
                newCapacity += territory.Capacity;
            }

            resourceStorage.Capacity = newCapacity;
        }

        private void ProcessLands()
        {
            Resources toBudget = default;
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
