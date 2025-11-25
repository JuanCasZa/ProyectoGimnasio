using lib_dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace lib_repositorios.Interfaces
{
    public interface IClientesInstrumentosAplicacion
    {
        void Configurar(string StringConexion);
        List<ClientesInstrumentos> Listar();
        List<ClientesInstrumentos> Filtro(ClientesInstrumentos? entidad);
        ClientesInstrumentos? Guardar(ClientesInstrumentos? entidad);
        ClientesInstrumentos? Modificar(ClientesInstrumentos? entidad);
        ClientesInstrumentos? Borrar(ClientesInstrumentos? entidad);
    }
}
