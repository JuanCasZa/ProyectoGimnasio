using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface IInstrumentosPresentacion
    {
        Task<List<Instrumentos>> Listar(string Token);

        Task<List<Instrumentos>> Filtro(Instrumentos? entidad, string Token);
        Task<Instrumentos?> Guardar(Instrumentos? entidad, string Token);
        Task<Instrumentos?> Modificar(Instrumentos? entidad, string Token);
        Task<Instrumentos?> Borrar(Instrumentos? entidad, string Token);
    }
}
