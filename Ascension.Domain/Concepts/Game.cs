using System.Collections.Generic;

namespace Ascension.Domain.Concepts
{
    public class Game
    {
        public ICollection<Player> Players { get; private set; }
    }
}
