using lib_repositorios.Interfaces;
using lib_repositorios.Implementaciones;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddScoped<IConexion, Conexion>();
builder.Services.AddScoped<IClientesMembresiasAplicacion, ClientesMembresiasAplicacion>();
builder.Services.AddScoped<IInstalacionesClientesAplicacion, InstalacionesClientesAplicacion>();
builder.Services.AddScoped<IInstalacionesEmpleadosAplicacion, InstalacionesEmpleadosAplicacion>();
builder.Services.AddScoped<IClientesSuplementosAplicacion, ClientesSuplementosAplicacion>();
builder.Services.AddScoped<IClientesClasesGrupalesAplicacion, ClientesClasesGrupalesAplicacion>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();