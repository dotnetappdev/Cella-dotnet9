using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Cella.Infrastructure
{
    public class MyApiService<T>
    {
        private readonly string _baseUrl;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly JsonSerializerOptions _jsonSerializerOptions;
        private string _bearerToken;

        public MyApiService(string baseUrl, IHttpClientFactory httpClientFactory)
        {
            _baseUrl = baseUrl;
            _httpClientFactory = httpClientFactory;
            _jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
        }

        private HttpClient CreateHttpClient()
        {
            var httpClient = _httpClientFactory.CreateClient();
            if (!string.IsNullOrEmpty(_bearerToken))
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _bearerToken);
            }
            return httpClient;
        }

        public async Task<bool> LoginAsync(string username, string password)
        {
            var httpClient = CreateHttpClient();
            var loginModel = new { Username = username, Password = password };
            var jsonContent = new StringContent(JsonSerializer.Serialize(loginModel), Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync($"{_baseUrl}/api/account/login", jsonContent);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var content = await response.Content.ReadAsStringAsync();
                var tokenResponse = JsonSerializer.Deserialize<TokenResponse>(content, _jsonSerializerOptions);
                _bearerToken = tokenResponse.Token;
                return true;
            }
            return false;
        }

        public async Task LogoutAsync()
        {
            var httpClient = CreateHttpClient();
            var response = await httpClient.PostAsync($"{_baseUrl}/api/account/logout", null);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                _bearerToken = null;
            }
        }

        public async Task<bool> RegisterAsync(string username, string password, string email)
        {
            var httpClient = CreateHttpClient();
            var registerModel = new { Username = username, Password = password, Email = email };
            var jsonContent = new StringContent(JsonSerializer.Serialize(registerModel), Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync($"{_baseUrl}/api/register", jsonContent);
            return response.StatusCode == System.Net.HttpStatusCode.OK;
        }

        public async Task<bool> ForgotPasswordAsync(string email)
        {
            var httpClient = CreateHttpClient();
            var forgotPasswordModel = new { Email = email };
            var jsonContent = new StringContent(JsonSerializer.Serialize(forgotPasswordModel), Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync($"{_baseUrl}/api/forgotpassword", jsonContent);
            return response.StatusCode == System.Net.HttpStatusCode.OK;
        }

        public async Task<bool> ResetPasswordAsync(string email, string token, string newPassword)
        {
            var httpClient = CreateHttpClient();
            var resetPasswordModel = new { Email = email, Token = token, NewPassword = newPassword };
            var jsonContent = new StringContent(JsonSerializer.Serialize(resetPasswordModel), Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync($"{_baseUrl}/api/resetpassword", jsonContent);
            return response.StatusCode == System.Net.HttpStatusCode.OK;
        }

        private async Task<T> MakeRequestAsync(string endpoint)
        {
            var httpClient = CreateHttpClient();
            var response = await httpClient.GetAsync($"{_baseUrl}{endpoint}");
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<T>(content, _jsonSerializerOptions);
            }
            throw new HttpRequestException($"Request to {endpoint} failed with status code {response.StatusCode}");
        }

        public async Task<T> GetDataAsync(string endpoint)
        {
            return await MakeRequestAsync(endpoint);
        }

        public async Task<T[]> GetAllDataAsync(string endpoint)
        {
            var httpClient = CreateHttpClient();
            var response = await httpClient.GetAsync($"{_baseUrl}{endpoint}");
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<T[]>(content, _jsonSerializerOptions);
            }
            throw new HttpRequestException($"Request to {endpoint} failed with status code {response.StatusCode}");
        }

        public async Task<T> PostDataAsync(string endpoint, T data)
        {
            var httpClient = CreateHttpClient();
            var jsonContent = new StringContent(JsonSerializer.Serialize(data), Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync($"{_baseUrl}{endpoint}", jsonContent);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<T>(content, _jsonSerializerOptions);
            }
            throw new HttpRequestException($"Request to {endpoint} failed with status code {response.StatusCode}");
        }

        public async Task<T> PutDataAsync(string endpoint, T data)
        {
            var httpClient = CreateHttpClient();
            var jsonContent = new StringContent(JsonSerializer.Serialize(data), Encoding.UTF8, "application/json");
            var response = await httpClient.PutAsync($"{_baseUrl}{endpoint}", jsonContent);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<T>(content, _jsonSerializerOptions);
            }
            throw new HttpRequestException($"Request to {endpoint} failed with status code {response.StatusCode}");
        }

        public async Task<bool> DeleteDataAsync(string endpoint)
        {
            var httpClient = CreateHttpClient();
            var response = await httpClient.DeleteAsync($"{_baseUrl}{endpoint}");
            return response.StatusCode == System.Net.HttpStatusCode.OK;
        }
    }

    public class TokenResponse
    {
        public string Token { get; set; }
    }
}
