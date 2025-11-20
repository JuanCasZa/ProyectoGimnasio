using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface IClientesClasesGrupalesPresentacion
    {
        Task<List<ClientesClasesGrupales>> Listar(string Token);

        Task<List<ClientesClasesGrupales>> Filtro(ClientesClasesGrupales? entidad, string Token);
        Task<ClientesClasesGrupales?> Guardar(ClientesClasesGrupales? entidad, string Token);
        Task<ClientesClasesGrupales?> Modificar(ClientesClasesGrupales? entidad, string Token);
        Task<ClientesClasesGrupales?> Borrar(ClientesClasesGrupales? entidad, string Token);
    }
}
