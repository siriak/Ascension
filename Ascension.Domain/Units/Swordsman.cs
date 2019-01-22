using Ascension.Domain.Concepts;
using System;

namespace Ascension.Domain.Units
{
    public class Swordsman : Unit
    {
        public override string Name { get; protected set; } = "Swordsman";

        public override uint Damage { get; protected set; } = 10;

        public override UnitType DamageType { get; protected set; } = UnitType.Light;

        public override uint Health { get; protected set; } = 10;

        public override UnitType HealthType { get; protected set; } = UnitType.Medium;

        public override Resources HireCost { get; protected set; } = new Resources
        {
            Soldiers = 10,
            Ammunition = 10,
            Food = 20,
        };

        public override Resources MaintenanceCost { get; protected set; } = new Resources
        {
            Soldiers = 1,
            Ammunition = 1,
            Food = 2,
        };
    }
}
