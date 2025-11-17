using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface ISuplementosPresentacion
    {
        Task<List<Suplementos>> Listar();
        Task<List<Suplementos>> Filtro(Suplementos? entidad);
        Task<Suplementos?> Guardar(Suplementos? entidad);
        Task<Suplementos?> Modificar(Suplementos? entidad);
        Task<Suplementos?> Borrar(Suplementos? entidad);
    }
}
