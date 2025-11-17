using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface IClasesGrupalesPresentacion
    {
        Task<List<ClasesGrupales>> Listar();
        Task<List<ClasesGrupales>> Filtro(ClasesGrupales? entidad);
        Task<ClasesGrupales?> Guardar(ClasesGrupales? entidad);
        Task<ClasesGrupales?> Modificar(ClasesGrupales? entidad);
        Task<ClasesGrupales?> Borrar(ClasesGrupales? entidad);
    }
}
