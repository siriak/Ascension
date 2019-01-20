using System;

using Ascension.Domain.Exceptions;

namespace Ascension.Domain.Concepts
{
    public struct Resources : IComparable<Resources>, IComparable
    {
        public uint Food;
        public uint Production;
        public uint Science;
        public uint Commerce;
        public uint Culture;
        public uint Soldiers;
        public uint Ammunition;

        public static Resources operator +(Resources r1, Resources r2)
        {
            return new Resources
            {
                Food = r1.Food + r2.Food,
                Production = r1.Production + r2.Production,
                Science = r1.Science + r2.Science,
                Commerce = r1.Commerce + r2.Commerce,
                Culture = r1.Culture + r2.Culture,
                Soldiers = r1.Soldiers + r2.Soldiers,
                Ammunition = r1.Ammunition + r2.Ammunition,
            };
        }

        public static Resources operator -(Resources r1, Resources r2)
        {
            if (!(r1 >= r2))
            {
                throw new NotSufficientResourcesException();
            }

            return new Resources
            {
                Food = r1.Food - r2.Food,
                Production = r1.Production - r2.Production,
                Science = r1.Science - r2.Science,
                Commerce = r1.Commerce - r2.Commerce,
                Culture = r1.Culture - r2.Culture,
                Soldiers = r1.Soldiers - r2.Soldiers,
                Ammunition = r1.Ammunition - r2.Ammunition,
            };
        }

        public static bool operator >(Resources r1, Resources r2)
        {
            return
                r1.Food > r2.Food &&
                r1.Production > r2.Production &&
                r1.Science > r2.Science &&
                r1.Commerce > r2.Commerce &&
                r1.Culture > r2.Culture &&
                r1.Soldiers > r2.Soldiers &&
                r1.Ammunition > r2.Ammunition;
        }

        public static bool operator <(Resources r1, Resources r2)
        {
            return
                r1.Food < r2.Food &&
                r1.Production < r2.Production &&
                r1.Science < r2.Science &&
                r1.Commerce < r2.Commerce &&
                r1.Culture < r2.Culture &&
                r1.Soldiers < r2.Soldiers &&
                r1.Ammunition < r2.Ammunition;
        }

        public static bool operator >=(Resources r1, Resources r2) => r1 > r2 || r1 == r2;

        public static bool operator <=(Resources r1, Resources r2) => r1 < r2 || r1 == r2;

        public static bool operator ==(Resources r1, Resources r2) => r1.Equals(r2);

        public static bool operator !=(Resources r1, Resources r2) => !(r1 == r2);

        public Resources TrimWith(Resources r)
        {
            return new Resources()
            {
                Food = Food > r.Food ? r.Food : Food,
                Production = Production > r.Production ? r.Production : Production,
                Science = Science > r.Science ? r.Science : Science,
                Commerce = Commerce > r.Commerce ? r.Commerce : Commerce,
                Culture = Culture > r.Culture ? r.Culture : Culture,
                Soldiers = Soldiers > r.Soldiers ? r.Soldiers : Soldiers,
                Ammunition = Ammunition > r.Ammunition ? r.Ammunition : Ammunition,
            };
        }

        public override bool Equals(object obj)
        {
            return obj is Resources r
                ? Equals(r)
                : false;
        }

        public bool Equals(Resources r)
        {
            return r.Ammunition == Ammunition
                    && r.Commerce == Commerce
                    && r.Culture == Culture
                    && r.Food == Food
                    && r.Production == Production
                    && r.Science == Science
                    && r.Soldiers == Soldiers;
        }

        public override int GetHashCode()
        {
            var hashCode = -1124929281;
            hashCode = hashCode * -1521134295 + Food.GetHashCode();
            hashCode = hashCode * -1521134295 + Production.GetHashCode();
            hashCode = hashCode * -1521134295 + Science.GetHashCode();
            hashCode = hashCode * -1521134295 + Commerce.GetHashCode();
            hashCode = hashCode * -1521134295 + Culture.GetHashCode();
            hashCode = hashCode * -1521134295 + Soldiers.GetHashCode();
            hashCode = hashCode * -1521134295 + Ammunition.GetHashCode();
            return hashCode;
        }

        public int CompareTo(Resources other)
        {
            if (this > other)
            {
                return 1;
            }

            if (this == other)
            {
                return 0;
            }

            if (this < other)
            {
                return -1;
            }

            throw new ResourcesNotComparableException();
        }

        public int CompareTo(object obj)
        {
            if (obj is null)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            if (!(obj is Resources r))
            {
                throw new ArgumentException();
            }

            return CompareTo(r);
        }
    }
}
