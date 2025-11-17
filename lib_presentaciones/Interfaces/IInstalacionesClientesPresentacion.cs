using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface IInstalacionesClientesPresentacion
    {
        Task<List<InstalacionesClientes>> Listar();
        Task<List<InstalacionesClientes>> Filtro(InstalacionesClientes? entidad);
        Task<InstalacionesClientes?> Guardar(InstalacionesClientes? entidad);
        Task<InstalacionesClientes?> Modificar(InstalacionesClientes? entidad);
        Task<InstalacionesClientes?> Borrar(InstalacionesClientes? entidad);
    }
}
