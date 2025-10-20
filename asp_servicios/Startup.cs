using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using asp_servicios.Controllers;
using Microsoft.AspNetCore.Server.Kestrel.Core;

namespace asp_servicios
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public static IConfiguration? Configuration { set; get; }

        public void ConfigureServices(WebApplicationBuilder builder, IServiceCollection services)
        {
            services.Configure<KestrelServerOptions>(x => {
                x.AllowSynchronousIO = true;
            });
            services.Configure<IISServerOptions>(x => { x.AllowSynchronousIO = true; });
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            //services.AddSwaggerGen();

            // Repositorios
            services.AddScoped<IConexion, Conexion>();
            services.AddScoped<IBeneficiosMembresiasAplicacion, BeneficiosMembresiasAplicacion>();
            services.AddScoped<IClasesGrupalesAplicacion, ClasesGrupalesAplicacion>();
            services.AddScoped<IClientesAplicacion, ClientesAplicacion>();
            services.AddScoped<IClientesClasesGrupalesAplicacion, ClientesClasesGrupalesAplicacion>();
            services.AddScoped<IClientesInstrumentosAplicacion, ClientesInstrumentosAplicacion>();
            services.AddScoped<IClientesMembresiasAplicacion, ClientesMembresiasAplicacion>();
            services.AddScoped<IClientesSuplementosAplicacion, ClientesSuplementosAplicacion>();
            services.AddScoped<IEmpleadosAplicacion, EmpleadosAplicacion>();
            services.AddScoped<IInstalacionesAplicacion, InstalacionesAplicacion>();
            services.AddScoped<IInstalacionesClientesAplicacion, InstalacionesClientesAplicacion>();
            services.AddScoped<IInstalacionesEmpleadosAplicacion, InstalacionesEmpleadosAplicacion>();
            services.AddScoped<IInstrumentosAplicacion, InstrumentosAplicacion>();
            services.AddScoped<IMembresiasAplicacion, MembresiasAplicacion>();
            services.AddScoped<IProveedoresAplicacion, ProveedoresAplicacion>();
            services.AddScoped<ISuplementosAplicacion, SuplementosAplicacion>();

            services.AddScoped<TokenAplicacion, TokenAplicacion>();
            // Controladores
            services.AddScoped<TokenController, TokenController>();
            services.AddCors(o => o.AddDefaultPolicy(b => b.AllowAnyOrigin()));
        }

        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                //app.UseSwagger();
                //app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
            app.UseRouting();
            app.UseCors();
        }
    }
}
