using lib_dominio.Entidades;

namespace lib_repositorios.Interfaces
{
    public interface IClientesAplicacion
    {
        void Configurar(string StringConexion);
        List<Clientes> Listar();
<<<<<<< HEAD
        List<Clientes> PorEdad(Clientes? entidad);
=======

        List<Clientes> Filtro(Clientes? entidad);
>>>>>>> 4513b1bb842d2298da43cd4afc1208b322bd6b1d
        Clientes? Guardar(Clientes? entidad);
        Clientes? Modificar(Clientes? entidad);
        Clientes? Borrar(Clientes? entidad);
    }
}
