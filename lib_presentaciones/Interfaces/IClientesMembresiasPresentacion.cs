using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface IClientesMembresiasPresentacion
    {
        Task<List<ClientesMembresias>> Listar();
        Task<List<ClientesMembresias>> Filtro(ClientesMembresias? entidad);
        Task<ClientesMembresias?> Guardar(ClientesMembresias? entidad);
        Task<ClientesMembresias?> Modificar(ClientesMembresias? entidad);
        Task<ClientesMembresias?> Borrar(ClientesMembresias? entidad);
    }
}
