using Ascension.Domain.Concepts;

namespace Ascension.Domain.Internal
{
    internal class ResourceStorage
    {
        private Resources capacity;
        private Resources available;

        public ResourceStorage(Resources capacity) => this.capacity = capacity;

        public Resources Capacity
        {
            get => capacity;
            set
            {
                capacity = value;
                available = available.TrimWith(capacity);
            }
        }

        public Resources Available => available;

        public bool IsFull => Available == Capacity;

        public Resources PutResources(Resources count)
        {
            var onHands = available + count;
            var trimmed = onHands.TrimWith(capacity);
            var surplus = onHands - trimmed;

            available = trimmed;
            return surplus;
        }

        public Resources GetResources(Resources count)
        {
            var trimmed = count.TrimWith(available);
            available -= trimmed;
            return trimmed;
        }
    }
}
