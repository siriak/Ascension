using Ascension.Domain.Interfaces;
using Ascension.Domain.Internal;

namespace Ascension.Domain.Concepts
{
    public abstract class Project : IBuildable
    {
        protected Project(Resources cost) => storage = new PutOnlyResourceStorage(cost);

        private readonly PutOnlyResourceStorage storage;

        public Resources BuildCost => storage.Capacity;

        public Resources ResourcesAllocated => storage.Available;

        public bool IsFinished { get; private set; }

        public Resources Consume(Resources allocated)
        {
            if (IsFinished)
            {
                return allocated;
            }

            var leftover = storage.PutResources(allocated);

            if (storage.IsFull)
            {
                IsFinished = true;
                OnProjectFinished();
            }

            return leftover;
        }

        protected abstract void OnProjectFinished();
    }
}
