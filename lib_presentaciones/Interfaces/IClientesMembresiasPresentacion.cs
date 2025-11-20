using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface IClientesMembresiasPresentacion
    {
        Task<List<ClientesMembresias>> Listar(string Token);

        Task<List<ClientesMembresias>> Filtro(ClientesMembresias? entidad, string Token);
        Task<ClientesMembresias?> Guardar(ClientesMembresias? entidad, string Token);
        Task<ClientesMembresias?> Modificar(ClientesMembresias? entidad, string Token);
        Task<ClientesMembresias?> Borrar(ClientesMembresias? entidad, string Token);
    }
}
