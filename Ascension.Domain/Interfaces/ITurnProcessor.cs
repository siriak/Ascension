namespace Ascension.Domain.Interfaces
{
    public interface ITurnProcessor<in TInput, out TOutput>
    {
        TOutput ProcessTurn(TInput input);
    }
}
