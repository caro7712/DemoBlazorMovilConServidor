using DemoBlazorMovil.Server.Models;
using DemoBlazorMovil.Server.Services;
using DemoBlazorMovil.Shared.Models;
using DemoBlazorMovil.Shared.Services;
using Microsoft.AspNetCore.Mvc;

namespace DemoBlazorMovil.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoService _productoService; // ✅ usar la interfaz

        public ProductoController(IProductoService productoService) // ✅ inyectar interfaz
        {
            _productoService = productoService;
        }

        private Producto ToEntity(ProductoDTO dto)
        {
            return new Producto
            {
                Id = dto.Id,
                Name = dto.Name,
                Precio = dto.Precio,
                Stock = dto.Stock,
                Foto = dto.Foto
            };
        }

        private ProductoDTO ToDTO(Producto entity)
        {
            return new ProductoDTO
            {
                Id = entity.Id,
                Name = entity.Name,
                Precio = entity.Precio,
                Stock = entity.Stock,
                Foto = entity.Foto
            };
        }

        // GET: api/Producto
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductoDTO>>> GetAll()
        {
            var productos = await _productoService.GetProductosAsync();
            return Ok(productos);
        }

        // GET: api/Producto/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductoDTO>> GetById(int id)
        {
            var producto = await _productoService.GetProductoAsync(id);
            if (producto == null)
                return NotFound();

            return Ok(producto);
        }

        // POST: api/Producto
        [HttpPost]
        public async Task<ActionResult<ProductoDTO>> Create(ProductoDTO productoDto)
        {
            var producto = await _productoService.AddProductoAsync(productoDto);
            return CreatedAtAction(nameof(GetById), new { id = producto.Id }, producto);
        }

        // PUT: api/Producto/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, ProductoDTO productoDto)
        {
            if (id != productoDto.Id)
                return BadRequest();

            var updated = await _productoService.UpdateProductoAsync(productoDto);
            if (updated == null)
                return NotFound();

            return NoContent();
        }

        // DELETE: api/Producto/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _productoService.DeleteProductoAsync(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}
