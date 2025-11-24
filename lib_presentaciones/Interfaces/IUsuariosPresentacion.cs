using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface IUsuariosPresentacion
    {
        Task<List<Usuarios>> Listar(string Token/*IMPLEMENTANDO COSAS*/);
        Task<string?> Autenticar(string nombre, string contrasenha, string Token /*IMPLEMENTANDO COSAS*/);

        Task<string?> ObtenerRol(string Token /*IMPLEMENENTANDO COSAS*/ ); 

        Task<Usuarios?> Guardar(Usuarios? entidad);
        Task<Usuarios?> Modificar(Usuarios? entidad, string Token);
        Task<Usuarios?> Borrar(Usuarios? entidad, string Token);
    }
}
