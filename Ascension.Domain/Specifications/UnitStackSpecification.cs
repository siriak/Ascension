﻿namespace Ascension.Domain.Specifications
{
    public sealed class UnitStackSpecification
    {
        public UnitStackSpecification(UnitSpecification unitSpecification, uint unitCount)
        {
            UnitSpecification = unitSpecification;
            UnitCount = unitCount;
        }

        public UnitSpecification UnitSpecification { get; }

        public uint UnitCount { get; }

        #region Shortcuts

        public uint UnitDamage => UnitSpecification.Damage;

        public uint UnitHealth => UnitSpecification.Health;

        #endregion Shortcuts
    }
}
