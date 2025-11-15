using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lib_dominio.Entidades;

namespace lib_repositorios.Interfaces
{
    public interface IClasesGrupalesAplicacion
    {
        void Configurar(string StringConexion);
        List<ClasesGrupales> Listar();
        List<ClasesGrupales> Filtro(ClasesGrupales? entidad);
        ClasesGrupales? Guardar(ClasesGrupales? entidad);
        ClasesGrupales? Modificar(ClasesGrupales? entidad);
        ClasesGrupales? Borrar(ClasesGrupales? entidad);
    }
}
