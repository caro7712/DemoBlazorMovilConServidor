using DemoBlazorMovil.Server.Data;
using DemoBlazorMovil.Server.Models;
using DemoBlazorMovil.Shared.Models;
using DemoBlazorMovil.Shared.Services;
using Microsoft.EntityFrameworkCore;

namespace DemoBlazorMovil.Server.Services
{
    public class ProductoService : IProductoService
    {
        private readonly ApplicationDbContext _context;

        public ProductoService(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET todos los productos
        public async Task<List<ProductoDTO>> GetProductosAsync()
        {
            return await _context.Producto
                .Select(p => new ProductoDTO
                {
                    Id = p.Id,
                    Name = p.Name,
                    Foto = p.Foto,
                    Precio = p.Precio,
                    Stock = p.Stock
                })
                .ToListAsync();
        }

        // GET producto por Id
        public async Task<ProductoDTO?> GetProductoAsync(int id)
        {
            var p = await _context.Producto
                .Where(p => p.Id == id)
                .Select(p => new ProductoDTO
                {
                    Id = p.Id,
                    Name = p.Name,
                    Foto = p.Foto,
                    Precio = p.Precio,
                    Stock = p.Stock
                })
                .FirstOrDefaultAsync();

            return p;
        }

        // POST agregar producto
        public async Task<ProductoDTO> AddProductoAsync(ProductoDTO producto)
        {
            var entity = new Producto
            {
                Name = producto.Name,
                Foto = producto.Foto,
                Precio = producto.Precio,
                Stock = producto.Stock
            };

            _context.Producto.Add(entity);
            await _context.SaveChangesAsync();

            producto.Id = entity.Id; // asignamos Id generado
            return producto;
        }

        // PUT actualizar producto
        public async Task<ProductoDTO?> UpdateProductoAsync(ProductoDTO producto)
        {
            var existente = await _context.Producto.FirstOrDefaultAsync(p => p.Id == producto.Id);
            if (existente == null) return null;

            existente.Name = producto.Name;
            existente.Foto = producto.Foto;
            existente.Precio = producto.Precio;
            existente.Stock = producto.Stock;

            await _context.SaveChangesAsync();
            return producto;
        }

        // DELETE producto
        public async Task<bool> DeleteProductoAsync(int id)
        {
            var producto = await _context.Producto.FirstOrDefaultAsync(p => p.Id == id);
            if (producto == null) return false;

            _context.Producto.Remove(producto);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
