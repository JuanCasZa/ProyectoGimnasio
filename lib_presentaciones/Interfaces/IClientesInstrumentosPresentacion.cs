using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface IClientesInstrumentosPresentacion
    {
        Task<List<ClientesInstrumentos>> Listar(string Token);

        Task<List<ClientesInstrumentos>> Filtro(ClientesInstrumentos? entidad, string Token);
        Task<ClientesInstrumentos?> Guardar(ClientesInstrumentos? entidad, string Token);
        Task<ClientesInstrumentos?> Modificar(ClientesInstrumentos? entidad, string Token);
        Task<ClientesInstrumentos?> Borrar(ClientesInstrumentos? entidad, string Token);
    }
}
