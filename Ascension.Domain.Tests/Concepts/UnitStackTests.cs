using Ascension.Domain.Concepts;
using Ascension.Domain.Specifications;
using Ascension.Domain.Units;
using NUnit.Framework;

namespace Ascension.Domain.Tests.Concepts
{
    [TestFixture]
    public class UnitStackTests
    {
        [Test]
        [Parallelizable]
        public void ReceiveDamage_StackDestroyedRightDamage_UnitCountIsZero([Random(1)]uint count)
        {
            var (specification, stack) = SetUp(count);

            stack.ReceiveDamage(specification.Health * count);

            Assert.AreEqual(0, stack.UnitCount);
        }

        [Test]
        [Parallelizable]
        public void ReceiveDamage_StackDestroyedMoreDamage_UnitCountIsZero([Random(1)]uint count)
        {
            var (specification, stack) = SetUp(count);

            stack.ReceiveDamage(specification.Health * (count + 1));

            Assert.AreEqual(0, stack.UnitCount);
        }

        [Test]
        [Parallelizable]
        public void ReceiveDamage_StackNotDestroyed1HPLeft_UnitCountNotZero([Random(1, uint.MaxValue, 1)]uint count)
        {
            var (specification, stack) = SetUp(count);

            stack.ReceiveDamage(specification.Health * count - 1);

            Assert.AreNotEqual(0, stack.UnitCount);
        }

        [Test]
        [Parallelizable]
        public void ReceiveDamage_StackNotDestroyed1UnitLeft_UnitCountNotZero([Random(1, uint.MaxValue, 1)]uint count)
        {
            var (specification, stack) = SetUp(count);

            stack.ReceiveDamage(specification.Health * (count - 1));

            Assert.AreNotEqual(0, stack.UnitCount);
        }

        [Test]
        [Parallelizable]
        public void IsEmpty_UnitCountIsZero_StackIsEmpty()
        {
            var (_, stack) = SetUp(0);

            Assert.IsTrue(stack.IsEmpty);
        }

        [Test]
        [Parallelizable]
        public void IsEmpty_UnitCountNotZero_StackNotEmpty([Random(1, uint.MaxValue, 1)]uint count)
        {
            var (_, stack) = SetUp(count);

            Assert.IsFalse(stack.IsEmpty);
        }

        private (UnitSpecification specification, UnitStack stack) SetUp(uint count)
        {
            var unitSpecification = new SlaveSpecification();
            var stackSpecification = new UnitStackSpecification(unitSpecification, count);
            var stack = new UnitStack(stackSpecification);

            return (unitSpecification, stack);
        }
    }
}
