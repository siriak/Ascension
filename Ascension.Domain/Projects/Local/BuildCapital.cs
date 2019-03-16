using Ascension.Domain.Buildings;
using Ascension.Domain.Concepts;

namespace Ascension.Domain.Projects.Local
{
    public class BuildCapital : LocalProject
    {
        public BuildCapital(Territory territory)
            : base(territory, new Resources() { Production = 1000 })
        {
        }

        protected override void OnProjectFinished() => Territory.Building = new Capital(Territory);
    }
}
