using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface ISuplementosPresentacion
    {
        Task<List<Suplementos>> Listar(string Token);

        Task<List<Suplementos>> Filtro(Suplementos? entidad, string Token);
        Task<Suplementos?> Guardar(Suplementos? entidad, string Token);
        Task<Suplementos?> Modificar(Suplementos? entidad, string Token);
        Task<Suplementos?> Borrar(Suplementos? entidad, string Token);
    }
}
