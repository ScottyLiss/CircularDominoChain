namespace CircularDominoChain.Models
{
    public class Domino
    {
        public int leftValue, rightValue;

        public Domino(int left, int right)
        {
            leftValue = left;
            rightValue = right;
        }

        public void FlipDomino() => (leftValue, rightValue) = (rightValue, leftValue);

        public bool HasMatchingDots(int dotCount)
        {
            return leftValue == dotCount || rightValue == dotCount;
        }
    }
}
