using lib_dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_repositorios.Interfaces
{
    public interface IInstrumentosAplicacion
    {
        void Configurar(string StringConexion);
        List<Instrumentos> Filtro(Instrumentos? entidad);
        List<Instrumentos> Listar();
        Instrumentos? Guardar(Instrumentos? entidad);
        Instrumentos? Modificar(Instrumentos? entidad);
        Instrumentos? Borrar(Instrumentos? entidad);
        String ToStringInstrumentos(Instrumentos? entidad);
    }
}
