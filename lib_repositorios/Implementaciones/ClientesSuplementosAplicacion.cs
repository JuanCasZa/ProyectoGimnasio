using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_repositorios.Implementaciones
{
    public class ClientesSuplementosAplicacion : IClientesSuplementosAplicacion
    {
        private IConexion? IConexion = null;

        public ClientesSuplementosAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public ClientesSuplementos? Borrar(ClientesSuplementos? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformación");

            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardó");

            this.IConexion!.ClientesSuplementos!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public ClientesSuplementos? Guardar(ClientesSuplementos? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id != 0)
                throw new Exception("lbYaSeGuardo");

            this.IConexion!.ClientesSuplementos!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<ClientesSuplementos> Listar()
        {
            return this.IConexion!.ClientesSuplementos!.Take(20).ToList();
        }

        public ClientesSuplementos? Modificar(ClientesSuplementos? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformación");

            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardó");

            var entry = this.IConexion!.Entry<ClientesSuplementos>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}
