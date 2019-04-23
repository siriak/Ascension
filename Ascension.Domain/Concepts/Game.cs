using System.Collections.Generic;

using Ascension.Domain.DTO;
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
            // TODO: remove
            var size = 100;
            Countries = countriesGenerator.GenerateCountries();
            Map = mapGenerator.GenerateMap(Countries, size);

            ProcessTurn();
        }

        public void ProcessTurn()
        {
            Map.ProcessTurn(new MapProcessTurnArgs());

            foreach (var country in Countries)
            {
                country.ProcessTurn();
            }

            Turn++;
        }
    }
}
