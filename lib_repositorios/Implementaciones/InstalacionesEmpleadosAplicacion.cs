using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_repositorios.Implementaciones
{
    public class InstalacionesEmpleadosAplicacion : IInstalacionesEmpleadosAplicacion
    {
        private IConexion? IConexion = null;

        public InstalacionesEmpleadosAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public InstalacionesEmpleados? Borrar(InstalacionesEmpleados? entidad)
        {
            InstalacionesEmpleados? entidadvieja = this.IConexion!.InstalacionesEmpleados!.FirstOrDefault(x => x.Id! == entidad!.Id);
            if (entidadvieja == null) throw new Exception("La entidad no existe");


            if (entidad == null)
                throw new Exception("lbFaltaInformación");

            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardó");

            //Operaciones
            entidad._IdInstalaciones = null;
            entidad._IdEmpleados = null;

            this.IConexion!.InstalacionesEmpleados!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public InstalacionesEmpleados? Guardar(InstalacionesEmpleados? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id != 0)
                throw new Exception("lbYaSeGuardo");

            if (!(this.IConexion!.Instalaciones!.Any(x => x.Id! == entidad!.IdInstalaciones)))
            {
                throw new Exception($"La instalacion con id {entidad.IdInstalaciones} no existe");
            }

            if (!(this.IConexion!.Empleados!.Any(x => x.Id! == entidad!.IdEmpleados)))
            {
                throw new Exception($"El empleado con id {entidad.IdEmpleados} no existe");
            }

            //Operaciones
            entidad._IdInstalaciones = null;
            entidad._IdEmpleados = null;

            this.IConexion!.InstalacionesEmpleados!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<InstalacionesEmpleados> Listar()
        {
            return this.IConexion!.InstalacionesEmpleados!.Take(20).ToList();
        }

        public List<InstalacionesEmpleados> PorIdEmpleados(InstalacionesEmpleados? entidad)
        {
            if (entidad == null)
            {
                return new List<InstalacionesEmpleados>();
            }

            return this.IConexion!.InstalacionesEmpleados!.Where(x => x.IdEmpleados! == entidad!.IdEmpleados).ToList();
        }

        public List<InstalacionesEmpleados> PorIdInstalaciones(InstalacionesEmpleados? entidad)
        {
            if (entidad == null)
            {
                return new List<InstalacionesEmpleados>();
            }

            return this.IConexion!.InstalacionesEmpleados!.Where(x => x.IdInstalaciones! == entidad!.IdInstalaciones).ToList();
        }
        public InstalacionesEmpleados? Modificar(InstalacionesEmpleados? entidad)
        {
            InstalacionesEmpleados? entidadvieja = this.IConexion!.InstalacionesEmpleados!.FirstOrDefault(x => x.Id! == entidad!.Id);
            if (entidadvieja == null) throw new Exception("La entidad no existe");

            if (entidad == null)
                throw new Exception("lbFaltaInformación");

            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardó");

            if (!(this.IConexion!.Instalaciones!.Any(x => x.Id! == entidad!.IdInstalaciones)))
            {
                throw new Exception($"La instalacion con id {entidad.IdInstalaciones} no existe");
            }

            if (!(this.IConexion!.Empleados!.Any(x => x.Id! == entidad!.IdEmpleados)))
            {
                throw new Exception($"El empleado con id {entidad.IdEmpleados} no existe");
            }

            //Operaciones
            entidad._IdInstalaciones = null;
            entidad._IdEmpleados = null;

            var entry = this.IConexion!.Entry<InstalacionesEmpleados>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}
