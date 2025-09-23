using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoBlazorMovil.Server.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Domicilio { get; set; }
        public string Correo { get; set; }
        public string Contraseña { get; set; }
        public string Rol { get; set; }
        public string Imagen { get; set; } = "usuario1.png";

        public Usuario() { }

        public Usuario(int id, string name, string domicilio, string correo, string contraseña, string rol, string imagen = "usuario1.png")
        {
            Id = id;
            Name = name;
            Domicilio = domicilio;
            Correo = correo;
            Contraseña = contraseña;
            Rol = rol;
            Imagen = imagen;
        }
    }
}



