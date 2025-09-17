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

        public InstalacionesEmpleados? Modificar(InstalacionesEmpleados? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformación");

            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardó");

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
