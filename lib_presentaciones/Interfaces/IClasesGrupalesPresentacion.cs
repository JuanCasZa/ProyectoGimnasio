using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface IClasesGrupalesPresentacion
    {
        Task<List<ClasesGrupales>> Listar(string Token);

        Task<List<ClasesGrupales>> Filtro(ClasesGrupales? entidad, string Token);
        Task<ClasesGrupales?> Guardar(ClasesGrupales? entidad, string Token);
        Task<ClasesGrupales?> Modificar(ClasesGrupales? entidad, string Token);
        Task<ClasesGrupales?> Borrar(ClasesGrupales? entidad, string Token);
    }
}
