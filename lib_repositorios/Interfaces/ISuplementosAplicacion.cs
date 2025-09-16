using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lib_dominio.Entidades;

namespace lib_repositorios.Interfaces
{
    public interface ISuplementosAplicacion
    {
        void Configurar(string StringConexion);
        List<Suplementos> Listar();
        Suplementos? Guardar(Suplementos? entidad);
        Suplementos? Modificar(Suplementos? entidad);
        Suplementos? Borrar(Suplementos? entidad);
    }
}
