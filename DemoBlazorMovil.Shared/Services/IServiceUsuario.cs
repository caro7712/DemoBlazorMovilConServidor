using DemoBlazorMovil.Shared.Models;

namespace DemoBlazorMovil.Shared.Services
{

    public interface IServiceUsuario
    {
        Task<List<UsuarioDTO>> GetUsuariosAsync();
        Task<UsuarioDTO?> GetUsuarioAsync(int id);
        Task<UsuarioDTO> AddUsuarioAsync(UsuarioDTO usuario);
        Task<UsuarioDTO?> UpdateUsuarioAsync(UsuarioDTO usuario);
        Task<bool> DeleteUsuarioAsync(int id);
        Task<UsuarioDTO?> LoginAsync(string correo, string contraseña);
    }
}