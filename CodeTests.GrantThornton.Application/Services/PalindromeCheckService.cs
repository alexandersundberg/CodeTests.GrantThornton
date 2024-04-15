namespace CodeTests.GrantThornton.Application.Services
{
    public class PalindromeCheckService
    {
        public (string[] Palindromes, string[] NonPalindromes) CheckForPalindromes(string[] texts)
        {
            var palindromes = new List<string>();
            var nonPalindromes = new List<string>();
            foreach (var text in texts)
            {
                if (IsPalindrome(text))
                    palindromes.Add(text);
                else
                    nonPalindromes.Add(text);
            }

            return (palindromes.ToArray(), nonPalindromes.ToArray());
        }

        private static bool IsPalindrome(string text)
        {
            var reversed = new string(text.Reverse().ToArray());
            return reversed.Equals(text, StringComparison.OrdinalIgnoreCase);
        }
    }
}
