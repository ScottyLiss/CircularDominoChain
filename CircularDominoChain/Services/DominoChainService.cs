using CircularDominoChain.Interfaces;
using CircularDominoChain.Models;

namespace CircularDominoChain.Services
{
    public class DominoChainService : IDominoChainService
    {
        public string GetCircularDominoChain(Domino[] dominos)
        {
            if (dominos.Length == 0)
            {
                return "Not Circular";
            }

            if (dominos.Length == 1)
            {
                return dominos[0].leftValue == dominos[0].rightValue ? $"[{dominos[0].leftValue}|{dominos[0].rightValue}]" : "Not Circular";
            }

            Dictionary<Domino, bool> usedDominos = dominos.ToDictionary(d => d, d => false); 

            var result = Backtrack(dominos.ToList(), new(), usedDominos);

            if(result != null)
            {
                return string.Join(" ", result.Select(d => $"[{d.leftValue}|{d.rightValue}]"));
            }

            return "Not Circular";
        }

        private List<Domino> Backtrack(List<Domino> dominos, List<Domino> permutation, Dictionary<Domino, bool> used)
        {
            if (permutation.Count == dominos.Count && IsCircle(permutation))
            {
                return new List<Domino>(permutation);
            }

            for (int i = 0; i < dominos.Count; i++)
            {
                if (!used[dominos[i]])
                {
                    used[dominos[i]] = true;

                    if(CanPlaceDomino(permutation, dominos[i]))
                    {
                        permutation.Add(dominos[i]);
                        var result = Backtrack(dominos, permutation, used);
                        if (result != null) 
                            return result;
                        permutation.RemoveAt(permutation.Count - 1);
                    }
                    else if(CanPlaceDomino(permutation, dominos[i], true))
                    {
                        dominos[i].FlipDomino();
                        permutation.Add(dominos[i]);
                        var result = Backtrack(dominos, permutation, used);
                        if (result != null)
                            return result;
                        permutation.RemoveAt(permutation.Count - 1);
                        dominos[i].FlipDomino();
                    }

                    used[dominos[i]] = false;
                }
            }
            return null;
        }

        private bool CanPlaceDomino(List<Domino> permutation, Domino domino, bool flip = false)
        {
            if (flip)
            {
                domino.FlipDomino();
            }

            bool canPlace = permutation.Count == 0 ||
                    permutation[permutation.Count - 1].rightValue == domino.leftValue;

            if (flip)
            {
                domino.FlipDomino();
            }

            return canPlace;
        }

        private bool IsCircle(List<Domino> permutation)
        {
            if(permutation.Count == 0 ) return false;

            return permutation[0].leftValue == permutation[permutation.Count -1].rightValue;
        }
    }
}
