using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface IInstalacionesClientesPresentacion
    {
        Task<List<InstalacionesClientes>> Listar(string Token);

        Task<List<InstalacionesClientes>> Filtro(InstalacionesClientes? entidad, string Token);
        Task<InstalacionesClientes?> Guardar(InstalacionesClientes? entidad, string Token);
        Task<InstalacionesClientes?> Modificar(InstalacionesClientes? entidad, string Token);
        Task<InstalacionesClientes?> Borrar(InstalacionesClientes? entidad, string Token);
    }
}
