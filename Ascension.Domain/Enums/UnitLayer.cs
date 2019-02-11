namespace Ascension.Domain.Enums
{
    public enum UnitLayer
    {
        Air = 0b1000,
        Land = 0b0100,
        Water = 0b0010,
        Underwater = 0b0001,
        None = 0b0000,
    }
}
