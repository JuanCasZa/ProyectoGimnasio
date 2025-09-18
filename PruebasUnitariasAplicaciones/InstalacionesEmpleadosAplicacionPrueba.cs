using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using ut_presentacion.Nucleo;

namespace PruebasUnitariasAplicaciones
{
    [TestClass]
    public class InstalacionesEmpleadosAplicacionPrueba
    {
        private readonly IConexion iConexion;
        private readonly InstalacionesEmpleadosAplicacion aplicacion;
        private InstalacionesEmpleados? entidad;

        public InstalacionesEmpleadosAplicacionPrueba()
        {
            iConexion = new Conexion();
            iConexion.StringConexion = Configuracion.ObtenerValor("StringConexion");
            aplicacion = new InstalacionesEmpleadosAplicacion(iConexion);
        }

        [TestMethod]
        public void Ejecutar()
        {
            Assert.AreEqual(true, Guardar());
            Assert.AreEqual(true, Modificar());
            Assert.AreEqual(true, Listar());
            Assert.AreEqual(true, Borrar());
        }

        public bool Guardar()
        {
            entidad = new InstalacionesEmpleados
            {
                IdEmpleados = 1,
                IdInstalaciones = 1
            };
            var resultado = aplicacion.Guardar(entidad);
            return resultado != null && resultado.Id > 0;
        }

        public bool Modificar()
        {
            entidad!.IdEmpleados = 2;
            var resultado = aplicacion.Modificar(entidad);
            return resultado != null && resultado.IdEmpleados == 2;
        }

        public bool Listar()
        {
            var lista = aplicacion.Listar();
            return lista.Count > 0;
        }

        public bool Borrar()
        {
            var resultado = aplicacion.Borrar(entidad);
            return resultado != null && resultado.Id == entidad!.Id;
        }
    }
}
