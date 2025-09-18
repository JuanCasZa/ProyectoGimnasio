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
    public class ClientesClasesGrupalesAplicacionPrueba
    {
        private readonly IConexion iConexion;
        private readonly ClientesClasesGrupalesAplicacion aplicacion;
        private ClientesClasesGrupales? entidad;

        public ClientesClasesGrupalesAplicacionPrueba()
        {
            iConexion = new Conexion();
            iConexion.StringConexion = Configuracion.ObtenerValor("StringConexion");
            aplicacion = new ClientesClasesGrupalesAplicacion(iConexion);
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
            entidad = new ClientesClasesGrupales
            {
                IdClientes = 1,
                IdClasesGrupales = 1
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

