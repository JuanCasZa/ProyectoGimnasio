using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using ut_presentacion.Nucleo;

namespace ut_presentacion.Repositorios
{
    [TestClass]
    public class SuplementosPrueba
    {
        private readonly IConexion? iConexion;
        private Suplementos? entidad;
        private Proveedores? proveedor;

        public SuplementosPrueba()
        {
            iConexion = new Conexion();
            iConexion.StringConexion = Configuracion.ObtenerValor("StringConexion");
        }

        [TestMethod]
        public void Ejecutar()
        {
            Assert.AreEqual(true, Guardar());
            Assert.AreEqual(true, Modificar());
            Assert.AreEqual(true, Listar());
            Assert.AreEqual(true, Borrar());
        }

        public bool Listar()
        {
            var lista = iConexion!.Suplementos!.Include(f => f._Proveedor).ToList();
            return lista.Count > 0;
        }

        public bool Guardar()
        {
            this.proveedor = EntidadesNucleo.Proveedores();
            iConexion!.Proveedores!.Add(proveedor);
            iConexion.SaveChanges();

            this.entidad = EntidadesNucleo.Suplementos();
            this.entidad.Proveedor = proveedor.Id;

            iConexion.Suplementos!.Add(entidad);
            iConexion.SaveChanges();

            return true;
        }

        public bool Modificar()
        {
            this.entidad!.Valor = 155000m;
            var entry = this.iConexion!.Entry<Suplementos>(this.entidad);
            entry.State = EntityState.Modified;
            this.iConexion!.SaveChanges();
            return true;
        }
        public bool Borrar()
        {
            this.iConexion!.Suplementos!.Remove(this.entidad!);
            this.iConexion!.SaveChanges();

            return true;
        }
    }
}
