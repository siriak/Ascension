using System;

using Ascension.Domain.Enums;
using Ascension.Domain.Interfaces;
using Ascension.Domain.Specifications;

namespace Ascension.Domain.Concepts
{
    public class UnitStack : IResourceConsumer
    {
        public UnitStack(UnitStackSpecification specification) => Specification = specification ?? throw new ArgumentNullException(nameof(specification));

        public UnitStackSpecification Specification { get; }

        public bool IsEmpty => UnitCount == 0;

        public uint UnitCount { get; private set; }

        public uint TotalDamage => Specification.UnitDamage * UnitCount;

        public void ReceiveDamage(uint damage)
        {
            var lostCount = damage / Specification.UnitHealth;
            UnitCount = lostCount > UnitCount ? 0 : UnitCount - lostCount;
        }

        public Resources Consume(Resources allocated)
        {
            var canHireCount = allocated / Specification.UnitHireCost;

            if (canHireCount == 0)
            {
                return allocated;
            }

            var unitsNeed = Specification.UnitCount - UnitCount;
            if (canHireCount > unitsNeed)
            {
                canHireCount = unitsNeed;
            }

            UnitCount += canHireCount;

            return allocated - UnitCount * Specification.UnitHireCost;
        }

        #region Shortcuts

        public TargetUnitClass TargetUnitClass => Specification.UnitSpecification.TargetUnitClass;

        public UnitClass UnitClass => Specification.UnitSpecification.UnitClass;

        #endregion
    }
}
