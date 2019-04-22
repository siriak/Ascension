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

        public int Pollution { get; set; }

        public Surface Surface { get; }

        // TODO: Move cost depends on surface
        public double MoveCost => 1;

        public TerritoryProcessTurnResult ProcessTurn(TerritoryProcessTurnArgs input)
        {
            ProcessPollution();
            var toCountry = ProcessResources();

            return new TerritoryProcessTurnResult
            {
                ProjectFinished = Project.IsFinished,
                ResourcesToCountryBudget = toCountry,
            };
        }

        private void ProcessPollution() => Pollution += Building.Pollution;

        private Resources ProcessResources()
        {
            var toUse = Income / 2;
            var toCountry = Income - toUse;
            var leftover = Project.Consume(toUse);
            toCountry += leftover;

            return toCountry;
        }
    }
}
