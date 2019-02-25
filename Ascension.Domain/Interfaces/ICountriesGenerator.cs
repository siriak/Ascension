using System.Collections.Generic;

namespace Ascension.Domain.Concepts
{
    internal interface ICountriesGenerator
    {
        ICollection<Country> GenerateCountries();
    }
}
