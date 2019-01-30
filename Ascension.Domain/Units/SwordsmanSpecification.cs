using Ascension.Domain.Concepts;
using Ascension.Domain.Specifications;

namespace Ascension.Domain.Units
{
    public class SwordsmanSpecification : UnitSpecification
    {
        public override string Name { get; } = "Swordsman";

        public override uint Damage { get; } = 10;

        public override TargetUnitClass TargetUnitClass { get; } = TargetUnitClass.Light;

        public override uint Health { get; } = 10;

        public override UnitClass UnitClass { get; } = UnitClass.Medium;

        public override Resources HireCost { get; } = new Resources
        {
            Soldiers = 10,
            Ammunition = 10,
            Food = 20,
        };

        public override Resources MaintenanceCost { get; } = new Resources
        {
            Soldiers = 1,
            Ammunition = 1,
            Food = 2,
        };
    }
}
