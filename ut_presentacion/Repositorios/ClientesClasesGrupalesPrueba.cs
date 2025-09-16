using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using ut_presentacion.Nucleo;

namespace ut_presentacion.Repositorios
{
    [TestClass]
    public class ClientesClasesGrupalesPrueba
    {
        private readonly IConexion? iConexion;
        private List<ClientesClasesGrupales>? lista;
        private ClientesClasesGrupales? entidad;

        public ClientesClasesGrupalesPrueba()
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
            this.lista = this.iConexion!.ClientesClasesGrupales!.ToList();
            return lista.Count > 0;
        }

        public bool Guardar()
        {
            this.entidad = EntidadesNucleo.ClientesClasesGrupales()!;
            this.iConexion!.ClientesClasesGrupales!.Add(this.entidad);
            this.iConexion!.SaveChanges();

            return true;
        }

        public bool Modificar()
        {
            this.entidad! .IdClientes = 2;
            var entry = this.iConexion!.Entry<ClientesClasesGrupales>(this.entidad);
            entry.State = EntityState.Modified;
            this.iConexion!.SaveChanges();

            return true;
        }


        public bool Borrar()
        {
            this.iConexion!.ClientesClasesGrupales!.Remove(this.entidad!);
            this.iConexion!.SaveChanges();

            return true;
        }
    }
}