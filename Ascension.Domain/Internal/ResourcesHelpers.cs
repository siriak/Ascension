using Ascension.Domain.Concepts;

namespace Ascension.Domain.Internal
{
    public static class ResourcesHelpers
    {
        public static Resources TrimWith(this Resources resource, Resources trimmer)
        {
            return new Resources()
            {
                Food = resource.Food > trimmer.Food ? trimmer.Food : resource.Food,
                Production = resource.Production > trimmer.Production ? trimmer.Production : resource.Production,
                Science = resource.Science > trimmer.Science ? trimmer.Science : resource.Science,
                Commerce = resource.Commerce > trimmer.Commerce ? trimmer.Commerce : resource.Commerce,
                Culture = resource.Culture > trimmer.Culture ? trimmer.Culture : resource.Culture,
                Soldiers = resource.Soldiers > trimmer.Soldiers ? trimmer.Soldiers : resource.Soldiers,
                Ammunition = resource.Ammunition > trimmer.Ammunition ? trimmer.Ammunition : resource.Ammunition,
            };
        }
    }
}
