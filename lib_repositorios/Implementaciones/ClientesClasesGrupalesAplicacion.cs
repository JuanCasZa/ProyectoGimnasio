using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_repositorios.Implementaciones
{
    public class ClientesClasesGrupalesAplicacion : IClientesClasesGrupalesAplicacion
    {
        private IConexion? IConexion = null;

        public ClientesClasesGrupalesAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public ClientesClasesGrupales? Borrar(ClientesClasesGrupales? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformación");

            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardó");

            this.IConexion!.ClientesClasesGrupales!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public ClientesClasesGrupales? Guardar(ClientesClasesGrupales? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id != 0)
                throw new Exception("lbYaSeGuardo");

            this.IConexion!.ClientesClasesGrupales!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<ClientesClasesGrupales> Listar()
        {
            return this.IConexion!.ClientesClasesGrupales!.Take(20).ToList();
        }

        public ClientesClasesGrupales? Modificar(ClientesClasesGrupales? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformación");

            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardó");

            var entry = this.IConexion!.Entry<ClientesClasesGrupales>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}
