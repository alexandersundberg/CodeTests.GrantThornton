using System.Net.Http.Json;
using System.Text;
using System.Web;
using CodeTests.GrantThornton.Application.Integrations.GrantThornton.Models;
using Newtonsoft.Json;

namespace CodeTests.GrantThornton.Application.Integrations.GrantThornton
{
    public class GrantThorntonClient
    {
        private readonly HttpClient _client;
        private readonly string _code;

        public GrantThorntonClient(string uri, string code)
        {
            _client = new HttpClient() { BaseAddress = new(uri) };
            _code = code;
        }

        public async Task<string[]> GetPalindromeTestDataAsync(string name)
        {
            var uri = $"get/{name}?code={HttpUtility.UrlEncode(_code)}";
            var result = await _client.GetAsync(uri);
            result.EnsureSuccessStatusCode();

            var testData = JsonConvert.DeserializeObject<string[]>(await result.Content.ReadAsStringAsync());
            if (testData == null || testData.Length == 0)
            {
                throw new Exception("No test data received.");
            }

            return testData;
        }

        public async Task SubmitPalindromesAsync(string name, PalindromeCheckResult checkResult)
        {
            var uri = $"submit/{name}?code={HttpUtility.UrlEncode(_code)}";

            var content = new StringContent(
                JsonConvert.SerializeObject(checkResult), 
                Encoding.UTF8, 
                "application/json");

            var result = await _client.PostAsync(uri, content);
            result.EnsureSuccessStatusCode();
        }
    }
}
