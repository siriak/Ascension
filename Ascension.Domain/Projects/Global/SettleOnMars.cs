using System;

using Ascension.Domain.Concepts;

namespace Ascension.Domain.Projects.Global
{
    public class SettleOnMars : GlobalProject
    {
        public SettleOnMars(Country country)
            : base(country, new Resources() { Production = 1000000 })
        {
        }

        protected override void OnProjectFinished() => throw new NotImplementedException();
    }
}
