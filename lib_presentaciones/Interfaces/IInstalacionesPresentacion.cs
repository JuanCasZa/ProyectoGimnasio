using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface IInstalacionesPresentacion
    {
        Task<List<Instalaciones>> Listar();
        Task<List<Instalaciones>> Filtro(Instalaciones? entidad);
        Task<Instalaciones?> Guardar(Instalaciones? entidad);
        Task<Instalaciones?> Modificar(Instalaciones? entidad);
        Task<Instalaciones?> Borrar(Instalaciones? entidad);
    }
}