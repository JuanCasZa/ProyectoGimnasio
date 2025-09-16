using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_repositorios.Implementaciones
{
    public class ClientesSuplementosAplicacion : IClientesSuplementosAplicacion
    {
        private IConexion? IConexion;

        public ClientesSuplementosAplicacion(IConexion conexion)
        {
            IConexion = conexion;
        }

        public void Configurar(string StringConexion)
        {
            if (IConexion != null) IConexion.StringConexion = StringConexion;
        }

        public List<ClientesSuplementos> Listar()
        {
            return IConexion!.ClientesSuplementos!
                .Include(cs => cs._IdClientes)
                .Include(cs => cs._IdSuplementos)
                .ToList();
        }

        public ClientesSuplementos? Guardar(ClientesSuplementos? entidad)
        {
            if (entidad == null) throw new Exception("lbFaltaInformacion");
            if (entidad.Id != 0) throw new Exception("lbYaSeGuardo");

            IConexion!.ClientesSuplementos!.Add(entidad);
            IConexion.SaveChanges();
            return entidad;
        }

        public ClientesSuplementos? Modificar(ClientesSuplementos? entidad)
        {
            if (entidad == null) throw new Exception("lbFaltaInformacion");

            var existente = IConexion!.ClientesSuplementos!.Find(entidad.Id);
            if (existente == null) throw new Exception("lbNoExiste");

            IConexion.Entry(existente).CurrentValues.SetValues(entidad);
            IConexion.SaveChanges();
            return entidad;
        }

        public ClientesSuplementos? Borrar(ClientesSuplementos? entidad)
        {
            if (entidad == null) throw new Exception("lbFaltaInformacion");

            var existente = IConexion!.ClientesSuplementos!.Find(entidad.Id);
            if (existente == null) throw new Exception("lbNoExiste");

            IConexion.ClientesSuplementos!.Remove(existente);
            IConexion.SaveChanges();
            return existente;
        }
    }
}