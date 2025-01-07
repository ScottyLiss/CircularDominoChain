using CircularDominoChain.Models;

namespace CircularDominoChainTests.Models
{
    public class DominoTests
    {
        [Fact]
        public void GivenADominoWithValueThreeAndOne_WhenFlipped_ReturnsOneAndThree()
        {
            // Arrange
            Domino domino = new(3, 1);

            // Act
            domino.FlipDomino();

            // Assert
            Assert.True(domino.leftValue == 1);
            Assert.True(domino.rightValue == 3);

        }

        [Fact]
        public void GivenTwoDominosWithMatchingDotsReturnTrue()
        {
            // Arrange
            Domino dominoA = new(3, 1);
            Domino dominoB = new(1, 3);

            // Act
            var result = dominoA.HasMatchingDots(dominoB.leftValue);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void GivenTwoDominosWithNoMatchingDotsReturnFalse()
        {
            // Arrange
            Domino dominoA = new(3, 1);
            Domino dominoB = new(2, 4);

            // Act
            var result = dominoA.HasMatchingDots(dominoB.leftValue);

            // Assert
            Assert.False(result);
        }
    }
}
