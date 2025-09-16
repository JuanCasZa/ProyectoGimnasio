using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_repositorios.Implementaciones
{
    public class ClientesClasesGrupalesAplicacion : IClientesClasesGrupalesAplicacion
    {
        private IConexion? IConexion;

        public ClientesClasesGrupalesAplicacion(IConexion conexion)
        {
            IConexion = conexion;
        }

        public void Configurar(string StringConexion)
        {
            if (IConexion != null) IConexion.StringConexion = StringConexion;
        }

        public List<ClientesClasesGrupales> Listar()
        {
            return IConexion!.ClientesClasesGrupales!
                .Include(ccg => ccg._IdClientes)
                .Include(ccg => ccg._IdClasesGrupales)
                .ToList();
        }

        public ClientesClasesGrupales? Guardar(ClientesClasesGrupales? entidad)
        {
            if (entidad == null) throw new Exception("lbFaltaInformacion");
            if (entidad.Id != 0) throw new Exception("lbYaSeGuardo");

            IConexion!.ClientesClasesGrupales!.Add(entidad);
            IConexion.SaveChanges();
            return entidad;
        }

        public ClientesClasesGrupales? Modificar(ClientesClasesGrupales? entidad)
        {
            if (entidad == null) throw new Exception("lbFaltaInformacion");

            var existente = IConexion!.ClientesClasesGrupales!.Find(entidad.Id);
            if (existente == null) throw new Exception("lbNoExiste");

            IConexion.Entry(existente).CurrentValues.SetValues(entidad);
            IConexion.SaveChanges();
            return entidad;
        }

        public ClientesClasesGrupales? Borrar(ClientesClasesGrupales? entidad)
        {
            if (entidad == null) throw new Exception("lbFaltaInformacion");

            var existente = IConexion!.ClientesClasesGrupales!.Find(entidad.Id);
            if (existente == null) throw new Exception("lbNoExiste");

            IConexion.ClientesClasesGrupales!.Remove(existente);
            IConexion.SaveChanges();
            return existente;
        }
    }
}