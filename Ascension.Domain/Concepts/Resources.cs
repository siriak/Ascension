using System;

using Ascension.Domain.Exceptions;

namespace Ascension.Domain.Concepts
{
    public struct Resources
    {
        public uint Food;
        public uint Production;
        public uint Science;
        public uint Commerce;
        public uint Culture;
        public uint Soldiers;
        public uint Ammunition;

        public Resources(uint food, uint production, uint science, uint commerce, uint culture, uint soldiers, uint ammunition)
        {
            Food = food;
            Production = production;
            Science = science;
            Commerce = commerce;
            Culture = culture;
            Soldiers = soldiers;
            Ammunition = ammunition;
        }

        private static TFinalResult Apply<TResult, TFinalResult>(Resources r1, Resources r2, Func<uint, uint, TResult> selector, Func<TResult, TResult, TResult, TResult, TResult, TResult, TResult, TFinalResult> aggregator)
        {
            var food = selector(r1.Food, r2.Food);
            var production = selector(r1.Production, r2.Production);
            var science = selector(r1.Science, r2.Science);
            var commerce = selector(r1.Commerce, r2.Commerce);
            var culture = selector(r1.Culture, r2.Culture);
            var soldiers = selector(r1.Soldiers, r2.Soldiers);
            var ammunition = selector(r1.Ammunition, r2.Ammunition);

            var a = aggregator(food, production, science, commerce, culture, soldiers, ammunition);

            return a;
        }

        private static TFinalResult Apply<TResult, TFinalResult>(uint count, Resources res, Func<uint, uint, TResult> selector, Func<TResult, TResult, TResult, TResult, TResult, TResult, TResult, TFinalResult> aggregator)
        {
            var food = selector(count, res.Food);
            var production = selector(count, res.Production);
            var science = selector(count, res.Science);
            var commerce = selector(count, res.Commerce);
            var culture = selector(count, res.Culture);
            var soldiers = selector(count, res.Soldiers);
            var ammunition = selector(count, res.Ammunition);

            var a = aggregator(food, production, science, commerce, culture, soldiers, ammunition);

            return a;
        }

        #region Operators

        public static Resources operator +(Resources r1, Resources r2)
        {
            return Apply(r1, r2, SumTwo, MakeResources);

            uint SumTwo(uint v1, uint v2) => v1 + v2;

            Resources MakeResources(uint v1, uint v2, uint v3, uint v4, uint v5, uint v6, uint v7) => new Resources(v1, v2, v3, v4, v5, v6, v7);

            ////return new Resources
            ////{
            ////    Food = r1.Food + r2.Food,
            ////    Production = r1.Production + r2.Production,
            ////    Science = r1.Science + r2.Science,
            ////    Commerce = r1.Commerce + r2.Commerce,
            ////    Culture = r1.Culture + r2.Culture,
            ////    Soldiers = r1.Soldiers + r2.Soldiers,
            ////    Ammunition = r1.Ammunition + r2.Ammunition,
            ////};
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

        public static uint operator /(Resources r1, Resources r2)
        {
            return Apply(r1, r2, DivideIfNotZero, Min);

            uint DivideIfNotZero(uint v1, uint v2) => v2 == 0 ? uint.MaxValue : v1 / v2;

            uint Min(uint v1, uint v2, uint v3, uint v4, uint v5, uint v6, uint v7) => Math.Min(v1, Math.Min(v2, Math.Min(v3, Math.Min(v4, Math.Min(v5, Math.Min(v6, v7))))));
        }

        public static Resources operator /(Resources r1, uint count)
        {
            return Apply(count, r1, Divide, MakeResources);

            uint Divide(uint v1, uint v2) => v2 / v1;

            Resources MakeResources(uint v1, uint v2, uint v3, uint v4, uint v5, uint v6, uint v7) => new Resources(v1, v2, v3, v4, v5, v6, v7);
        }

        public static Resources operator *(uint count, Resources res)
        {
            return Apply(count, res, Multiply, MakeResources);

            uint Multiply(uint c, uint r) => c * r;

            Resources MakeResources(uint v1, uint v2, uint v3, uint v4, uint v5, uint v6, uint v7) => new Resources(v1, v2, v3, v4, v5, v6, v7);
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

        #endregion

        #region Overrides

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

        #endregion
    }
}
