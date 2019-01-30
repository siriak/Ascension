using Ascension.Domain.Concepts;

namespace Ascension.Domain.Specifications
{
    public abstract class UnitSpecification
    {
        public abstract string Name { get; }

        public abstract uint Damage { get; }

        public abstract TargetUnitClass TargetUnitClass { get; }

        public abstract uint Health { get; }

        public abstract UnitClass UnitClass { get; }

        public abstract Resources HireCost { get; }

        public abstract Resources MaintenanceCost { get; }
    }
}
