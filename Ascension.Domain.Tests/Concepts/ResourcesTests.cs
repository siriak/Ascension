using System;

using Ascension.Domain.Concepts;
using Ascension.Domain.Exceptions;
using NUnit.Framework;

namespace Ascension.Domain.Tests.Concepts
{
    [TestFixture]
    internal class ResourcesTests
    {
        [Test]
        [Parallelizable]
        public void Substract_NotSufficientResources_ExceptionThrown([Random(1)]uint count1, [Random(1)]uint count2)
        {
            var (smaller, bigger) = GetResources(count1, count2);

            Assert.Throws<NotSufficientResourcesException>(() => { var result = count1 != count2 ? smaller - bigger : throw new NotSufficientResourcesException(); });
        }

        [Test]
        [Parallelizable]
        public void Substract_EnoughResources_Substracted([Random(1)]uint count1, [Random(1)]uint count2)
        {
            var (smaller, bigger) = GetResources(count1, count2);

            var result = bigger - smaller;

            Assert.AreEqual(result.Food, bigger.Food - smaller.Food);
            Assert.AreEqual(result.Ammunition, bigger.Ammunition - smaller.Ammunition);
            Assert.AreEqual(result.Commerce, bigger.Commerce - smaller.Commerce);
            Assert.AreEqual(result.Culture, bigger.Culture - smaller.Culture);
            Assert.AreEqual(result.Production, bigger.Production - smaller.Production);
            Assert.AreEqual(result.Science, bigger.Science - smaller.Science);
            Assert.AreEqual(result.Soldiers, bigger.Soldiers - smaller.Soldiers);
        }

        [Test]
        [Parallelizable]
        public void Add_EnoughResources_Added([Random(1)]uint resourcesCount)
        {
            var r1 = GetResources(resourcesCount);
            var r2 = GetResources(resourcesCount);

            var result = r2 + r1;

            Assert.AreEqual(result.Food, r2.Food + r1.Food);
            Assert.AreEqual(result.Ammunition, r2.Ammunition + r1.Ammunition);
            Assert.AreEqual(result.Commerce, r2.Commerce + r1.Commerce);
            Assert.AreEqual(result.Culture, r2.Culture + r1.Culture);
            Assert.AreEqual(result.Production, r2.Production + r1.Production);
            Assert.AreEqual(result.Science, r2.Science + r1.Science);
            Assert.AreEqual(result.Soldiers, r2.Soldiers + r1.Soldiers);
        }

        private (Resources smaller, Resources bigger) GetResources(uint count1, uint count2)
        {
            var smaller = Math.Min(count1, count2);
            var bigger = Math.Max(count1, count2);

            return (GetResources(smaller), GetResources(bigger));
        }

        private Resources GetResources(uint count) =>
            new Resources
            {
                Food = count,
                Ammunition = count,
                Commerce = count,
                Culture = count,
                Production = count,
                Science = count,
                Soldiers = count,
            };
    }
}
