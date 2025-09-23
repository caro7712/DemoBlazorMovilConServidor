using System.Collections.Generic;
using System.Threading.Tasks;
using DemoBlazorMovil.Shared.Models;

namespace DemoBlazorMovil.Shared.Services
{
    public interface IProductoService
    {
        Task<List<ProductoDTO>> GetProductosAsync();
        Task<ProductoDTO?> GetProductoAsync(int id);
        Task<ProductoDTO> AddProductoAsync(ProductoDTO producto);
        Task<ProductoDTO?> UpdateProductoAsync(ProductoDTO producto);
        Task<bool> DeleteProductoAsync(int id);
    }
}
