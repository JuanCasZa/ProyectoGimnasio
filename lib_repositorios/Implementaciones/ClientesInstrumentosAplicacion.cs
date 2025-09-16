using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_repositorios.Implementaciones
{
    public class ClientesInstrumentosAplicacion : IClientesInstrumentosAplicacion
    {
        private IConexion? IConexion = null;

        public ClientesInstrumentosAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }
        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }
        public ClientesInstrumentos? Borrar(ClientesInstrumentos? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformación");

            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardó");

            this.IConexion!.ClientesInstrumentos!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }
        public ClientesInstrumentos? Guardar(ClientesInstrumentos? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id != 0)
                throw new Exception("lbYaSeGuardo");

            this.IConexion!.ClientesInstrumentos!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }
        public List<ClientesInstrumentos> Listar()
        {
            return this.IConexion!.ClientesInstrumentos!.Take(20).ToList();
        }
        public ClientesInstrumentos? Modificar(ClientesInstrumentos? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformación");

            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardó");

            var entry = this.IConexion!.Entry<ClientesInstrumentos>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}
