using lib_dominio.Entidades;

namespace lib_repositorios.Interfaces
{
    public interface IInstalacionesAplicacion
    {
        void Configurar(string StringConexion);
        List<Instalaciones> Listar();

        List<Instalaciones> Filtro(Instalaciones? entidad);
        Instalaciones? Guardar(Instalaciones? entidad);
        Instalaciones? Modificar(Instalaciones? entidad);
        Instalaciones? Borrar(Instalaciones? entidad);
    }
}
