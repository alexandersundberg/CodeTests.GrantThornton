using CodeTests.GrantThornton.Application.Services;

namespace CodeTests.GrantThornton.UnitTests.Services
{
    public class FibonacciSequenceServiceTests
    {
        [Theory]
        [InlineData(1, 0)]
        [InlineData(2, 1)]
        [InlineData(3, 1)]
        [InlineData(4, 2)]
        [InlineData(5, 3)]
        [InlineData(6, 5)]
        public void GetFibonacciNumber_PositiveIndex_ReturnsFibonacciNumber(int n, int expectedResult)
        {
            var sut = new FibonacciSequenceService();

            var result = sut.GetFibonacciNumber(n);

            Assert.Equal(expectedResult, result);
        }
    }
}
