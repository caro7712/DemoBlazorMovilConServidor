using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoBlazorMovil.Shared.Models
{
    public class UsuarioDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Domicilio { get; set; }
        public string Correo { get; set; }
        public string Contraseña { get; set; }
        public string Rol {  get; set; }
        public string Imagen { get; set; } = "usuario1.png";
    }
}
