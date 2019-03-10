using System.Collections.Generic;

namespace Ascension.Domain.Interfaces
{
    public interface ICountriesGenerator
    {
        ICollection<Country> GenerateCountries();
    }
}
