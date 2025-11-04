using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface IInstrumentosPresentacion
    {
        Task<List<Instrumentos>> Listar();
        Task<Instrumentos?> Guardar(Instrumentos? entidad);
        Task<Instrumentos?> Modificar(Instrumentos? entidad);
        Task<Instrumentos?> Borrar(Instrumentos? entidad);
    }
}
