using lib_dominio.Entidades;

namespace lib_repositorios.Interfaces
{
    public interface IInstalacionesClientesAplicacion
    {
        void Configurar(string StringConexion);
        List<InstalacionesClientes> Listar();
        List<InstalacionesClientes> PorIdClientes(InstalacionesClientes? entidad);
        List<InstalacionesClientes> PorIdInstalaciones(InstalacionesClientes? entidad);
        InstalacionesClientes? Guardar(InstalacionesClientes? entidad);
        InstalacionesClientes? Modificar(InstalacionesClientes? entidad);
        InstalacionesClientes? Borrar(InstalacionesClientes? entidad);
    }
}