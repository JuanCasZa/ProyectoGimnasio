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
            ClientesMembresias? entidadvieja = this.IConexion!.ClientesMembresias!.FirstOrDefault(x => x.Id! == entidad!.Id);
            if (entidadvieja == null) throw new Exception("La entidad no existe");

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

            var membresia = this.IConexion!.Membresias!
               .FirstOrDefault(i => i.Id == entidad.IdMembresias);

            if (membresia == null)
                throw new Exception("La membresia no existe");

            var cliente = this.IConexion!.Clientes!
               .FirstOrDefault(i => i.Id == entidad.IdClientes);

            if (cliente == null)
                throw new Exception("El cliente no existe");

            // Regla de negocio: evitar solapamiento de membresías activas
            var ahora = DateTime.Now;
            var tieneActiva = this.IConexion.ClientesMembresias!.Any(cm => cm.IdClientes == entidad.IdClientes
                           && (cm.FechaFin == null || cm.FechaFin >= ahora));

            // Si pasa validaciones, asignamos FechaInicio si no viene y añadimos la entidad
            if (entidad.FechaInicio == null) entidad.FechaInicio = DateTime.Now;

            this.IConexion.ClientesMembresias!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<ClientesMembresias> Listar()
        {
            return this.IConexion!.ClientesMembresias!.Take(20).Include(x => x._IdClientes).Include(y => y._IdMembresias).ToList();
        }

        public List<ClientesMembresias> Filtro(ClientesMembresias? entidad)
        {
            
            var consulta = this.IConexion!.ClientesMembresias!.Include(x => x._IdClientes).Include(y => y._IdMembresias).AsQueryable();

            //Filtro por el nombre del cliente
            if (entidad?._IdClientes?.Nombre is not null)
            {
                consulta = consulta.Where(x =>
                    x._IdClientes!.Nombre.Contains(entidad._IdClientes.Nombre)
                );
            }

            //Filtro por el tipo de membresia
            if (entidad?._IdMembresias?.TipoMembresia is not null)
            {
                consulta = consulta.Where(x =>
                    x._IdMembresias!.TipoMembresia.Contains(entidad._IdMembresias.TipoMembresia)
                );
            }

            return consulta.ToList();
        }

        public ClientesMembresias? Modificar(ClientesMembresias? entidad)
        {
            ClientesMembresias? entidadvieja = this.IConexion!.ClientesMembresias!.FirstOrDefault(x => x.Id! == entidad!.Id);
            if (entidadvieja == null) throw new Exception("La entidad no existe");

            if (entidad == null)
                throw new Exception("lbFaltaInformación");

            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardó");

            var membresia = this.IConexion!.Membresias!
               .FirstOrDefault(i => i.Id == entidad.IdMembresias);

            if (membresia == null)
                throw new Exception("La membresia no existe");

            var cliente = this.IConexion!.Clientes!
               .FirstOrDefault(i => i.Id == entidad.IdClientes);

            if (cliente == null)
                throw new Exception("El cliente no existe");

            var entry = this.IConexion!.Entry<ClientesMembresias>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
        public String ToStringClienteMembresia(ClientesMembresias? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformación");
            ClientesMembresias? entidadvieja = this.IConexion!.ClientesMembresias!
                .Include(x => x._IdClientes)
                .Include(y => y._IdMembresias)
                .FirstOrDefault(x => x.Id! == entidad!.Id);
            if (entidadvieja == null) throw new Exception("La entidad no existe");
            return $"Cliente: {entidadvieja._IdClientes!.Nombre}, Membresía: {entidadvieja._IdMembresias!.TipoMembresia}, Inicio: {entidadvieja.FechaInicio}, Fin: {entidadvieja.FechaFin}";
        }
    }
}