using Ascension.Domain.Concepts;

namespace Ascension.Domain.Buildings
{
    public class WarFactory : Building
    {
        public WarFactory(Territory territory)
            : base(territory)
        {
        }

        public override Resources Income => Territory.Surface == Surface.Hills
            ? new Resources
            {
                Ammunition = 150,
                Commerce = 10,
                Science = 10,
            }
            : new Resources
            {
                Ammunition = 100,
                Commerce = 10,
                Science = 10,
            };

        public override Resources Capacity => new Resources
        {
            Food = 10,
        };

        public override int Pollution => 100;
    }
}
