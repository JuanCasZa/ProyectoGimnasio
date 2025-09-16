using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_repositorios.Implementaciones
{
    public class ClientesMembresiasAplicacion : IClientesMembresiasAplicacion
    {
        private IConexion? IConexion;

        public ClientesMembresiasAplicacion(IConexion conexion)
        {
            IConexion = conexion;
        }

        public void Configurar(string StringConexion)
        {
            if (IConexion != null) IConexion.StringConexion = StringConexion;
        }

        public List<ClientesMembresias> Listar()
        {
            return IConexion!.ClientesMembresias!.Include(c => c._IdClientes).Include(c => c._IdMembresias).ToList();
        }

        public ClientesMembresias? Guardar(ClientesMembresias? entidad)
        {
            if (entidad == null) throw new Exception("lbFaltaInformacion");
            if (entidad.Id != 0) throw new Exception("lbYaSeGuardo");

            IConexion!.ClientesMembresias!.Add(entidad);
            IConexion.SaveChanges();
            return entidad;
        }

        public ClientesMembresias? Modificar(ClientesMembresias? entidad)
        {
            if (entidad == null) throw new Exception("lbFaltaInformacion");

            var existente = IConexion!.ClientesMembresias!.Find(entidad.Id);
            if (existente == null) throw new Exception("lbNoExiste");

            IConexion.Entry(existente).CurrentValues.SetValues(entidad);
            IConexion.SaveChanges();
            return entidad;
        }

        public ClientesMembresias? Borrar(ClientesMembresias? entidad)
        {
            if (entidad == null) throw new Exception("lbFaltaInformacion");

            var existente = IConexion!.ClientesMembresias!.Find(entidad.Id);
            if (existente == null) throw new Exception("lbNoExiste");

            IConexion.ClientesMembresias!.Remove(existente);
            IConexion.SaveChanges();
            return existente;
        }
    }
}