namespace Ascension.Domain.Concepts
{
    public abstract class UnitSpecification
    {
        public abstract string Name { get; }

        public abstract uint Damage { get; }

        public abstract UnitType AttackType { get; }

        public abstract uint Health { get; }

        public abstract UnitType DefenseType { get; }

        public abstract Resources HireCost { get; }

        public abstract Resources MaintenanceCost { get; }
    }
}
