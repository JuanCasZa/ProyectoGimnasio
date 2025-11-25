using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface IClientesPresentacion
    {
<<<<<<< HEAD
        Task<List<Clientes>> Listar();
        Task<List<Clientes>> PorEdad(Clientes? entidad);
        Task<Clientes?> Guardar(Clientes? entidad);
        Task<Clientes?> Modificar(Clientes? entidad);
        Task<Clientes?> Borrar(Clientes? entidad);
=======
        Task<List<Clientes>> Listar(string Token);

        Task<List<Clientes>> Filtro(Clientes? entidad, string Token);
        Task<Clientes?> Guardar(Clientes? entidad, string Token);
        Task<Clientes?> Modificar(Clientes? entidad, string Token);
        Task<Clientes?> Borrar(Clientes? entidad, string Token);
>>>>>>> 4513b1bb842d2298da43cd4afc1208b322bd6b1d
    }
}
