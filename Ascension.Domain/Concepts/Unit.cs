namespace Ascension.Domain.Concepts
{
    public abstract class Unit
    {
        public abstract string Name { get; protected set; }

        public abstract uint Damage { get; protected set; }

        public abstract UnitType DamageType { get; protected set; }

        public abstract uint Health { get; protected set; }

        public abstract UnitType HealthType { get; protected set; }

        public abstract Resources HireCost { get; protected set; }

        public abstract Resources MaintenanceCost { get; protected set; }
    }
}
