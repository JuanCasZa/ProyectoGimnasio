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
            if (entidad == null)
                throw new Exception("lbFaltaInformación");

            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardó");

            // Reintegrar inventario en la eliminación de la compra
            var suplemento = this.IConexion!.Suplementos!.FirstOrDefault(s => s.Id == entidad.IdSuplementos);
            if (suplemento != null)
            {
                suplemento.Cantidad += entidad.CantidadCompraSuplementos;
                this.IConexion.Entry(suplemento).State = EntityState.Modified;
            }

            // Borrado físico (si tu política es borrar). Si prefieres borrado lógico, adapta aquí.
            var entry = this.IConexion.Entry<ClientesSuplementos>(entidad);
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
            return this.IConexion!.ClientesSuplementos!.Take(20).ToList();
        }

        public ClientesSuplementos? Modificar(ClientesSuplementos? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformación");

            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardó");

            var entry = this.IConexion!.Entry<ClientesSuplementos>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}