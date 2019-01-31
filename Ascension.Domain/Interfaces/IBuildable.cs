using Ascension.Domain.Concepts;

namespace Ascension.Domain.Interfaces
{
    public interface IBuildable : IResourceConsumer
    {
        Resources BuildCost { get; }

        Resources ResourcesAllocated { get; }

        bool IsFinished { get; }
    }
}
