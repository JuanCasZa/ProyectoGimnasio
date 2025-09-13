using lib_dominio.Entidades;

namespace lib_repositorios.Interfaces
{
    public interface IPersonasAplicacion
    {
        void Configurar(string StringConexion);
        List<Personas> Listar();
        Personas? Guardar(Personas? entidad);
        Personas? Modificar(Personas? entidad);
        Personas? Borrar(Personas? entidad);
    }
}
