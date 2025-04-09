using Cella.Models;
using System.Net.Http.Json;
namespace Cella.Hybrid.Services
{

    public class StockItemService
    {
        private readonly HttpClient _httpClient;

        public StockItemService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<StockItem>> GetStockItemsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<StockItem>>("api/stock");
        }

        public async Task<StockItem> GetStockItemByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<StockItem>($"api/stockitems/{id}");
        }

        public async Task<bool> DeleteStockItemAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/stockitems/{id}");
            return response.IsSuccessStatusCode;
        }

        public async Task<StockItem> AddStockItemAsync(StockItem stockItem)
        {
            var response = await _httpClient.PostAsJsonAsync("api/stockitems", stockItem);
            return await response.Content.ReadFromJsonAsync<StockItem>();
        }
    }

}
