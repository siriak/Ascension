using Ascension.Domain.Concepts;

namespace Ascension.Domain.Buildings
{
    public class Nothing : Building
    {
        public Nothing(Territory territory)
            : base(territory)
        {
        }

        public override Resources Income => new Resources()
        {
            Food = 10,
            Production = 10,
            Science = 20,
            Culture = 20,
        };

        public override Resources Capacity => default;

        public override int Pollution => -10;
    }
}
