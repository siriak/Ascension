using Ascension.Domain.Concepts;

namespace Ascension.Domain.Managers
{
    public class TerritoryManager : ITerritoryManager
    {
        public void Transfer(Territory territory, Country newOwner)
        {
            territory.Owner?.Lands.Remove(territory);
            newOwner?.Lands.Add(territory);
            territory.Owner = newOwner;
        }
    }
}
