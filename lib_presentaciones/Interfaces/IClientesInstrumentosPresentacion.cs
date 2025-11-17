using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface IClientesInstrumentosPresentacion
    {
        Task<List<ClientesInstrumentos>> Listar();
        Task<List<ClientesInstrumentos>> Filtro(ClientesInstrumentos? entidad);
        Task<ClientesInstrumentos?> Guardar(ClientesInstrumentos? entidad);
        Task<ClientesInstrumentos?> Modificar(ClientesInstrumentos? entidad);
        Task<ClientesInstrumentos?> Borrar(ClientesInstrumentos? entidad);
    }
}
