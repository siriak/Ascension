using System.Collections.Generic;

namespace Ascension.Domain.Concepts
{
    public abstract class Army
    {
        public ICollection<(Unit, int count)> Units { get; }
    }
}
