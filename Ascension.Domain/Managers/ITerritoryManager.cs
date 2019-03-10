using Ascension.Domain.Concepts;

namespace Ascension.Domain.Managers
{
    public interface ITerritoryManager
    {
        void Transfer(Territory territory, Country newOwner);
    }
}
