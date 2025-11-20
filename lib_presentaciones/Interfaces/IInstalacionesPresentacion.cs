using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface IInstalacionesEmpleadosPresentacion
    {
        Task<List<InstalacionesEmpleados>> Listar(string Token);

        Task<List<InstalacionesEmpleados>> Filtro(InstalacionesEmpleados? entidad, string Token);
        Task<InstalacionesEmpleados?> Guardar(InstalacionesEmpleados? entidad, string Token);
        Task<InstalacionesEmpleados?> Modificar(InstalacionesEmpleados? entidad, string Token);
        Task<InstalacionesEmpleados?> Borrar(InstalacionesEmpleados? entidad, string Token);
    }
}
