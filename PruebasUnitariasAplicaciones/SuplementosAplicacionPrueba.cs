using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using ut_presentacion.Nucleo;

namespace PruebasUnitariasAplicaciones
{
    [TestClass]
    public class SuplementosAplicacionPrueba
    {
        private readonly IConexion? iConexion;
        private SuplementosAplicacion? app;
        private List<Suplementos>? lista;
        private Suplementos? entidad;
        public SuplementosAplicacionPrueba()
        {
            iConexion = new Conexion();
            iConexion.StringConexion = Configuracion.ObtenerValor("StringConexion");
            app = new SuplementosAplicacion(iConexion);
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
            this.entidad = EntidadesNucleo.Suplementos();
            this.app!.Guardar(this.entidad);

            return this.entidad!.Id > 0;
        }
        public bool Modificar()
        {
            this.entidad!.Valor = 155000m;
            this.app!.Modificar(this.entidad);

            return true;
        }
        public bool Listar()
        {
            this.lista = this.app!.Listar();
            return lista.Count > 0;
        }
        public bool Borrar()
        {
            this.app!.Borrar(this.entidad!);
            return true;
        }
    }
}
