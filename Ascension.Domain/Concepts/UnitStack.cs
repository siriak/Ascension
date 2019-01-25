namespace Ascension.Domain.Concepts
{
    public class UnitStack
    {
        public UnitStack(UnitSpecification unitSpecification, uint unitCount = 0)
        {
            UnitSpecification = unitSpecification;
            UnitCount = unitCount;
        }

        public UnitSpecification UnitSpecification { get; }

        public bool IsEmpty => UnitCount == 0;

        public uint UnitCount { get; private set; }

        public void ReceiveDamage(uint damage)
        {
            var lostCount = damage / UnitSpecification.Health;
            UnitCount = lostCount > UnitCount ? 0 : UnitCount - lostCount;
        }
    }
}
