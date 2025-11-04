using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface IClientesClasesGrupalesPresentacion
    {
        Task<List<ClientesClasesGrupales>> Listar();
        Task<ClientesClasesGrupales?> Guardar(ClientesClasesGrupales? entidad);
        Task<ClientesClasesGrupales?> Modificar(ClientesClasesGrupales? entidad);
        Task<ClientesClasesGrupales?> Borrar(ClientesClasesGrupales? entidad);
    }
}