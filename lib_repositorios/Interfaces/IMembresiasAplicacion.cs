using lib_dominio.Entidades;

namespace lib_repositorios.Interfaces
{
    public interface IMembresiasAplicacion
    {
        void Configurar(string StringConexion);
        List<Membresias> Listar();
        List<Membresias> Filtro(Membresias? entidad);
        Membresias? Guardar(Membresias? entidad);
        Membresias? Modificar(Membresias? entidad);
        Membresias? Borrar(Membresias? entidad);
        String ToStringMembresias(Membresias? entidad);
    }
}
