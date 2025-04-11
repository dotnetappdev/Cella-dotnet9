using Cella.Models;
using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace Cella.Application
{

    public class ApiService : IDisposable
    {
        private readonly HttpClient _client;
        private bool _disposed = false;

        public ApiService()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("https://cella-api.dotnetappdevni.com"); // Base API URL
            _client.DefaultRequestHeaders.Add("Accept", "application/json"); // Set headers if required
        }

        public async Task<string> PostStockItemViewModel(string endpoint, StockItemVm? stockItemVM)
        {
            try
            {
                // Serialize the StockItemVm object into a JSON string using System.Text.Json
                string json = JsonSerializer.Serialize(stockItemVM);

                // Create the StringContent using the serialized JSON string
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                // Send the POST request
                HttpResponseMessage response = await _client.PostAsync(endpoint, content);

                // Ensure a successful response
                response.EnsureSuccessStatusCode();

                // Return the response content as a string
                return await response.Content.ReadAsStringAsync();
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Request error: {ex.Message}");
                return null;
            }
        }



        public void Dispose()
        {
            if (!_disposed)
            {
                _client.Dispose();
                _disposed = true;
            }
        }
    }
}