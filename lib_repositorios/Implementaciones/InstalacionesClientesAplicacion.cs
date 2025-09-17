using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_repositorios.Implementaciones
{
    public class InstalacionesClientesAplicacion : IInstalacionesClientesAplicacion
    {
        private IConexion? IConexion = null;

        public InstalacionesClientesAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public InstalacionesClientes? Borrar(InstalacionesClientes? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformación");

            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardó");

            this.IConexion!.InstalacionesClientes!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public InstalacionesClientes? Guardar(InstalacionesClientes? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id != 0)
                throw new Exception("lbYaSeGuardo");

            // Validación: cliente e instalación existen
            if (!this.IConexion!.Clientes!.Any(c => c.Id == entidad.IdClientes))
                throw new Exception("Cliente no válido");

            if (!this.IConexion!.Instalaciones!.Any(i => i.Id == entidad.IdInstalaciones))
                throw new Exception("Instalación no válida");

            /* Registro de ingreso: si el campo RegistroIngresoClientes se usa como conteo,
               si viene vacío lo inicializamos en 1 */
            if (entidad.RegistroIngresoClientes == 0)
                entidad.RegistroIngresoClientes = 1;

            this.IConexion!.InstalacionesClientes!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<InstalacionesClientes> Listar()
        {
            return this.IConexion!.InstalacionesClientes!.Take(20).ToList();
        }

        public InstalacionesClientes? Modificar(InstalacionesClientes? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformación");

            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardó");

            var entry = this.IConexion!.Entry<InstalacionesClientes>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}
