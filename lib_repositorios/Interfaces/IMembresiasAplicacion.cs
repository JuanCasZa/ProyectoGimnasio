using lib_dominio.Entidades;

namespace lib_repositorios.Interfaces
{
    public interface IMembresiasAplicacion
    {
        void Configurar(string StringConexion);
        List<Membresias> Listar();
        List<Membresias> PorTipoMembresia(Membresias? entidad);
        Membresias? Guardar(Membresias? entidad);
        Membresias? Modificar(Membresias? entidad);
        Membresias? Borrar(Membresias? entidad);
    }
}
