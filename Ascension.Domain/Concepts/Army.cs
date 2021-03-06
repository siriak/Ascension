﻿using System.Collections.Generic;
using System.Linq;

using Ascension.Domain.Enums;

namespace Ascension.Domain.Concepts
{
    public class Army
    {
        public IList<UnitStack> Units { get; } = new List<UnitStack>();

        public IEnumerable<UnitStack> GetUnitStacksOfAttackType(TargetUnitClass targetUnitClass) => Units.Where(us => us.TargetUnitClass == targetUnitClass);

        public IEnumerable<UnitStack> GetUnitStacksOfDefenseType(UnitClass unitClass) => Units.Where(us => us.UnitClass == unitClass);
    }
}
