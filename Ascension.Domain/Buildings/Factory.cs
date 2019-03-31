using Ascension.Domain.Concepts;

namespace Ascension.Domain.Buildings
{
    public class Factory : Building
    {
        public Factory(Territory territory)
            : base(territory)
        {
        }

        public override Resources Income => Territory.Surface == Surface.Hills
            ? new Resources
            {
                Production = 150,
                Commerce = 10,
                Science = 10,
            }
            : new Resources
            {
                Production = 100,
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
