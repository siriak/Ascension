using System;
using System.Threading.Tasks;

namespace Ascension.Domain.Concepts
{
    public class ComputerCountry : Country
    {
        public override Task MakeTurn() => throw new NotImplementedException();
    }
}
