using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface IEmpleadosPresentacion
    {
        Task<List<Empleados>> Listar(string Token);

        Task<List<Empleados>> Filtro(Empleados? entidad, string Token);
        Task<Empleados?> Guardar(Empleados? entidad, string Token);
        Task<Empleados?> Modificar(Empleados? entidad, string Token);
        Task<Empleados?> Borrar(Empleados? entidad, string Token);
    }
}
