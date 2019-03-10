using System.Collections.Generic;

using Ascension.Domain.Interfaces;

namespace Ascension.Domain.Concepts
{
    public class Game
    {
        public Map Map { get; }

        public ICollection<Country> Countries { get; }

        public int Turn { get; private set; }

        public Game(IMapGenerator mapGenerator, ICountriesGenerator countriesGenerator)
        {
            Countries = countriesGenerator.GenerateCountries();
            Map = mapGenerator.GenerateMap(Countries);

            ProcessTurn();
        }

        public void ProcessTurn()
        {
            Map.ProcessTurn(null);

            foreach (var country in Countries)
            {
                country.ProcessTurn();
            }

            Turn++;
        }
    }
}
