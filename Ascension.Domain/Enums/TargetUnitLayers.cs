using System;

namespace Ascension.Domain.Enums
{
    [Flags]
    public enum TargetUnitLayers
    {
        Air = UnitLayer.Air,
        Land = UnitLayer.Land,
        Water = UnitLayer.Water,
        Underwater = UnitLayer.Underwater,
        None = UnitLayer.None,
    }
}
