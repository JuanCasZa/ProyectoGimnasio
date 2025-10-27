using lib_dominio.Entidades;


namespace lib_repositorios.Interfaces
{
    public interface IClientesMembresiasAplicacion
    {
        void Configurar(string StringConexion);
        List<ClientesMembresias> Listar();
        List<ClientesMembresias> PorIdClientes(ClientesMembresias? entidad);
        List<ClientesMembresias> PorIdMembresias(ClientesMembresias? entidad);
        ClientesMembresias? Guardar(ClientesMembresias? entidad);
        ClientesMembresias? Modificar(ClientesMembresias? entidad);
        ClientesMembresias? Borrar(ClientesMembresias? entidad);
    }
}
