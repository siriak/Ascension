using Ascension.Domain.Exceptions;

namespace Ascension.Domain.Concepts
{
    public struct ResourceStorage
    {
        private Resources capacity;
        private Resources available;

        public ResourceStorage(Resources capacity)
        {
            this.capacity = capacity;
            available = default;
        }

        public Resources Capacity
        {
            get => capacity;
            set
            {
                capacity = value;
                available = available.TrimWith(capacity);
            }
        }

        public Resources Available
        {
            get => available;
            set
            {
                if (!(capacity >= value))
                {
                    throw new NotEnoughSpaceInStorageException();
                }

                available = value;
            }
        }
    }
}
