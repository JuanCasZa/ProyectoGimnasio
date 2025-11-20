using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface IClientesPresentacion
    {
        Task<List<Clientes>> Listar(string Token);

        Task<List<Clientes>> Filtro(Clientes? entidad, string Token);
        Task<Clientes?> Guardar(Clientes? entidad, string Token);
        Task<Clientes?> Modificar(Clientes? entidad, string Token);
        Task<Clientes?> Borrar(Clientes? entidad, string Token);
    }
}
