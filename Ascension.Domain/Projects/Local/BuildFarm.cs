using Ascension.Domain.Buildings;
using Ascension.Domain.Concepts;

namespace Ascension.Domain.Projects.Local
{
    public class BuildFarm : LocalProject
    {
        public BuildFarm(Territory territory)
            : base(territory, new Resources() { Production = 100 })
        {
        }

        protected override void OnProjectFinished() => Territory.Building = new Farm(Territory);
    }
}
