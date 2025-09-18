using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lib_repositorios.Interfaces;
using lib_repositorios.Implementaciones;
using lib_dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using ut_presentacion.Nucleo;

namespace PruebasUnitariasAplicaciones
{
    [TestClass]
    public class ClientesAplicacionPrueba
    {
        private readonly IConexion? iConexion;
        private ClientesAplicacion? aplicacion;
        private List<Clientes>? lista;
        private Clientes? entidad;

        public ClientesAplicacionPrueba()
        {
            iConexion = new Conexion();
            iConexion.StringConexion = Configuracion.ObtenerValor("StringConexion");
            aplicacion = new ClientesAplicacion(iConexion);
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
            this.entidad = EntidadesNucleo.Clientes()!;
            this.aplicacion!.Guardar(this.entidad);
            return true;
        }

        public bool Modificar()
        {
            this.entidad!.Nombre = "NombrePruebaDesdeTest";
            this.aplicacion!.Modificar(this.entidad);
            return true;
        }

        public bool Borrar()
        {
            this.aplicacion!.Borrar(this.entidad!);
            return true;
        }
    }
}
