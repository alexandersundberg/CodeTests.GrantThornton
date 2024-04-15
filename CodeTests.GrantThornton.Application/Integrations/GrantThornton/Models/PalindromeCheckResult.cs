using Newtonsoft.Json;

namespace CodeTests.GrantThornton.Application.Integrations.GrantThornton.Models
{
    public class PalindromeCheckResult
    {
        [JsonProperty("palindromes")]
        public string[] Palindromes { get; set; } = [];
        
        [JsonProperty("NonPalindromes")]
        public string[] NonPalindromes { get; set; } = [];
    }
}
