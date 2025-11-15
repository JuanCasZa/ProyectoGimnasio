using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_repositorios.Implementaciones
{
    public class ClientesClasesGrupalesAplicacion : IClientesClasesGrupalesAplicacion
    {
        private IConexion? IConexion = null;

        public ClientesClasesGrupalesAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public ClientesClasesGrupales? Borrar(ClientesClasesGrupales? entidad)
        {
            ClientesClasesGrupales? entidadvieja = this.IConexion!.ClientesClasesGrupales!.FirstOrDefault(x => x.Id! == entidad!.Id);
            if (entidadvieja == null) throw new Exception("La entidad no existe");

            if (entidad == null)
                throw new Exception("lbFaltaInformación");

            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardó");

            this.IConexion!.ClientesClasesGrupales!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public ClientesClasesGrupales? Guardar(ClientesClasesGrupales? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id != 0)
                throw new Exception("lbYaSeGuardo");

            // Validar cliente
            if (!this.IConexion!.Clientes!.Any(c => c.Id == entidad.IdClientes))
                throw new Exception("Cliente no válido");

            // Validar clase grupal
            var clase = this.IConexion.ClasesGrupales!.FirstOrDefault(cg => cg.Id == entidad.IdClasesGrupales);
            if (clase == null)
                throw new Exception("Clase grupal no válida");

            // Validar capacidad
            var inscritos = this.IConexion.ClientesClasesGrupales!.Count(cc => cc.IdClasesGrupales == entidad.IdClasesGrupales);
            if (clase.CapacidadMax <= inscritos)
                throw new Exception("La clase ya alcanzó su capacidad máxima");

            // Inicializar asistencias si es null
            if (entidad.Asistencias == null) entidad.Asistencias = 0;

            this.IConexion!.ClientesClasesGrupales!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<ClientesClasesGrupales> Listar()
        {
            return this.IConexion!.ClientesClasesGrupales!.Take(20).ToList();
        }

        public List<ClientesClasesGrupales> Filtro(ClientesClasesGrupales? entidad)
        {
            //Filtro por Id del cliente e Id de la clase
            var consulta = this.IConexion!.ClientesClasesGrupales!.AsQueryable();

            if (entidad!.IdClientes != 0)
            {
                consulta = consulta.Where(x => x.IdClientes == entidad.IdClientes);
            }

            if (entidad!.IdClasesGrupales != 0)
            {
                consulta = consulta.Where(x => x.IdClasesGrupales == entidad.IdClasesGrupales);
            }

            return consulta.ToList();
        }

        public ClientesClasesGrupales? Modificar(ClientesClasesGrupales? entidad)
        {
            ClientesClasesGrupales? entidadvieja = this.IConexion!.ClientesClasesGrupales!.FirstOrDefault(x => x.Id! == entidad!.Id);
            if (entidadvieja == null) throw new Exception("La entidad no existe");

            if (entidad == null)
                throw new Exception("lbFaltaInformación");

            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardó");

            if (entidadvieja.IdClientes != entidad.IdClientes) throw new Exception("El id del cliente debe de ser el mismo");

            if (entidadvieja.IdClasesGrupales != entidad.IdClasesGrupales) throw new Exception("El id de la clase grupal debe de ser el mismo");

            var entry = this.IConexion!.Entry<ClientesClasesGrupales>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}
