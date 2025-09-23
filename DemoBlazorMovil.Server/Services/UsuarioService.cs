using DemoBlazorMovil.Server.Data;
using DemoBlazorMovil.Server.Models;
using DemoBlazorMovil.Shared.Models;
using DemoBlazorMovil.Shared.Services;
using Microsoft.EntityFrameworkCore;

namespace DemoBlazorMovil.Server.Services
{
    public class UsuarioService : IServiceUsuario
    {
        private readonly ApplicationDbContext _context;

        public UsuarioService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<UsuarioDTO>> GetUsuariosAsync()
        {
            // Traemos todos los usuarios a memoria
            var usuarios = await _context.Usuario.ToListAsync();

            // Convertimos a DTO en memoria
            return usuarios.Select(u => ToDTO(u)).ToList();
        }

        public async Task<UsuarioDTO?> GetUsuarioAsync(int id)
        {
            var u = await _context.Usuario.FirstOrDefaultAsync(x => x.Id == id);
            return u == null ? null : ToDTO(u);
        }

        public async Task<UsuarioDTO> AddUsuarioAsync(UsuarioDTO usuario)
        {
            var entity = new Usuario
            {
                Name = usuario.Name,
                Correo = usuario.Correo,
                Domicilio = usuario.Domicilio,
                Imagen = usuario.Imagen,
                Contraseña = usuario.Contraseña,
                Rol = usuario.Rol
            };

            _context.Usuario.Add(entity);
            await _context.SaveChangesAsync();

            usuario.Id = entity.Id;
            return usuario;
        }

        public async Task<UsuarioDTO?> UpdateUsuarioAsync(UsuarioDTO usuario)
        {
            var existente = await _context.Usuario.FirstOrDefaultAsync(u => u.Id == usuario.Id);
            if (existente == null) return null;

            existente.Name = usuario.Name;
            existente.Correo = usuario.Correo;
            existente.Domicilio = usuario.Domicilio;
            existente.Imagen = usuario.Imagen;
            existente.Contraseña = usuario.Contraseña;
            existente.Rol = usuario.Rol;

            await _context.SaveChangesAsync();
            return usuario;
        }

        public async Task<bool> DeleteUsuarioAsync(int id)
        {
            var usuario = await _context.Usuario.FirstOrDefaultAsync(u => u.Id == id);
            if (usuario == null) return false;

            _context.Usuario.Remove(usuario);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<UsuarioDTO?> LoginAsync(string nombre, string contraseña)
        {
            var usuario = await _context.Usuario
                .FirstOrDefaultAsync(u => u.Name == nombre && u.Contraseña == contraseña);

            return usuario == null ? null : ToDTO(usuario);
        }

        private UsuarioDTO ToDTO(Usuario u) => new UsuarioDTO
        {
            Id = u.Id,
            Name = u.Name,
            Correo = u.Correo,
            Domicilio = u.Domicilio,
            Imagen = u.Imagen,
            Contraseña = u.Contraseña,
            Rol = u.Rol
        };
    }
}

