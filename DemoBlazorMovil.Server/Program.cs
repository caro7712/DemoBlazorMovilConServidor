using DemoBlazorMovil.Server.Data;
using DemoBlazorMovil.Server.Services;
using DemoBlazorMovil.Shared.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Registrar DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Registrar servicios con sus interfaces
builder.Services.AddScoped<IProductoService, ProductoService>();
builder.Services.AddScoped<IServiceUsuario,UsuarioService>();

// Agregar controladores
builder.Services.AddControllers();

// Configuración Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
