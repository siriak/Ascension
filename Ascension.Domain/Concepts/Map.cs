using System;

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
            // TODO: Add corruption
            ProcessPollution();

            return new MapProcessTurnResult();
        }

        private void ProcessPollution()
        {
            var newPollution = new double[Size, Size];
            for (var i = 0; i < Size; i++)
            {
                for (var j = 0; j < Size; j++)
                {
                    ProcessPollutionOnTerritory(i, j, map[i, j].Pollution, newPollution);
                }
            }

            for (var i = 0; i < Size; i++)
            {
                for (var j = 0; j < Size; j++)
                {
                    map[i, j].Pollution = (int)Math.Max(newPollution[i, j], 0);
                }
            }
        }

        private void ProcessPollutionOnTerritory(int x, int y, double value, double[,] map)
        {
            var angularValue = value / 20;
            map[Translate(x - 1), Translate(y - 1)] += angularValue;
            map[Translate(x - 1), Translate(y + 1)] += angularValue;
            map[Translate(x + 1), Translate(y + 1)] += angularValue;
            map[Translate(x + 1), Translate(y - 1)] += angularValue;

            var sideValue = 3 * value / 40;
            map[Translate(x), Translate(y - 1)] += sideValue;
            map[Translate(x), Translate(y + 1)] += sideValue;
            map[Translate(x - 1), Translate(y)] += sideValue;
            map[Translate(x + 1), Translate(y)] += sideValue;

            var left = value / 2;
            map[x, y] += left;
        }

        private int Translate(int n) => (n + Size) % Size;
    }
}
