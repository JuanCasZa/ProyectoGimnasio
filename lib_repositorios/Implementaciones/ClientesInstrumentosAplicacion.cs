using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_repositorios.Implementaciones
{
    public class ClientesInstrumentosAplicacion : IClientesInstrumentosAplicacion
    {
        private IConexion? IConexion = null;

        public ClientesInstrumentosAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }
        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }
        public ClientesInstrumentos? Borrar(ClientesInstrumentos? entidad)
        {
            ClientesInstrumentos? entidadvieja = this.IConexion!.ClientesInstrumentos!.FirstOrDefault(x => x.Id! == entidad!.Id);
            if (entidadvieja == null) throw new Exception("La entidad no existe");

            if (entidad == null)
                throw new Exception("lbFaltaInformación");

            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardó");

            entidad._IdClientes = null;
            entidad._IdInstrumentos = null;

            this.IConexion!.ClientesInstrumentos!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }
        public ClientesInstrumentos? Guardar(ClientesInstrumentos? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id != 0)
                throw new Exception("lbYaSeGuardo");

            //Validar que el instrumento este disponible
            var instrumento = this.IConexion!.Instrumentos!
                .FirstOrDefault(i => i.Id == entidad.IdInstrumentos);

            if (instrumento == null)
                throw new Exception("El instrumento no existe");

            if (instrumento.Estado == false)
                throw new Exception("El instrumento no está disponible");

            //Validar que el cliente exista
            var cliente = this.IConexion!.Clientes!
                .FirstOrDefault(i => i.Id == entidad.IdClientes);

            if (cliente == null)
                throw new Exception("El cliente no existe");

            //Valida que no se reserven mas instrumentos de los que hay
            int cantidadReservada = this.IConexion!.ClientesInstrumentos!
                .Count(ci => ci.IdInstrumentos == entidad.IdInstrumentos);

            if (cantidadReservada >= instrumento.CantidadEquip)
                throw new Exception("No hay más unidades disponibles de este instrumento");

            //Valida que un cliente no reserve el mismo instrumento dos veces
            bool yaReservado = this.IConexion!.ClientesInstrumentos!
                .Any(ci => ci.IdClientes == entidad.IdClientes && ci.IdInstrumentos == entidad.IdInstrumentos);

            if (yaReservado)
                throw new Exception("El cliente ya reservó este instrumento");

            entidad._IdClientes = null;
            entidad._IdInstrumentos = null;

            this.IConexion!.ClientesInstrumentos!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }
        public List<ClientesInstrumentos> Listar()
        {
            return this.IConexion!.ClientesInstrumentos!.Take(20).ToList();
        }

        public List<ClientesInstrumentos> PorIdClientes(ClientesInstrumentos? entidad)
        {
            if (entidad == null)
            {
                return new List<ClientesInstrumentos>();
            }

            return this.IConexion!.ClientesInstrumentos!.Where(x => x.IdClientes! == entidad!.IdClientes).ToList();
        }

        public List<ClientesInstrumentos> PorIdInstrumentos(ClientesInstrumentos? entidad)
        {
            if (entidad == null)
            {
                return new List<ClientesInstrumentos>();
            }

            return this.IConexion!.ClientesInstrumentos!.Where(x => x.IdInstrumentos! == entidad!.IdInstrumentos).ToList();
        }

        public ClientesInstrumentos? Modificar(ClientesInstrumentos? entidad)
        {
            ClientesInstrumentos? entidadvieja = this.IConexion!.ClientesInstrumentos!.FirstOrDefault(x => x.Id! == entidad!.Id);
            if (entidadvieja == null) throw new Exception("La entidad no existe");

            if (entidad == null)
                throw new Exception("lbFaltaInformación");

            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardó");

            var instrumento = this.IConexion!.Instrumentos!
               .FirstOrDefault(i => i.Id == entidad.IdInstrumentos);

            if (instrumento == null)
                throw new Exception("El instrumento no existe");

            var cliente = this.IConexion!.Clientes!
               .FirstOrDefault(i => i.Id == entidad.IdClientes);

            if (cliente == null)
                throw new Exception("El cliente no existe");

            entidad._IdClientes = null;
            entidad._IdInstrumentos = null;

            var entry = this.IConexion!.Entry<ClientesInstrumentos>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}
