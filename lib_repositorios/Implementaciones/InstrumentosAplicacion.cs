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
    public class InstrumentosAplicacion : IInstrumentosAplicacion
    {
        private IConexion? IConexion = null;

        public InstrumentosAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public Instrumentos? Borrar(Instrumentos? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformación");

            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardó");

            //Si el instrumento esta asignado a un cliente, que no se pueda borrar
            bool asignado = this.IConexion!.ClientesInstrumentos!
              .Any(ci => ci.IdInstrumentos == entidad.Id);

            if (asignado)
                throw new Exception("No se puede borrar: el instrumento está asignado a un cliente");

            entidad._Proveedor = null;

            this.IConexion!.Instrumentos!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Instrumentos? Guardar(Instrumentos? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id != 0)
                throw new Exception("lbYaSeGuardo");

            //Disponible por defecto
            entidad.Estado = true;

            entidad._Proveedor= null;

            this.IConexion!.Instrumentos!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Instrumentos> Listar()
        {
            return this.IConexion!.Instrumentos!.Take(20).ToList();
        }

        public Instrumentos? Modificar(Instrumentos? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformación");

            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardó");

            entidad._Proveedor = null;

            var entry = this.IConexion!.Entry<Instrumentos>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}
