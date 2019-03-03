using Ascension.Domain.Concepts;

namespace Ascension.Domain.Internal
{
    public class PutOnlyResourceStorage
    {
        private readonly ResourceStorage storage;

        public PutOnlyResourceStorage(Resources capacity) => storage = new ResourceStorage(capacity);

        public Resources Capacity
        {
            get => storage.Capacity;
            set => storage.Capacity = value;
        }

        public Resources Available => storage.Available;

        public bool IsFull => storage.IsFull;

        public Resources PutResources(Resources count) => storage.PutResources(count);
    }
}
