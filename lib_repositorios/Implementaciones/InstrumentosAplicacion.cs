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

            //Para evitar que la cantidad de equipos y de piezas sea negativa
            if (entidad.CantidadEquip < 0)
                throw new Exception("La cantidad de equipos no puede ser negativa");
            if (entidad.Piezas < 0)
                throw new Exception("La cantidad de piezas no puede ser negativa");

            //Para evitar que hayan dos instrumentos con el mismo nombre y marca repetidos
            bool existeDuplicado = this.IConexion!.Instrumentos!
                .Any(i => i.NombreInstrumento == entidad.NombreInstrumento
                && i.Marca == entidad.Marca
                && i.Id != entidad.Id);

            if (existeDuplicado)
                throw new Exception("Ya existe un instrumento con el mismo nombre y marca");

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

            //Para evitar que la cantidad de equipos y de piezas sea negativa
            if (entidad.CantidadEquip < 0)
                throw new Exception("La cantidad de equipos no puede ser negativa");
            if (entidad.Piezas < 0)
                throw new Exception("La cantidad de piezas no puede ser negativa");

            //Para evitar que hayan dos instrumentos con el mismo nombre y marca repetidos
            bool existeDuplicado = this.IConexion!.Instrumentos!
                .Any(i => i.NombreInstrumento == entidad.NombreInstrumento
                && i.Marca == entidad.Marca
                && i.Id != entidad.Id);

            if (existeDuplicado)
                throw new Exception("Ya existe un instrumento con el mismo nombre y marca");

            entidad._Proveedor = null;

            var entry = this.IConexion!.Entry<Instrumentos>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}
