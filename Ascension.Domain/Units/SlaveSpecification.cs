using Ascension.Domain.Concepts;

namespace Ascension.Domain.Units
{
    public class SlaveSpecification : UnitSpecification
    {
        public override string Name { get; } = "Slave";

        public override uint Damage { get; } = 1;

        public override UnitType AttackType { get; } = UnitType.Light;

        public override uint Health { get; } = 1;

        public override UnitType DefenseType { get; } = UnitType.Light;

        public override Resources HireCost { get; } = new Resources
        {
            Soldiers = 10,
            Food = 10,
        };

        public override Resources MaintenanceCost { get; } = new Resources
        {
            Soldiers = 1,
            Food = 1,
        };
    }
}
