using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface IInstalacionesPresentacion
    {
        Task<List<Instalaciones>> Listar();
        Task<Instalaciones?> Guardar(Instalaciones? entidad);
        Task<Instalaciones?> Modificar(Instalaciones? entidad);
        Task<Instalaciones?> Borrar(Instalaciones? entidad);
    }
}