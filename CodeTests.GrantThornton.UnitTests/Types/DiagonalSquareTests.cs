using CodeTests.GrantThornton.Application.Types;
using Xunit.Abstractions;

namespace CodeTests.GrantThornton.UnitTests.Types
{
    public class DiagonalSquareTests(ITestOutputHelper _output)
    {
        [Fact]
        public void DiagonalSquare_EvenNumber_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() =>  new DiagonalSquare(2));
        }

        [Fact]
        public void DiagonalSquare_NIs3_ReturnsDiagonalSquareWithN3()
        {
            var diagonalSquare = new DiagonalSquare(3);

            var expected = new bool[,]
            {
                { false, true, false },
                { true, true, true },
                { false, true, false },
            };

            Assert.Equal(expected, diagonalSquare.Representation);
        }

        [Fact]
        public void DiagonalSquare_NIs5_ReturnsDiagonalSquareWithN5()
        {
            var diagonalSquare = new DiagonalSquare(5);

            var expected = new bool[,]
            {
                { false, false, true, false, false },
                { false, true, true, true, false },
                { true, true, true, true, true },
                { false, true, true, true, false },
                { false, false, true, false, false },
            };

            Assert.Equal(expected, diagonalSquare.Representation);
        }
    }
}
