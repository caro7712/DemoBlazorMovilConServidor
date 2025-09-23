using DemoBlazorMovil.Server.Models;
using DemoBlazorMovil.Server.Services;
using DemoBlazorMovil.Shared.Models;
using DemoBlazorMovil.Shared.Services;
using Microsoft.AspNetCore.Mvc;

namespace DemoBlazorMovil.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IServiceUsuario _usuarioService;

        public UsuarioController(IServiceUsuario usuarioService)
        {
            _usuarioService = usuarioService;
        }

        private Usuario ToEntity(UsuarioDTO dto)
        {
            return new Usuario
            {
                Id = dto.Id,
                Name = dto.Name,
                Domicilio = dto.Domicilio,
                Correo = dto.Correo,
                Contraseña = dto.Contraseña,
                Rol = dto.Rol,
                Imagen = dto.Imagen,
            };
        }

        private UsuarioDTO ToDTO(Usuario entity)
        {
            return new UsuarioDTO
            {
                Id = entity.Id,
                Name = entity.Name,
                Domicilio = entity.Domicilio,
                Correo = entity.Correo,
                Contraseña = entity.Contraseña,
                Rol = entity.Rol,
                Imagen = entity.Imagen,
            };
        }

        // GET: api/Usuario
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioDTO>>> GetAll()
        {
            var usuarios = await _usuarioService.GetUsuariosAsync();
            return Ok(usuarios);
        }

        // GET: api/Usuario/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioDTO>> GetById(int id)
        {
            var usuario = await _usuarioService.GetUsuarioAsync(id);
            if (usuario == null)
                return NotFound();

            return Ok(usuario);
        }

        // POST: api/Usuario
        [HttpPost]
        public async Task<ActionResult<UsuarioDTO>> Create(UsuarioDTO usuarioDto)
        {
            var usuario = await _usuarioService.AddUsuarioAsync(usuarioDto);
            return CreatedAtAction(nameof(GetById), new { id = usuario.Id }, usuario);
        }

        // PUT: api/Usuario/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, UsuarioDTO usuarioDto)
        {
            if (id != usuarioDto.Id)
                return BadRequest();

            var updated = await _usuarioService.UpdateUsuarioAsync(usuarioDto);
            if (updated == null)
                return NotFound();

            return NoContent();
        }

        // DELETE: api/Usuario/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _usuarioService.DeleteUsuarioAsync(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }

        // LOGIN
        [HttpPost("Login")]
        public async Task<ActionResult<UsuarioDTO>> Login([FromBody] LoginRequest request)
        {
            var usuario = await _usuarioService.LoginAsync(request.Nombre, request.Contraseña);

            if (usuario == null)
                return Unauthorized();

            return Ok(usuario);
        }
    }
}
