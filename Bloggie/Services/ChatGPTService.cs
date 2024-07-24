using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Bloggie.Services
{
    public class ChatGPTService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        public ChatGPTService(HttpClient httpClient, string apiKey)
        {
            _httpClient = httpClient;
            _apiKey = apiKey;
        }

        public async Task<string> GenerateContentAsync(string prompt)
        {
            var requestBody = new
            {
                model = "gpt-3.5-turbo", // Adjust model as needed
                messages = new[]
                {
                    new { role = "user", content = prompt }
                }
            };

            var requestJson = JsonConvert.SerializeObject(requestBody);
            var requestContent = new StringContent(requestJson, System.Text.Encoding.UTF8, "application/json");

            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _apiKey);

            var response = await _httpClient.PostAsync("https://api.openai.com/v1/chat/completions", requestContent);
            response.EnsureSuccessStatusCode();

            var responseJson = await response.Content.ReadAsStringAsync();
            dynamic responseObject = JsonConvert.DeserializeObject(responseJson);

            return responseObject.choices[0].message.content;
        }
    }
}
