using System;
using System.Collections.Generic;

using Ascension.Domain.Concepts;
using Ascension.Domain.Interfaces;

namespace Ascension.Domain.Internal
{
    public class MapGenerator : IMapGenerator
    {
        public Map GenerateMap(ICollection<Country> countries, int size)
        {
            var map = new Map(size);

            var random = new Random();
            foreach (var country in countries)
            {
                int x, y;
                do
                {
                    x = random.Next(size);
                    y = random.Next(size);
                }
                while (map[x, y].Owner != null);

                map[x, y].Owner = new ComputerCountry();
            }

            return map;
        }
    }
}
