using System;

using Ascension.Domain.Buildings;
using Ascension.Domain.Interfaces;

namespace Ascension.Domain.Concepts
{
    public abstract class Territory : ITurnProcessor<TerritoryProcessTurnArgs, TerritoryProcessTurnResult>
    {
        // TODO: Income depends on surface
        public Resources FullIncome => Building.Income;

        public Building Building { get; private set; } = new Nothing();

        public Project Project => throw new NotImplementedException();

        public Country Owner => throw new NotImplementedException();

        public Surface Surface => throw new NotImplementedException();

        public double MoveCost => throw new NotImplementedException();

        public TerritoryProcessTurnResult ProcessTurn(TerritoryProcessTurnArgs input) => throw new NotImplementedException();
    }
}
