using Microsoft.EntityFrameworkCore;
using DemoBlazorMovil.Server.Models;

namespace DemoBlazorMovil.Server.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Producto> Producto { get; set; }
    }
}