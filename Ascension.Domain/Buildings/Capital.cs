using Ascension.Domain.Concepts;

namespace Ascension.Domain.Buildings
{
    public class Capital : Building
    {
        public Capital(Territory territory)
            : base(territory)
        {
        }

        public override Resources Income => new Resources
        {
            Food = 100,
            Ammunition = 100,
            Culture = 100,
            Commerce = 100,
            Production = 100,
            Soldiers = 100,
            Science = 100,
        };

        public override Resources Capacity => new Resources
        {
            Food = 1000,
            Ammunition = 1000,
            Soldiers = 1000,
        };

        public override int Pollution => 100;
    }
}
