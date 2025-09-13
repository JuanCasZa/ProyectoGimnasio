using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using ut_presentacion.Nucleo;

namespace ut_presentacion.Repositorios
{
    [TestClass]
    public class PersonasPrueba
    {
        private readonly IConexion? iConexion;
        private List<Personas>? lista;
        private Personas? entidad;

        public PersonasPrueba()
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
            this.lista = this.iConexion!.Personas!.ToList();
            return lista.Count > 0;
        }

        public bool Guardar()
        {
            this.entidad = EntidadesNucleo.Personas()!;
            this.iConexion!.Personas!.Add(this.entidad);
            this.iConexion!.SaveChanges();

            return true;
        }
        
        public bool Modificar()
        {
            this.entidad!.Nombre = "Luis";
            var entry = this.iConexion!.Entry<Personas>(this.entidad);
            entry.State = EntityState.Modified;
            this.iConexion!.SaveChanges();

            return true;
        }
        

        public bool Borrar()
        {
            this.iConexion!.Personas!.Remove(this.entidad!);
            this.iConexion!.SaveChanges();
            return true;
        }
    }
}
