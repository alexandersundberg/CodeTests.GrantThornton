using CodeTests.GrantThornton.Application.Extensions;

namespace CodeTests.GrantThornton.UnitTests.Extensions
{
    public class ArrayExtensionsTests
    {
        [Fact]
        public void SwapElements()
        { 
            var sut = new[] { 1, 2 };

            sut.SwapElements(0, 1);

            Assert.Equal([2, 1], sut);
        }

        [Fact]
        public void BubbleSort_UnsortedArray_ReturnsSorted()
        { 
            var sut = new[] { 9, 3, 5, 6, 1 };

            sut.BubbleSort();

            Assert.Equal([1, 3, 5, 6, 9], sut);
        }
    }
}
