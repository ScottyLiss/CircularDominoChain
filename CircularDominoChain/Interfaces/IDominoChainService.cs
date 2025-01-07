using CircularDominoChain.Models;

namespace CircularDominoChain.Interfaces
{
    public interface IDominoChainService
    {
        string GetCircularDominoChain(Domino[] dominos);
    }
}