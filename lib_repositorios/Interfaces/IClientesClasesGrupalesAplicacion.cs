using lib_dominio.Entidades;

namespace lib_repositorios.Interfaces
{
    public interface IClientesClasesGrupalesAplicacion
    {
        void Configurar(string StringConexion);
        List<ClientesClasesGrupales> Listar();
        List<ClientesClasesGrupales> PorCliente(ClientesClasesGrupales? entidad);
        List<ClientesClasesGrupales> PorClaseGrupal(ClientesClasesGrupales? entidad);
        ClientesClasesGrupales? Guardar(ClientesClasesGrupales? entidad);
        ClientesClasesGrupales? Modificar(ClientesClasesGrupales? entidad);
        ClientesClasesGrupales? Borrar(ClientesClasesGrupales? entidad);
    }
}