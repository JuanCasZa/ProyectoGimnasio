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
using Microsoft.VisualStudio.TestTools.UnitTesting; //

namespace PruebasUnitariasAplicaciones
{
    [TestClass]
    public class InstrumentosAplicacionPrueba
    {
        private readonly IConexion? iConexion;
        private InstrumentosAplicacion? aplicacion;
        private List<Instrumentos>? lista;
        private Instrumentos? entidad;
        public InstrumentosAplicacionPrueba()
        {
            iConexion = new Conexion();
            iConexion.StringConexion = Configuracion.ObtenerValor("StringConexion");
            aplicacion = new InstrumentosAplicacion(iConexion);
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
            this.lista = this.aplicacion!.Listar();
            return lista.Count > 0;
        }

        public bool Guardar()
        {
            this.entidad = EntidadesNucleo.Instrumentos()!;
            this.aplicacion!.Guardar(this.entidad);
            return true;
        }

        public bool Modificar()
        {
            this.entidad!.NombreInstrumento = "Disco2";
            this.aplicacion!.Modificar(this.entidad);
            return true;
        }

        public bool Borrar()
        {
            this.aplicacion!.Borrar(this.entidad!);
            return true;
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "No se puede borrar: el instrumento está asignado a un cliente")]
        public void Borrar_InstrumentoAsignado_DebeFallar()
        {
            var instrumento = EntidadesNucleo.Instrumentos()!;
            this.aplicacion!.Guardar(instrumento);

            // Crear relación cliente-instrumento
            var clienteInstrumento = new ClientesInstrumentos
            {
                IdClientes = 1, // Id ficticio
                IdInstrumentos = instrumento.Id
            };
            this.iConexion!.ClientesInstrumentos!.Add(clienteInstrumento);
            this.iConexion.SaveChanges();

            // Al intentar borrar debería lanzar excepción
            this.aplicacion!.Borrar(instrumento);
        }
    }
}
