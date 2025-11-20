using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface IClientesSuplementosPresentacion
    {
        Task<List<ClientesSuplementos>> Listar(string Token);

        Task<List<ClientesSuplementos>> Filtro(ClientesSuplementos? entidad, string Token);
        Task<ClientesSuplementos?> Guardar(ClientesSuplementos? entidad, string Token);
        Task<ClientesSuplementos?> Modificar(ClientesSuplementos? entidad, string Token);
        Task<ClientesSuplementos?> Borrar(ClientesSuplementos? entidad, string Token);
    }
}
