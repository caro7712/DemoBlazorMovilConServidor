
namespace DemoBlazorMovil.Server.Models;

    public class Producto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Foto { get; set; }

        public int Precio { get; set; }
        
        public int Stock { get; set; }
        public Producto() { }
        public Producto(int id, string name, string foto, int precio, int stock)
        {
                Id = id;
                Name = name;
                Foto = foto;
                Precio = precio;
                Stock = stock;
        
        }
    
    }
