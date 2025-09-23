using DemoBlazorMovil.Shared.Models;
using DemoBlazorMovil.Shared.Services;
using System.Net.Http;
using System.Net.Http.Json;

namespace DemoBlazorMovil.Services
{
    public class UsuarioHttpService : IServiceUsuario
    {
        private readonly HttpClient _http;
        private const string baseUrl = "Usuario"; // Relativa al BaseAddress

        public UsuarioHttpService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<UsuarioDTO>> GetUsuariosAsync()
        {
            return await _http.GetFromJsonAsync<List<UsuarioDTO>>(baseUrl)
                   ?? new List<UsuarioDTO>();
        }

        public async Task<UsuarioDTO?> GetUsuarioAsync(int id)
        {
            return await _http.GetFromJsonAsync<UsuarioDTO>($"{baseUrl}/{id}");
        }

        public async Task<UsuarioDTO> AddUsuarioAsync(UsuarioDTO usuario)
        {
            var response = await _http.PostAsJsonAsync(baseUrl, usuario);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<UsuarioDTO>()
                   ?? throw new Exception("Error al crear el usuario");
        }

        public async Task<UsuarioDTO?> UpdateUsuarioAsync(UsuarioDTO usuario)
        {
            var response = await _http.PutAsJsonAsync($"{baseUrl}/{usuario.Id}", usuario);
            if (!response.IsSuccessStatusCode)
                return null;

            return await response.Content.ReadFromJsonAsync<UsuarioDTO>();
        }

        public async Task<bool> DeleteUsuarioAsync(int id)
        {
            var response = await _http.DeleteAsync($"{baseUrl}/{id}");
            return response.IsSuccessStatusCode;
        }

        public async Task<UsuarioDTO?> LoginAsync(string nombre, string contraseña)
        {
            var loginRequest = new LoginRequest
            {
                Nombre = nombre,
                Contraseña = contraseña
            };

            var response = await _http.PostAsJsonAsync($"{baseUrl}/Login", loginRequest);

            if (!response.IsSuccessStatusCode)
                return null;

            return await response.Content.ReadFromJsonAsync<UsuarioDTO>();
        }
    }
}
