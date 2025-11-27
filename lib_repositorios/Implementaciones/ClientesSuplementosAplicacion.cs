using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_repositorios.Implementaciones
{
    public class ClientesSuplementosAplicacion : IClientesSuplementosAplicacion
    {
        private IConexion? IConexion = null;

        public ClientesSuplementosAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public ClientesSuplementos? Borrar(ClientesSuplementos? entidad)
        {
            ClientesSuplementos? entidadvieja = this.IConexion!.ClientesSuplementos!.FirstOrDefault(x => x.Id! == entidad!.Id);
            if (entidadvieja == null) throw new Exception("La entidad no existe");

            if (entidad == null)
                throw new Exception("lbFaltaInformación");

            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardó");

            var entry = this.IConexion!.Entry<ClientesSuplementos>(entidad);
            entry.State = EntityState.Deleted;
            this.IConexion.SaveChanges();
            return entidad;
        }

        public ClientesSuplementos? Guardar(ClientesSuplementos? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id != 0)
                throw new Exception("lbYaSeGuardo");

            // Validación: cliente existe
            if (!this.IConexion!.Clientes!.Any(c => c.Id == entidad.IdClientes))
                throw new Exception("Cliente no válido");

            // Validación: suplemento existe
            var suplemento = this.IConexion.Suplementos!.FirstOrDefault(s => s.Id == entidad.IdSuplementos);
            if (suplemento == null)
                throw new Exception("Suplemento no válido");

            // Validación: stock suficiente (Suplementos.Cantidad)
            if (suplemento.Cantidad < entidad.CantidadCompraSuplementos)
                throw new Exception("Stock insuficiente");

            // Descontar inventario
            suplemento.Cantidad -= entidad.CantidadCompraSuplementos;
            this.IConexion.Entry(suplemento).State = EntityState.Modified;

            // Calcular ValorTotalCompra si no viene
            if (entidad.ValorTotalCompra == 0)
            {
                entidad.ValorTotalCompra = suplemento.Valor * entidad.CantidadCompraSuplementos;
            }

            this.IConexion.ClientesSuplementos!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<ClientesSuplementos> Listar()
        {
            return this.IConexion!.ClientesSuplementos!.Take(20).Include(x => x._IdClientes).Include(y => y._IdSuplementos).ToList();
        }

        public List<ClientesSuplementos> Filtro(ClientesSuplementos? entidad)
        {
            var consulta = this.IConexion!.ClientesSuplementos!.Include(x => x._IdClientes).Include(y => y._IdSuplementos).AsQueryable();

            //Filtro por el nombre del cliente
            if (entidad?._IdClientes?.Nombre is not null)
            {
                consulta = consulta.Where(x =>
                    x._IdClientes!.Nombre.Contains(entidad._IdClientes.Nombre)
                );
            }

            //Filtro por el nombre del suplemento
            if (entidad?._IdSuplementos?.NombreSuplemento is not null)
            {
                consulta = consulta.Where(x =>
                    x._IdSuplementos!.NombreSuplemento.Contains(entidad._IdSuplementos.NombreSuplemento)
                );
            }

            return consulta.ToList();
        }

        public ClientesSuplementos? Modificar(ClientesSuplementos? entidad)
        {
            ClientesSuplementos? entidadvieja = this.IConexion!.ClientesSuplementos!.FirstOrDefault(x => x.Id! == entidad!.Id);
            if (entidadvieja == null) throw new Exception("La entidad no existe");

            if (entidad == null)
                throw new Exception("lbFaltaInformación");

            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardó");

            if (entidadvieja.IdClientes != entidad.IdClientes) throw new Exception("El id del cliente debe de ser el mismo");

            if (entidadvieja.IdSuplementos != entidad.IdSuplementos) throw new Exception("El id del suplemento debe de ser el mismo");

            var entry = this.IConexion!.Entry<ClientesSuplementos>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
        public string ToStringClientesSuplementos(ClientesSuplementos? entidad)
        {
            if (entidad == null)
                return "lbFaltaInformación";
            return $"Id: {entidad.Id}, CantidadCompraSuplementos: {entidad.CantidadCompraSuplementos}, ValorTotalCompra: {entidad.ValorTotalCompra}, IdClientes: {entidad.IdClientes}, IdSuplementos: {entidad.IdSuplementos}";
        }
    }
}