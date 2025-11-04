using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_repositorios.Implementaciones
{
    public class ClientesAplicacion : IClientesAplicacion
    {
        private IConexion? IConexion = null;

        public ClientesAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public Clientes? Borrar(Clientes? entidad)
        {
            Clientes? entidadvieja = this.IConexion!.Clientes!.FirstOrDefault(x => x.Id! == entidad!.Id);
            if (entidadvieja == null) throw new Exception("La entidad no existe");


            if (entidad == null)
                throw new Exception("lbFaltaInformación");

            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardó");

            if (this.IConexion!.ClientesClasesGrupales!.Any(s => s.IdClientes == entidad.Id))
                throw new Exception("lbCliente ligado a otras tablas");
            if (this.IConexion!.ClientesInstrumentos!.Any(s => s.IdClientes == entidad.Id))
                throw new Exception("lbCliente ligado a otras tablas");
            if (this.IConexion!.ClientesSuplementos!.Any(s => s.IdClientes == entidad.Id))
                throw new Exception("lbCliente ligado a otras tablas");
            if (this.IConexion!.ClientesMembresias!.Any(s => s.IdClientes == entidad.Id))
                throw new Exception("lbCliente ligado a otras tablas");
            if (this.IConexion!.InstalacionesClientes!.Any(s => s.IdClientes == entidad.Id))
                throw new Exception("lbCliente ligado a otras tablas");

            this.IConexion!.Clientes!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Clientes? Guardar(Clientes? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id != 0)
                throw new Exception("lbYaSeGuardo");

            if (entidad.Edad < 16)
                throw new Exception("No se puede registrar, cliente demasiado joven");

            this.IConexion!.Clientes!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Clientes> Listar()
        {
            return this.IConexion!.Clientes!.Take(20).ToList();
        }

        public Clientes? Modificar(Clientes? entidad)
        {
            Clientes? entidadvieja = this.IConexion!.Clientes!.FirstOrDefault(x => x.Id! == entidad!.Id);
            if (entidadvieja == null) throw new Exception("La entidad no existe");

            if (entidad == null)
                throw new Exception("lbFaltaInformación");

            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardó");

            if (entidad.CorreoElectronico!.Length > 100)
            {
                throw new Exception("Correo electronico invalido, demasiado largo");
            }
            else
            {
                string[] correo = entidad.CorreoElectronico.Split("@");
                if (!correo[1].Equals("gmail.com") && !correo[1].Equals("hotmail.com") && !correo[1].Equals("outlook.com"))
                    throw new Exception("Extención de correo invalida");
            }
            if (entidad.Telefono?.Length > 10)
            {
                throw new Exception("Telefeono demasido largo");
            }
            else if (entidad.Telefono?.Length < 7)
            {
                throw new Exception("Telefono demasiado corto");
            }

           

                var entry = this.IConexion!.Entry<Clientes>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}
