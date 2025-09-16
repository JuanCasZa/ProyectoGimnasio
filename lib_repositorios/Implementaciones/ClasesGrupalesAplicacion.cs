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
    public class ClasesGrupalesAplicacion : IClasesGrupalesAplicacion
    {
        private IConexion? IConexion = null;
        public ClasesGrupalesAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }
        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }
        public ClasesGrupales? Borrar(ClasesGrupales? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformación");

            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardó");

            this.IConexion!.ClasesGrupales!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }
        public ClasesGrupales? Guardar(ClasesGrupales? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id != 0)
                throw new Exception("lbYaSeGuardo");

            this.IConexion!.ClasesGrupales!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }
        public List<ClasesGrupales> Listar()
        {
            return this.IConexion!.ClasesGrupales!.Take(20).ToList();
        }
        public ClasesGrupales? Modificar(ClasesGrupales? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformación");

            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardó");

            var entry = this.IConexion!.Entry<ClasesGrupales>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}
