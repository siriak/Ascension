using Ascension.Domain.DTO;

namespace Ascension.Domain.Concepts
{
    public class Territory
    {
        public Territory(Surface surface) => Surface = surface;

        public Resources Income => Building.Income;

        public Resources Capacity => Building.Capacity;

        public Building Building { get; set; }

        public Project Project { get; set; }

        public Country Owner { get; set; }

        public Surface Surface { get; }

        // TODO: Move cost depends on surface
        public double MoveCost => 1;

        public TerritoryProcessTurnResult ProcessTurn(TerritoryProcessTurnArgs input)
        {
            var toUse = Income / 2;
            var toCountry = Income - toUse;
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
