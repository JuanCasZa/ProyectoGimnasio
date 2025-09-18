using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace lib_repositorios.Implementaciones
{
    public class InstalacionesAplicacion : IInstalacionesAplicacion
    {
        private IConexion? IConexion = null;

        public InstalacionesAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public Instalaciones? Borrar(Instalaciones? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformación");

            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardó");

            this.IConexion!.Instalaciones!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Instalaciones? Guardar(Instalaciones? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id != 0)
                throw new Exception("lbYaSeGuardo");

            if (entidad.Direccion == null)
                throw new Exception("Direccion no ingresada");

            this.IConexion!.Instalaciones!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Instalaciones> Listar()
        {
            return this.IConexion!.Instalaciones!.Take(20).ToList();
        }

        public Instalaciones? Modificar(Instalaciones? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformación");

            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardó");

            if (entidad.Direccion?.Length > 150)
                throw new Exception("Direccion demasiado larga, utilice abreviaturas");

            if (entidad.Telefono.Length > 10)
            {
                throw new Exception("Número de telefono invalido, demasiado largo");
            }
            else if(entidad.Telefono.Length < 7)
            {
                throw new Exception("Número invalido, demasiado corto");
            }


                var entry = this.IConexion!.Entry<Instalaciones>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}
