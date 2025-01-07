using CircularDominoChain.Models;
using CircularDominoChain.Services;

namespace CircularDominoChainTests
{
    public class CircularDominoChainTests
    {
        [Fact]
        public void GivenNoDominosReturnFalse()
        {
            // Arrange
            DominoChainService dominoChainService = new();
            Domino[] dominos = [];

            // Act
            var result = dominoChainService.GetCircularDominoChain(dominos);

            // Assert
            Assert.Equal("Not Circular", result);
        }

        [Fact]
        public void GivenASingleDominoWithSameValueDotsReturnTrue()
        {
            // Arrange
            DominoChainService dominoChainService = new();
            Domino[] dominos = [new Domino(1, 1)];

            // Act
            var result = dominoChainService.GetCircularDominoChain(dominos);

            // Assert
            Assert.Equal("[1|1]", result);
        }

        [Fact]
        public void GivenTwoOrderedDominosWithSameValuesReturnTrue()
        {
            // Arrange
            DominoChainService dominoChainService = new();
            Domino[] dominos = [new Domino(1, 2), new Domino(2,1)];

            // Act
            var result = dominoChainService.GetCircularDominoChain(dominos);

            // Assert
            Assert.Equal("[1|2] [2|1]", result);
        }

        [Fact]
        public void GivenTwoUnorderedDominosWithSameValuesReturnTrue()
        {
            // Arrange
            DominoChainService dominoChainService = new();
            Domino[] dominos = [new Domino(1, 2), new Domino(1, 2)];

            // Act
            var result = dominoChainService.GetCircularDominoChain(dominos);

            // Assert
            Assert.Equal("[1|2] [2|1]", result);
        }


        [Fact]
        public void GivenMultipleDominosThatAreCircularReturnTrue()
        {
            // Arrange
            DominoChainService dominoChainService = new();
            Domino[] dominos = [new (2,1), new(2,3), new(1,3)];

            // Act
            var result = dominoChainService.GetCircularDominoChain(dominos);

            // Assert
            Assert.Equal("[2|1] [1|3] [3|2]", result);
        }

        [Fact]
        public void GivenMultipleDominosThatAreNotCircularReturnFalse()
        {
            // Arrange
            DominoChainService dominoChainService = new();
            Domino[] dominos = [new(1, 2), new(4, 1), new(2, 3)];

            // Act
            var result = dominoChainService.GetCircularDominoChain(dominos);

            // Assert
            Assert.Equal("Not Circular", result);
        }

        [Fact]
        public void GivenMultipleDominosThatDoNotMatchReturnFalse()
        {
            // Arrange
            DominoChainService dominoChainService = new();
            Domino[] dominos = [new(1, 2), new(2, 3), new(4, 3)];

            // Act
            var result = dominoChainService.GetCircularDominoChain(dominos);

            // Assert
            Assert.Equal("Not Circular", result);
        }
    }
}