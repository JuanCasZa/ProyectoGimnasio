using lib_repositorios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using Microsoft.EntityFrameworkCore;
using ut_presentacion.Nucleo;

namespace ut_presentacion.Repositorios
{
    [TestClass]
    public class ClasesGrupalesPrueba
    {
        private readonly IConexion? iConexion;
        private List<ClasesGrupales>? lista;
        private ClasesGrupales? entidad;

        public ClasesGrupalesPrueba()
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
            this.lista = this.iConexion!.ClasesGrupales!.ToList();
            return lista.Count > 0;
        }
        public bool Guardar()
        {
            this.entidad = EntidadesNucleo.ClasesGrupales()!;
            this.iConexion!.ClasesGrupales!.Add(this.entidad);
            this.iConexion!.SaveChanges();
            return true;
        }
        public bool Modificar()
        {
            this.entidad!.Nivel = "Alto";
            var entry = this.iConexion!.Entry<ClasesGrupales>(this.entidad);
            entry.State = EntityState.Modified;
            this.iConexion!.SaveChanges();
            return true;
        }
        public bool Borrar()
        {
            this.iConexion!.ClasesGrupales!.Remove(this.entidad!);
            this.iConexion!.SaveChanges();

            return true;
        }
    }
}
