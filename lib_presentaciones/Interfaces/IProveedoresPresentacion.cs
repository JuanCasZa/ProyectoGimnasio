using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface IProveedoresPresentacion
    {
        Task<List<Proveedores>> Listar(string Token);

        Task<List<Proveedores>> Filtro(Proveedores? entidad, string Token);
        Task<Proveedores?> Guardar(Proveedores? entidad, string Token);
        Task<Proveedores?> Modificar(Proveedores? entidad, string Token);
        Task<Proveedores?> Borrar(Proveedores? entidad, string Token);
    }
}
