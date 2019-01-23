﻿using Ascension.Domain.Concepts;

namespace Ascension.Domain.Units
{
    public class SwordsmanSpecification : UnitSpecification
    {
        public override string Name { get; } = "Swordsman";

        public override uint Damage { get; } = 10;

        public override UnitType AttackType { get; } = UnitType.Light;

        public override uint Health { get; } = 10;

        public override UnitType DefenseType { get; } = UnitType.Medium;

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