using Ascension.Domain.DTO;

namespace Ascension.Domain.Concepts
{
    public class Map
    {
        public Map(int size) => Size = size;

        private readonly Territory[,] map;

        public int Size { get; }

        public MapProcessTurnResult ProcessTurn(MapProcessTurnArgs input)
        {
            // TODO: Process pollution, etc.
            return new MapProcessTurnResult();
        }
    }
}
