using Ascension.Domain.Concepts;

namespace Ascension.Domain.Buildings
{
    public class Farm : Building
    {
        public Farm(Territory territory)
            : base(territory)
        {
        }

        public override Resources Income => new Resources
        {
            Food = 100,
        };

        public override Resources Capacity => new Resources
        {
            Food = 1000,
        };

        public override int Pollution => 10;
    }
}
