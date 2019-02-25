using System.Collections.Generic;

using Ascension.Domain.Concepts;

namespace Ascension.Domain.Interfaces
{
    internal interface IMapGenerator
    {
        Map GenerateMap(ICollection<Country> countries);
    }
}
