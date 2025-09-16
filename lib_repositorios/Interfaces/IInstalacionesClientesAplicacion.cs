using lib_dominio.Entidades;

namespace lib_repositorios.Interfaces
{
    public interface IInstalacionesClientesAplicacion
    {
        void Configurar(string StringConexion);
        List<InstalacionesClientes> Listar();
        InstalacionesClientes? Guardar(InstalacionesClientes? entidad);
        InstalacionesClientes? Modificar(InstalacionesClientes? entidad);
        InstalacionesClientes? Borrar(InstalacionesClientes? entidad);
    }
}