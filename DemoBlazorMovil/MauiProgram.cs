    using Microsoft.Extensions.Logging;
    using System.Net.Http;
    using DemoBlazorMovil.Shared.Services;
    using DemoBlazorMovil.Services;

    namespace DemoBlazorMovil
    {
        public static class MauiProgram
        {
            public static MauiApp CreateMauiApp()
            {
                var builder = MauiApp.CreateBuilder();

                // Configuración básica de la app
                builder
                    .UseMauiApp<App>()
                    .ConfigureFonts(fonts =>
                    {
                        fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    });

                // Habilitar Blazor WebView
                builder.Services.AddMauiBlazorWebView();

    #if DEBUG
                // Herramientas de desarrollo y logging en modo debug
                builder.Services.AddBlazorWebViewDeveloperTools();
                builder.Logging.AddDebug();
    #endif

                // -------------------------------
                // HttpClient según entorno
                // -------------------------------
                builder.Services.AddScoped(sp =>
                {
                    string baseUrl;

    #if DEBUG && ANDROID
                    baseUrl = "http://10.0.2.2:7001/api/"; // Emulador Android
    #elif DEBUG && WINDOWS
                    baseUrl = "https://localhost:7001/api/"; // Windows debug
    #else
                    baseUrl = "https://DemoBlazorMovil.somee.com/api/"; // Producción
    #endif

                    return new HttpClient
                    {
                        BaseAddress = new Uri(baseUrl)
                    };
                });

                // -------------------------------
                // Servicios Http
                // -------------------------------
                builder.Services.AddScoped<IServiceUsuario, UsuarioHttpService>();
                builder.Services.AddScoped<IProductoService, ProductoHttpService>();

                return builder.Build();
            }
        }
    }
