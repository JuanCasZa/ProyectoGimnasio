using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface IMembresiasPresentacion
    {
        Task<List<Membresias>> Listar(string Token);

        Task<List<Membresias>> Filtro(Membresias? entidad, string Token);
        Task<Membresias?> Guardar(Membresias? entidad, string Token);
        Task<Membresias?> Modificar(Membresias? entidad, string Token);
        Task<Membresias?> Borrar(Membresias? entidad, string Token);
    }
}
