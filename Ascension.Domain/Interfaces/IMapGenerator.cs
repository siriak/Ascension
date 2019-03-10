using System.Collections.Generic;

using Ascension.Domain.Concepts;

namespace Ascension.Domain.Interfaces
{
    public interface IMapGenerator
    {
        Map GenerateMap(ICollection<Country> countries);
    }
}
