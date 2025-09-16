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
    public class SuplementosAplicacion: ISuplementosAplicacion
    {
        private IConexion? IConexion = null;

        public SuplementosAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }
        public Suplementos? Borrar(Suplementos? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformación");

            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardó");

            this.IConexion!.Suplementos!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }
        public Suplementos? Guardar(Suplementos? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id != 0)
                throw new Exception("lbYaSeGuardo");

            this.IConexion!.Suplementos!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }
        public List<Suplementos> Listar()
        {
            return this.IConexion!.Suplementos!.Take(20).ToList();
        }

        public Suplementos? Modificar(Suplementos? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformación");

            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardó");

            var entry = this.IConexion!.Entry<Suplementos>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}
