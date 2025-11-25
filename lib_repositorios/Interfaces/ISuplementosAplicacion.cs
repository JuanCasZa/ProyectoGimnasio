using lib_dominio.Entidades;

namespace lib_repositorios.Interfaces
{
    public interface ISuplementosAplicacion
    {
        void Configurar(string StringConexion);
        List<Suplementos> Listar();
        List<Suplementos> Filtro(Suplementos? entidad);
        Suplementos? Guardar(Suplementos? entidad);
        Suplementos? Modificar(Suplementos? entidad);
        Suplementos? Borrar(Suplementos? entidad);
    }
}
