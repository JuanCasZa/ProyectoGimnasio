using lib_dominio.Entidades;


namespace lib_repositorios.Interfaces
{
    public interface IClientesMembresiasAplicacion
    {
        void Configurar(string StringConexion);
        List<ClientesMembresias> Listar();
        ClientesMembresias? Guardar(ClientesMembresias? entidad);
        ClientesMembresias? Modificar(ClientesMembresias? entidad);
        ClientesMembresias? Borrar(ClientesMembresias? entidad);
    }
}
