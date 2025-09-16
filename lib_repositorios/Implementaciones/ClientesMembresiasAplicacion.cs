using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_repositorios.Implementaciones
{
    public class ClientesMembresiasAplicacion : IClientesMembresiasAplicacion
    {
        private IConexion? IConexion = null;

        public ClientesMembresiasAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public ClientesMembresias? Borrar(ClientesMembresias? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformación");

            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardó");

            this.IConexion!.ClientesMembresias!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public ClientesMembresias? Guardar(ClientesMembresias? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id != 0)
                throw new Exception("lbYaSeGuardo");

            this.IConexion!.ClientesMembresias!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<ClientesMembresias> Listar()
        {
            return this.IConexion!.ClientesMembresias!.Take(20).ToList();
        }

        public ClientesMembresias? Modificar(ClientesMembresias? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformación");

            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardó");

            var entry = this.IConexion!.Entry<ClientesMembresias>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}
