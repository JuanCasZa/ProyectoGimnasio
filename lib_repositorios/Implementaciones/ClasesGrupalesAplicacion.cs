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

            // Valida que el cupo maximo sea mayor a cero
            if (entidad.CapacidadMax <= 0)
                throw new Exception("La capacidad maxima debe ser mayor a cero");

            //Valida que la duracion de la clase no sea negativa y no exceda de un limite razonable
            if (entidad.Duracion <= 0 || entidad.Duracion > 2)
                throw new Exception("La duración debe ser mayor a 0 y no puede superar las 2 horas");

            this.IConexion!.ClasesGrupales!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }
        public List<ClasesGrupales> Listar()
        {
            return this.IConexion!.ClasesGrupales!.Take(20).ToList();
        }

        public List<ClasesGrupales> PorTipoClase(ClasesGrupales? entidad)
        {
            return this.IConexion!.ClasesGrupales!.Where(x => x.TipoClase!.Contains(entidad!.TipoClase!)).ToList();
        }

        public ClasesGrupales? Modificar(ClasesGrupales? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformación");

            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardó");

            // Valida que el cupo maximo sea mayor a cero
            if (entidad.CapacidadMax <= 0)
                throw new Exception("La capacidad maxima debe ser mayor a cero");

            //Validar que la duracion de la clase no sea negativa y no exceda de un limite razonable
            if (entidad.Duracion <= 0 || entidad.Duracion > 2)
                throw new Exception("La duración debe ser mayor a 0 y no puede superar las 2 horas");

            var entry = this.IConexion!.Entry<ClasesGrupales>(entidad); 
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}
