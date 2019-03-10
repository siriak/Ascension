using System;
using System.Collections.Generic;

using Ascension.Domain.Concepts;
using Ascension.Domain.Interfaces;

namespace Ascension.Domain.Internal
{
    public class SquareMapGenerator : IMapGenerator
    {
        private readonly int size;

        public SquareMapGenerator(int size) => this.size = size;

        public Map GenerateMap(ICollection<Country> countries) => throw new NotImplementedException();
    }
}
