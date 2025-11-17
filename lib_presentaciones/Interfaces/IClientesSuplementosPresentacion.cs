using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface IClientesSuplementosPresentacion
    {
        Task<List<ClientesSuplementos>> Listar();
        Task<List<ClientesSuplementos>> Filtro(ClientesSuplementos? entidad);
        Task<ClientesSuplementos?> Guardar(ClientesSuplementos? entidad);
        Task<ClientesSuplementos?> Modificar(ClientesSuplementos? entidad);
        Task<ClientesSuplementos?> Borrar(ClientesSuplementos? entidad);
    }
}
