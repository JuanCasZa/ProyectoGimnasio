using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_repositorios.Implementaciones
{
    public class InstalacionesClientesAplicacion : IInstalacionesClientesAplicacion
    {
        private IConexion? IConexion;

        public InstalacionesClientesAplicacion(IConexion conexion)
        {
            IConexion = conexion;
        }

        public void Configurar(string StringConexion)
        {
            if (IConexion != null) IConexion.StringConexion = StringConexion;
        }

        public List<InstalacionesClientes> Listar()
        {
            return IConexion!.InstalacionesClientes!
                .Include(ic => ic._IdClientes)
                .Include(ic => ic._IdInstalaciones)
                .ToList();
        }

        public InstalacionesClientes? Guardar(InstalacionesClientes? entidad)
        {
            if (entidad == null) throw new Exception("lbFaltaInformacion");
            if (entidad.Id != 0) throw new Exception("lbYaSeGuardo");

            IConexion!.InstalacionesClientes!.Add(entidad);
            IConexion.SaveChanges();
            return entidad;
        }

        public InstalacionesClientes? Modificar(InstalacionesClientes? entidad)
        {
            if (entidad == null) throw new Exception("lbFaltaInformacion");

            var existente = IConexion!.InstalacionesClientes!.Find(entidad.Id);
            if (existente == null) throw new Exception("lbNoExiste");

            IConexion.Entry(existente).CurrentValues.SetValues(entidad);
            IConexion.SaveChanges();
            return entidad;
        }

        public InstalacionesClientes? Borrar(InstalacionesClientes? entidad)
        {
            if (entidad == null) throw new Exception("lbFaltaInformacion");

            var existente = IConexion!.InstalacionesClientes!.Find(entidad.Id);
            if (existente == null) throw new Exception("lbNoExiste");

            IConexion.InstalacionesClientes!.Remove(existente);
            IConexion.SaveChanges();
            return existente;
        }
    }
}