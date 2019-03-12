using System.Collections.Generic;

using Ascension.Domain.Concepts;

namespace Ascension.Domain.Interfaces
{
    public interface ICountriesGenerator
    {
        ICollection<Country> GenerateCountries();
    }
}
