using Ascension.Domain.Concepts;

namespace Ascension.Domain.Interfaces
{
    public interface IResourceConsumer
    {
        Resources Consume(Resources allocated);
    }
}
