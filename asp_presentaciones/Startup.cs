using lib_presentaciones.Implementaciones;
using lib_presentaciones.Interfaces;

namespace asp_presentaciones
{
    public class Startup
    {
        public static IConfiguration? Configuration { get; set; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(WebApplicationBuilder builder, IServiceCollection services)
        {
            //Presentaciones--Inyeccion de dependencias
            services.AddScoped<IBeneficiosMembresiasPresentacion, BeneficiosMembresiasPresentacion>();
            services.AddScoped<IClasesGrupalesPresentacion, ClasesGrupalesPresentacion>();
            services.AddScoped<IClientesClasesGrupalesPresentacion, ClientesClasesGrupalesPresentacion>();
            services.AddScoped<IClientesInstrumentosPresentacion, ClientesInstrumentosPresentacion>();
            services.AddScoped<IClientesMembresiasPresentacion, ClientesMembresiasPresentacion>();
            services.AddScoped<IClientesPresentacion, ClientesPresentacion>();
            services.AddScoped<IClientesSuplementosPresentacion, ClientesSuplementosPresentacion>();
            services.AddScoped<IEmpleadosPresentacion, EmpleadosPresentacion>();
            services.AddScoped<IInstalacionesClientesPresentacion, InstalacionesClientesPresentacion>();
            services.AddScoped<IInstalacionesEmpleadosPresentacion, InstalacionesEmpleadosPresentacion>();
            services.AddScoped<IInstalacionesPresentacion, InstalacionesPresentacion>();
            services.AddScoped<IInstrumentosPresentacion, InstrumentosPresentacion>();
            services.AddScoped<IMembresiasPresentacion, MembresiasPresentacion>();
            services.AddScoped<ISuplementosPresentacion, SuplementosPresentacion>();
            services.AddScoped<IProveedoresPresentacion, ProveedoresPresentacion>();

            services.AddScoped<IUsuariosPresentacion, UsuariosPresentacion>();

            //Para Razor Pages
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddRazorPages();
            services.AddSession(options => { options.IdleTimeout = TimeSpan.FromMinutes(30); });

        }

        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
            }
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.UseSession();
            app.MapRazorPages();
            app.Run();
        }
    }        
}
