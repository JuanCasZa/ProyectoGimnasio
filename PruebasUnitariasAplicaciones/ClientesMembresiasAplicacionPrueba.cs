using lib_repositorios.Interfaces;
using lib_repositorios.Implementaciones;
using lib_dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using ut_presentacion.Nucleo;

namespace PruebasUnitariasAplicaciones
{
    [TestClass]
    public class ClientesMembresiasAplicacionPrueba
    {
        private readonly IConexion? iConexion;
        private ClientesMembresiasAplicacion? app;
        private List<ClientesMembresias>? lista;
        private ClientesMembresias? entidad;

        public ClientesMembresiasAplicacionPrueba()
        {
            iConexion = new Conexion();
            iConexion.StringConexion = Configuracion.ObtenerValor("StringConexion");
            app = new ClientesMembresiasAplicacion(iConexion);
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
            this.entidad = EntidadesNucleo.ClientesMembresias()!;
            this.app!.Guardar(this.entidad);

            return this.entidad.Id > 0;
        }

        public bool Modificar()
        {
            this.entidad!.FechaInicio = DateTime.Now;
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
