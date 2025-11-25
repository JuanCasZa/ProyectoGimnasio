using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface IInstalacionesPresentacion
    {
        Task<List<Instalaciones>> Listar(string Token);

        Task<List<Instalaciones>> Filtro(Instalaciones? entidad, string Token);
        Task<Instalaciones?> Guardar(Instalaciones? entidad, string Token);
        Task<Instalaciones?> Modificar(Instalaciones? entidad, string Token);
        Task<Instalaciones?> Borrar(Instalaciones? entidad, string Token);
    }
}
