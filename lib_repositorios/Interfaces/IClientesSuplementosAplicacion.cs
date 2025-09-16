using lib_dominio.Entidades;

namespace lib_repositorios.Interfaces
{
    public interface IClientesSuplementosAplicacion
    {
        void Configurar(string StringConexion);
        List<ClientesSuplementos> Listar();
        ClientesSuplementos? Guardar(ClientesSuplementos? entidad);
        ClientesSuplementos? Modificar(ClientesSuplementos? entidad);
        ClientesSuplementos? Borrar(ClientesSuplementos? entidad);
    }
}