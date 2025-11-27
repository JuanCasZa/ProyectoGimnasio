using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lib_dominio.Entidades;

namespace lib_repositorios.Interfaces
{
    public interface IProveedoresAplicacion
    {
        void Configurar(string StringConexion);
        List<Proveedores> Listar();
        List<Proveedores> Filtro(Proveedores? entidad);
        Proveedores? Guardar(Proveedores? entidad);
        Proveedores? Modificar(Proveedores? entidad);
        Proveedores? Borrar(Proveedores? entidad);
        String ToStringProveedores(Proveedores? entidad);
    }
}
