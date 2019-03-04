namespace Ascension.Domain.Concepts
{
    public abstract class Building
    {
        public string Name => GetType().Name;

        public abstract Resources Income { get; }

        public abstract Resources Capacity { get; }

        public Territory Territory { get; }

        public Building(Territory territory) => Territory = territory;
    }
}
