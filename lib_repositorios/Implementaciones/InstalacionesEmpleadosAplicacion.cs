using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_repositorios.Implementaciones
{
    public class InstalacionesEmpleadosAplicacion : IInstalacionesEmpleadosAplicacion
    {
        private IConexion? IConexion;

        public InstalacionesEmpleadosAplicacion(IConexion conexion)
        {
            IConexion = conexion;
        }

        public void Configurar(string StringConexion)
        {
            if (IConexion != null) IConexion.StringConexion = StringConexion;
        }

        public List<InstalacionesEmpleados> Listar()
        {
            return IConexion!.InstalacionesEmpleados!
                .Include(ie => ie._IdEmpleados)
                .Include(ie => ie._IdInstalaciones)
                .ToList();
        }

        public InstalacionesEmpleados? Guardar(InstalacionesEmpleados? entidad)
        {
            if (entidad == null) throw new Exception("lbFaltaInformacion");
            if (entidad.Id != 0) throw new Exception("lbYaSeGuardo");

            IConexion!.InstalacionesEmpleados!.Add(entidad);
            IConexion.SaveChanges();
            return entidad;
        }

        public InstalacionesEmpleados? Modificar(InstalacionesEmpleados? entidad)
        {
            if (entidad == null) throw new Exception("lbFaltaInformacion");

            var existente = IConexion!.InstalacionesEmpleados!.Find(entidad.Id);
            if (existente == null) throw new Exception("lbNoExiste");

            IConexion.Entry(existente).CurrentValues.SetValues(entidad);
            IConexion.SaveChanges();
            return entidad;
        }

        public InstalacionesEmpleados? Borrar(InstalacionesEmpleados? entidad)
        {
            if (entidad == null) throw new Exception("lbFaltaInformacion");

            var existente = IConexion!.InstalacionesEmpleados!.Find(entidad.Id);
            if (existente == null) throw new Exception("lbNoExiste");

            IConexion.InstalacionesEmpleados!.Remove(existente);
            IConexion.SaveChanges();
            return existente;
        }
    }
}