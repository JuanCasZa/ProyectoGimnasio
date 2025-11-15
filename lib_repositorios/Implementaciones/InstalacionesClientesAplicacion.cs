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
            InstalacionesClientes? entidadvieja = this.IConexion!.InstalacionesClientes!.FirstOrDefault(x => x.Id! == entidad!.Id);
            if (entidadvieja == null) throw new Exception("La entidad no existe");

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

        public List<InstalacionesClientes> Filtro(InstalacionesClientes? entidad)
        {
            //Filtro por Id de cliente y de instalacion
            var consulta = this.IConexion!.InstalacionesClientes!.AsQueryable();

            if (entidad!.IdClientes != 0)
            {
                consulta = consulta.Where(x => x.IdClientes == entidad.IdClientes);
            }

            if (entidad!.IdInstalaciones != 0)
            {
                consulta = consulta.Where(x => x.IdInstalaciones == entidad.IdInstalaciones);
            }

            return consulta.ToList();
        }

        public InstalacionesClientes? Modificar(InstalacionesClientes? entidad)
        {
            InstalacionesClientes? entidadvieja = this.IConexion!.InstalacionesClientes!.FirstOrDefault(x => x.Id! == entidad!.Id);
            if (entidadvieja == null) throw new Exception("La entidad no existe");

            if (entidad == null)
                throw new Exception("lbFaltaInformación");

            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardó");

            if (entidadvieja.IdInstalaciones != entidad.IdInstalaciones) throw new Exception("El id de la instalacion debe de ser el mismo");

            if (entidadvieja.IdClientes != entidad.IdClientes) throw new Exception("El id del cliente debe de ser el mismo");

            var entry = this.IConexion!.Entry<InstalacionesClientes>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}
