using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using ut_presentacion.Nucleo;

namespace PruebasUnitariasAplicaciones
{
    [TestClass]
    public class ClientesInstrumentosAplicacionPrueba
    {
        private readonly IConexion iConexion;
        private readonly ClientesInstrumentosAplicacion aplicacion;
        private ClientesInstrumentos? entidad;

        public ClientesInstrumentosAplicacionPrueba()
        {
            iConexion = new Conexion();
            iConexion.StringConexion = Configuracion.ObtenerValor("StringConexion");
            aplicacion = new ClientesInstrumentosAplicacion(iConexion);
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
            entidad = new ClientesInstrumentos
            {
                IdClientes = 1,
                IdInstrumentos = 1 
            };
            var resultado = aplicacion.Guardar(entidad);
            return resultado != null && resultado.Id > 0;
        }

        public bool Modificar()
        {
            entidad!.IdClientes = 2;
            var resultado = aplicacion.Modificar(entidad);
            return resultado != null && resultado.IdClientes == 2;
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
