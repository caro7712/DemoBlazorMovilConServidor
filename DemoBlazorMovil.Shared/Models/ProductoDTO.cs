namespace DemoBlazorMovil.Shared.Models
{
    public class ProductoDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Foto { get; set; } = string.Empty;
        public int Precio { get; set; }
        public int Stock { get; set; }
    }
}
