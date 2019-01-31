using Ascension.Domain.Concepts;

namespace Ascension.Domain.Interfaces
{
    public interface IMaintainable : IResourceConsumer
    {
        Resources MaintenanceCost { get; }
    }
}
