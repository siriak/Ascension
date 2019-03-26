using Ascension.Domain.Concepts;

namespace Ascension.Domain.DTO
{
    public class TerritoryProcessTurnResult
    {
        public bool ProjectFinished { get; set; }

        public Resources ResourcesToCountryBudget { get; set; }
    }
}
