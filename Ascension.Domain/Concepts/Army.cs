using System.Collections.Generic;
using System.Linq;

namespace Ascension.Domain.Concepts
{
    public abstract class Army
    {
        public ISet<UnitStack> Units { get; }

        public IEnumerable<UnitStack> GetUnitStacksOfAttackType(TargetUnitClass targetUnitClass) => Units.Where(s => s.UnitSpecification.TargetUnitClass == targetUnitClass);

        public IEnumerable<UnitStack> GetUnitStacksOfDefenseType(UnitClass unitClass) => Units.Where(s => s.UnitSpecification.UnitClass == unitClass);
    }
}
