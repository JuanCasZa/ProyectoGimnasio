using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface IInstalacionesEmpleadosPresentacion
    {
        Task<List<InstalacionesEmpleados>> Listar();
        Task<List<InstalacionesEmpleados>> Filtro(InstalacionesEmpleados? entidad);
        Task<InstalacionesEmpleados?> Guardar(InstalacionesEmpleados? entidad);
        Task<InstalacionesEmpleados?> Modificar(InstalacionesEmpleados? entidad);
        Task<InstalacionesEmpleados?> Borrar(InstalacionesEmpleados? entidad);
    }
}
