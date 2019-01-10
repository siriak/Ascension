using System.Collections.Generic;

namespace Ascension.Domain.Concepts
{
    public abstract class Army
    {
        public readonly ICollection<(Unit, int count)> Units;
    }
}
