using Ascension.Domain.Concepts;

namespace Ascension.Domain.Units
{
    public class Slave : Unit
    {
        public override string Name { get; protected set; } = "Slave";

        public override uint Damage { get; protected set; } = 1;

        public override UnitType DamageType { get; protected set; } = UnitType.Light;

        public override uint Health { get; protected set; } = 1;

        public override UnitType HealthType { get; protected set; } = UnitType.Light;

        public override Resources HireCost { get; protected set; } = new Resources
        {
            Soldiers = 10,
            Food = 10,
        };

        public override Resources MaintenanceCost { get; protected set; } = new Resources
        {
            Soldiers = 1,
            Food = 1,
        };
    }
}
