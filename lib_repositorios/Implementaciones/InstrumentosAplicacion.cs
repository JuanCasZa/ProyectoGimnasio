using lib_dominio.Entidades;
using lib_dominio.Nucleo;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Instrumentos? entidadvieja = this.IConexion!.Instrumentos!.FirstOrDefault(x => x.Id! == entidad!.Id);
            if (entidadvieja == null) throw new Exception("La entidad no existe");

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

            var proveedor = this.IConexion!.Proveedores!
                .FirstOrDefault(i => i.Id == entidad.Proveedor);

            if (proveedor == null)
                throw new Exception("El proveedor no existe");

            entidad._Proveedor= null;

            this.IConexion!.Instrumentos!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Instrumentos> Listar()
        {
            return this.IConexion!.Instrumentos!.Take(20).Include(x => x._Proveedor).ToList();
        }

        public List<Instrumentos> Filtro(Instrumentos? entidad)
        {
            var consulta = this.IConexion!.Instrumentos!.Include(x => x._Proveedor).AsQueryable();

            //Filtro por el nombre del proveedor
            if (entidad?._Proveedor?.NombreEntidad is not null)
            {
                consulta = consulta.Where(x =>
                    x._Proveedor!.NombreEntidad.Contains(entidad._Proveedor.NombreEntidad)
                );
            }

            //Filtro por marca y por nombre del instrumento
            consulta = consulta.Where(x => x.Marca!.Contains(entidad!.Marca!) && x.NombreInstrumento!.Contains(entidad!.NombreInstrumento!)).Take(50);

            return consulta.ToList();
        }


        public Instrumentos? Modificar(Instrumentos? entidad)
        {
            Instrumentos? entidadvieja = this.IConexion!.Instrumentos!.FirstOrDefault(x => x.Id! == entidad!.Id);
            if (entidadvieja == null) throw new Exception("La entidad no existe");

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

            if (entidadvieja.Proveedor != entidad.Proveedor) throw new Exception("El proveedor debe ser el mismo");

            entidad._Proveedor = null;

            var entry = this.IConexion!.Entry<Instrumentos>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
        public String ToStringInstrumentos(Instrumentos? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformación");
            return $"Id: {entidad.Id}, Nombre Instrumento: {entidad.NombreInstrumento}, Cantidad Equipos: {entidad.CantidadEquip}, Piezas: {entidad.Piezas}, Marca: {entidad.Marca}, Descripción General: {entidad.DescripcionGeneral}, Estado: {entidad.Estado}, Proveedor Id: {entidad.Proveedor}";
        }
    }
}
