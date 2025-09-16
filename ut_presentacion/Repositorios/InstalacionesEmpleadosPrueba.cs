using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using ut_presentacion.Nucleo;

namespace ut_presentacion.Repositorios
{
    [TestClass]
    public class InstalacionesEmpleadosPrueba
    {
        private readonly IConexion? iConexion;
        private List<InstalacionesEmpleados>? lista;
        private InstalacionesEmpleados? entidad;

        public InstalacionesEmpleadosPrueba()
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
            this.lista = this.iConexion!.InstalacionesEmpleados!.ToList();
            return lista.Count > 0;
        }

        public bool Guardar()
        {
            this.entidad = EntidadesNucleo.InstalacionesEmpleados()!;
            this.iConexion!.InstalacionesEmpleados!.Add(this.entidad);
            this.iConexion!.SaveChanges();

            return true;
        }

        public bool Modificar()
        {
            this.entidad!.IdEmpleados = 3;
            var entry = this.iConexion!.Entry<InstalacionesEmpleados>(this.entidad);
            entry.State = EntityState.Modified;
            this.iConexion!.SaveChanges();

            return true;
        }


        public bool Borrar()
        {
            this.iConexion!.InstalacionesEmpleados!.Remove(this.entidad!);
            this.iConexion!.SaveChanges();

            return true;
        }
    }
}

