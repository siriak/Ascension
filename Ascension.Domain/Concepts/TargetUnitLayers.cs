using System;

namespace Ascension.Domain.Concepts
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
