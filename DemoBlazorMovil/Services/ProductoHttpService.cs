using DemoBlazorMovil.Shared.Models;
using DemoBlazorMovil.Shared.Services;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace DemoBlazorMovil.Services
{
    public class ProductoHttpService : IProductoService
    {
        private readonly HttpClient _http;

        public ProductoHttpService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<ProductoDTO>> GetProductosAsync()
        {
            var productos = await _http.GetFromJsonAsync<List<ProductoDTO>>("api/Productos");
            return productos ?? new List<ProductoDTO>();
        }

        public async Task<ProductoDTO?> GetProductoAsync(int id)
        {
            return await _http.GetFromJsonAsync<ProductoDTO>($"api/Productos/{id}");
        }

        public async Task<ProductoDTO> AddProductoAsync(ProductoDTO producto)
        {
            var response = await _http.PostAsJsonAsync("api/Productos", producto);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<ProductoDTO>() ?? producto;
        }

        public async Task<ProductoDTO?> UpdateProductoAsync(ProductoDTO producto)
        {
            var response = await _http.PutAsJsonAsync($"api/Productos/{producto.Id}", producto);
            if (!response.IsSuccessStatusCode) return null;
            return await response.Content.ReadFromJsonAsync<ProductoDTO>();
        }

        public async Task<bool> DeleteProductoAsync(int id)
        {
            var response = await _http.DeleteAsync($"api/Productos/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
