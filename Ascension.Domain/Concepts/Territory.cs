using Ascension.Domain.DTO;
using Ascension.Domain.Interfaces;

namespace Ascension.Domain.Concepts
{
    public class Territory : ITurnProcessor<TerritoryProcessTurnArgs, TerritoryProcessTurnResult>
    {
        public Territory(Surface surface) => Surface = surface;

        // TODO: Income depends on surface
        public Resources FullIncome => Building.Income;

        public Building Building { get; set; }

        public Project Project { get; set; }

        public Country Owner { get; set; }

        public Surface Surface { get; }

        // TODO: Move cost depends on surface
        public double MoveCost => 1;

        public TerritoryProcessTurnResult ProcessTurn(TerritoryProcessTurnArgs input)
        {
            var toUse = FullIncome / 2;
            var toCountry = FullIncome - toUse;
            var leftover = Project.Consume(toUse);
            toCountry += leftover;

            var res = new TerritoryProcessTurnResult
            {
                ProjectFinished = Project.IsFinished,
                ResourcesToCountryBudget = toCountry,
            };

            return res;
        }
    }
}
