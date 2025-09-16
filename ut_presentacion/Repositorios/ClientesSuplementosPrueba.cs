using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using ut_presentacion.Nucleo;

namespace ut_presentacion.Repositorios
{
    [TestClass]
    public class ClientesSuplementosPrueba
    {
        private readonly IConexion? iConexion;
        private List<ClientesSuplementos>? lista;
        private ClientesSuplementos? entidad;

        public ClientesSuplementosPrueba()
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
            this.lista = this.iConexion!.ClientesSuplementos!.ToList();
            return lista.Count > 0;
        }

        public bool Guardar()
        {
            this.entidad = EntidadesNucleo.ClientesSuplementos()!;
            this.iConexion!.ClientesSuplementos!.Add(this.entidad);
            this.iConexion!.SaveChanges();

            return true;
        }

        public bool Modificar()
        {
            this.entidad!.IdClientes = 1;
            var entry = this.iConexion!.Entry<ClientesSuplementos>(this.entidad);
            entry.State = EntityState.Modified;
            this.iConexion!.SaveChanges();

            return true;
        }


        public bool Borrar()
        {
            this.iConexion!.ClientesSuplementos!.Remove(this.entidad!);
            this.iConexion!.SaveChanges();

            return true;
        }
    }
}
