using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ut_presentacion.Nucleo;

namespace ut_presentacion.Pruebas
{
    [TestClass]
    public class InstalacionesClientesPrueba
    {
        private IInstalacionesClientesAplicacion? app;

        [TestInitialize]
        public void Init()
        {
            var conexion = new Conexion();
            app = new InstalacionesClientesAplicacion(conexion);
            app.Configurar(Configuracion.ObtenerValor("StringConexion"));
        }

        [TestMethod]
        public void GuardarInstalacionesClientes()
        {
            var entidad = EntidadesNucleo.InstalacionesClientes();
            var resultado = app!.Guardar(entidad);
            Assert.IsNotNull(resultado);
        }

        [TestMethod]
        public void ListarInstalacionesClientes()
        {
            var lista = app!.Listar();
            Assert.IsNotNull(lista);
        }
    }
}