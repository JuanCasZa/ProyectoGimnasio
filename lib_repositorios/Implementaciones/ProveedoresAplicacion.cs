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
    public class ProveedoresAplicacion: IProveedoresAplicacion
    {
        private IConexion? IConexion = null;
        public ProveedoresAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }
        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }
        public Proveedores? Borrar(Proveedores? entidad)
        {
            Proveedores? entidadvieja = this.IConexion!.Proveedores!.FirstOrDefault(x => x.Id! == entidad!.Id);
            if (entidadvieja == null) throw new Exception("La entidad no existe");

            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardó");

            //Para evitar borrar proveedor de la base si hay suplementos o instrumentos asociados

            bool tieneSuplementos = this.IConexion!.Suplementos!
                .Any(s => s.Proveedor == entidad.Id);

            if (tieneSuplementos)
                throw new Exception("lbProveedorConSuplementos");

            bool tieneInstrumentos = this.IConexion!.Instrumentos!
               .Any(i => i.Proveedor == entidad.Id);

            if (tieneInstrumentos)
                throw new Exception("lbProveedorConInstrumentos");

            this.IConexion!.Proveedores!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }
        public Proveedores? Guardar(Proveedores? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad.Id != 0)
                throw new Exception("lbYaSeGuardó");

            //Para evitar proveedores sin nombre o direccion
            if (string.IsNullOrWhiteSpace(entidad.NombreEntidad))
                throw new Exception("El proveedor debe tener un nombre");
            if (string.IsNullOrWhiteSpace(entidad.Direccion))
                throw new Exception("El proveedor debe tener una dirección");

            //Para evitar valores negativos en el valor total de venta del proveedor
            if (entidad.ValorTotalVenta < 0)
                throw new Exception("El valor total de venta no puede ser negativo");
            
            //Valida que el telefono del proveedor sea valido
            if (string.IsNullOrWhiteSpace(entidad.Telefono) || entidad.Telefono.Length < 7 || !entidad.Telefono.All(char.IsDigit))
                throw new Exception("El teléfono no es válido");

            //Valida que el telefono del proveedor sea unico
            bool telefonoDuplicado = this.IConexion!.Proveedores!
                .Any(p => p.Telefono == entidad.Telefono && p.Id != entidad.Id);

            if (telefonoDuplicado)
                throw new Exception("El teléfono ya está registrado por otro proveedor");


            this.IConexion!.Proveedores!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }
        public List<Proveedores> Listar()
        {
            return this.IConexion!.Proveedores!.Take(20).ToList();
        }

        public List<Proveedores> Filtro(Proveedores? entidad)
        {
            var consulta = this.IConexion!.Proveedores!.AsQueryable();

            //Filtro por Direccion y por Telefono
            consulta = consulta.Where(x => x.Direccion!.Contains(entidad!.Direccion!) && x.Telefono!.Contains(entidad!.Telefono!)).Take(50);

            return consulta.ToList();
        }

        public Proveedores? Modificar(Proveedores? entidad)
        {
            Proveedores? entidadvieja = this.IConexion!.Proveedores!.FirstOrDefault(x => x.Id! == entidad!.Id);
            if (entidadvieja == null) throw new Exception("La entidad no existe");

            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardó");

            //Para evitar proveedores sin nombre o direccion
            if (string.IsNullOrWhiteSpace(entidad.NombreEntidad))
                throw new Exception("El proveedor debe tener un nombre");
            if (string.IsNullOrWhiteSpace(entidad.Direccion))
                throw new Exception("El proveedor debe tener una dirección");

            //Para evitar valores negativos en el valor total de venta del proveedor
            if (entidad.ValorTotalVenta < 0)
                throw new Exception("El valor total de venta no puede ser negativo");

            //Valida que el telefono del proveedor sea valido
            if (string.IsNullOrWhiteSpace(entidad.Telefono) || entidad.Telefono.Length < 7 || !entidad.Telefono.All(char.IsDigit))
                throw new Exception("El teléfono no es válido");

            //Valida que el telefono del proveedor sea unico
            bool telefonoDuplicado = this.IConexion!.Proveedores!
                .Any(p => p.Telefono == entidad.Telefono && p.Id != entidad.Id);

            if (telefonoDuplicado)
                throw new Exception("El teléfono ya está registrado por otro proveedor");

            var entry = this.IConexion!.Entry<Proveedores>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}
