using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_repositorios.Implementaciones
{
    public class ClientesMembresiasAplicacion : IClientesMembresiasAplicacion
    {
        private IConexion? IConexion = null;

        public ClientesMembresiasAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public ClientesMembresias? Borrar(ClientesMembresias? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformación");

            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardó");

            this.IConexion!.ClientesMembresias!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public ClientesMembresias? Guardar(ClientesMembresias? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id != 0)
                throw new Exception("lbYaSeGuardo");

            // Validar membresía
            if (!this.IConexion!.Membresias!.Any(m => m.Id == entidad.IdMembresias))
                throw new Exception("Membresía no válida");

            // Regla de negocio: evitar solapamiento de membresías activas
            var ahora = DateTime.Now;
            var tieneActiva = this.IConexion.ClientesMembresias!.Any(cm => cm.IdClientes == entidad.IdClientes
                           && (cm.FechaFin == null || cm.FechaFin >= ahora));
            if (tieneActiva)
                throw new Exception("El cliente ya tiene una membresía activa o vigente");

            // Si pasa validaciones, asignamos FechaInicio si no viene y añadimos la entidad
            if (entidad.FechaInicio == null) entidad.FechaInicio = DateTime.Now;

            this.IConexion.ClientesMembresias!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<ClientesMembresias> Listar()
        {
            return this.IConexion!.ClientesMembresias!.Take(20).ToList();
        }

        public ClientesMembresias? Modificar(ClientesMembresias? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformación");

            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardó");

            var entry = this.IConexion!.Entry<ClientesMembresias>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}