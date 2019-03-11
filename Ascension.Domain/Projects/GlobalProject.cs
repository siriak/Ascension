using Ascension.Domain.Concepts;

namespace Ascension.Domain.Projects
{
    public abstract class GlobalProject : Project
    {
        public GlobalProject(Country country, Resources cost)
            : base(cost) => Country = country;

        public Country Country { get; }
    }
}
