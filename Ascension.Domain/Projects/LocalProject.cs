using Ascension.Domain.Concepts;

namespace Ascension.Domain.Projects
{
    public abstract class LocalProject : Project
    {
        public LocalProject(Territory territory, Resources cost)
            : base(cost) => Territory = territory;

        public Territory Territory { get; }
    }
}
