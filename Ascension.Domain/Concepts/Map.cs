using System;

using Ascension.Domain.DTO;
using Ascension.Domain.Interfaces;

namespace Ascension.Domain.Concepts
{
    public class Map : ITurnProcessor<MapProcessTurnArgs, MapProcessTurnResult>
    {
        public Map(int size) => Size = size;

        private readonly Territory[,] map;

        public int Size { get; }

        public MapProcessTurnResult ProcessTurn(MapProcessTurnArgs input) => throw new NotImplementedException();
    }
}
