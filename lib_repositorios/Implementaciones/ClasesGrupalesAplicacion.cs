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
            ClasesGrupales? entidadvieja = this.IConexion!.ClasesGrupales!.FirstOrDefault(x => x.Id! == entidad!.Id);
            if (entidadvieja == null) throw new Exception("La entidad no existe");

            if (entidad == null)
                throw new Exception("lbFaltaInformación");

            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardó");

            bool heredaciones = this.IConexion!.ClientesClasesGrupales!
                .Any(s => s.IdClasesGrupales == entidad.Id);

            if (heredaciones)
                throw new Exception("lbClaseGrupal ligada a otras tablas");

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

        public List<ClasesGrupales> Filtro(ClasesGrupales? entidad)
        {
            var consulta = this.IConexion!.ClasesGrupales!.AsQueryable();

            //Filtro por èl tipo de clase y por el nivel
            consulta = consulta.Where(x => x.TipoClase!.Contains(entidad!.TipoClase!) && x.Nivel!.Contains(entidad!.Nivel!)).Take(50);

            return consulta.ToList();
        }

        public ClasesGrupales? Modificar(ClasesGrupales? entidad)
        {
            ClasesGrupales? entidadvieja = this.IConexion!.ClasesGrupales!.FirstOrDefault(x => x.Id! == entidad!.Id);
            if (entidadvieja == null) throw new Exception("La entidad no existe");

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
        public String ToStringClaseGrupal(ClasesGrupales? claseGrupal)
        {
            if (claseGrupal == null)
                return "Clase Grupal nula";
            return $"ID: {claseGrupal.Id}, Tipo de Clase: {claseGrupal.TipoClase}, Nivel: {claseGrupal.Nivel}, Duración: {claseGrupal.Duracion} horas, Capacidad Máxima: {claseGrupal.CapacidadMax}";
        }

    }
}
