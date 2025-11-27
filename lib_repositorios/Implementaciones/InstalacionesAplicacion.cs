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
            Instalaciones? entidadvieja = this.IConexion!.Instalaciones!.FirstOrDefault(x => x.Id! == entidad!.Id);
            if (entidadvieja == null) throw new Exception("La entidad no existe");

            if (entidad == null)
                throw new Exception("lbFaltaInformación");

            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardó");

            if (this.IConexion!.InstalacionesEmpleados!.Any(s => s.IdInstalaciones == entidad.Id))
                throw new Exception("lbInstalacion ligada a otras tablas");
            if (this.IConexion!.InstalacionesClientes!.Any(s => s.IdInstalaciones == entidad.Id))
                throw new Exception("lbInstalacion ligada a otras tablas");

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

        public List<Instalaciones> Filtro(Instalaciones? entidad)
        {
            
            var consulta = this.IConexion!.Instalaciones!.AsQueryable();

            //Filtro por Direccion y por Telefono
            consulta = consulta.Where(x => x.Direccion!.Contains(entidad!.Direccion!) && x.Telefono!.Contains(entidad!.Telefono!)).Take(50);

            return consulta.ToList();
        }

        public Instalaciones? Modificar(Instalaciones? entidad)
        {
            Instalaciones? entidadvieja = this.IConexion!.Instalaciones!.FirstOrDefault(x => x.Id! == entidad!.Id);
            if (entidadvieja == null) throw new Exception("La entidad no existe");

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
        public String ToStringInstalaciones(Instalaciones? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformación");
            return $"Id: {entidad.Id}, Dirección: {entidad.Direccion}, Teléfono: {entidad.Telefono}";
        }
    }
}
