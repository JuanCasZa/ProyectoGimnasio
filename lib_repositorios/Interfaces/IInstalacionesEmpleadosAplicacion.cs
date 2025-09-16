using lib_dominio.Entidades;

namespace lib_repositorios.Interfaces
{
    public interface IInstalacionesEmpleadosAplicacion
    {
        void Configurar(string StringConexion);
        List<InstalacionesEmpleados> Listar();
        InstalacionesEmpleados? Guardar(InstalacionesEmpleados? entidad);
        InstalacionesEmpleados? Modificar(InstalacionesEmpleados? entidad);
        InstalacionesEmpleados? Borrar(InstalacionesEmpleados? entidad);
    }
}