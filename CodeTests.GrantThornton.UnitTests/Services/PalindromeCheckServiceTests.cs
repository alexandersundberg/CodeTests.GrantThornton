using CodeTests.GrantThornton.Application.Services;

namespace CodeTests.GrantThornton.UnitTests.Services
{
    public class PalindromeCheckServiceTests
    {
        [Fact]
        public void CheckForPalindromes_IsPalindrome_ReturnsPalindrome()
        {
            var palindrome = "Kayak";
            var sut = new PalindromeCheckService();

            var result = sut.CheckForPalindromes([ palindrome ]);

            Assert.Empty(result.NonPalindromes);
            Assert.Single(result.Palindromes);
        }

        [Fact]
        public void CheckForPalindromes_IsNotPalindrome_ReturnsNonPalindrome()
        {
            var palindrome = "HelloWorld";
            var sut = new PalindromeCheckService();

            var result = sut.CheckForPalindromes([palindrome]);

            Assert.Single(result.NonPalindromes);
            Assert.Empty(result.Palindromes);
        }
    }
}
