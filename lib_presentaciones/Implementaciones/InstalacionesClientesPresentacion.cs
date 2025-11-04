using lib_dominio.Entidades;
using lib_dominio.Nucleo;
using lib_presentaciones.Interfaces;

namespace lib_presentaciones.Implementaciones
{
    public class InstalacionesClientesPresentacion : IInstalacionesClientesPresentacion
    {
        private Comunicaciones? comunicaciones = null;

        public async Task<List<InstalacionesClientes>> Listar()
        {
            var lista = new List<InstalacionesClientes>();
            var datos = new Dictionary<string, object>();

            comunicaciones = new Comunicaciones();
            datos = comunicaciones.ConstruirUrl(datos, "InstalacionesClientes/Listar");
            var respuesta = await comunicaciones!.Ejecutar(datos);

            if (respuesta.ContainsKey("Error"))
            {
                throw new Exception(respuesta["Error"].ToString()!);
            }
            lista = JsonConversor.ConvertirAObjeto<List<InstalacionesClientes>>(
                JsonConversor.ConvertirAString(respuesta["Entidades"]));
            return lista;
        }

        //public async Task<List<InstalacionesClientes>> PorTipo(InstalacionesClientes? entidad)
        //{
        //    var lista = new List<InstalacionesClientes>();
        //    var datos = new Dictionary<string, object>();
        //    datos["Entidad"] = entidad!;

        //    comunicaciones = new Comunicaciones();
        //    datos = comunicaciones.ConstruirUrl(datos, "InstalacionesClientes/PorTipo");
        //    var respuesta = await comunicaciones!.Ejecutar(datos);

        //    if (respuesta.ContainsKey("Error"))
        //    {
        //        throw new Exception(respuesta["Error"].ToString()!);
        //    }
        //    lista = JsonConversor.ConvertirAObjeto<List<InstalacionesClientes>>(
        //        JsonConversor.ConvertirAString(respuesta["Entidades"]));
        //    return lista;
        //}

        public async Task<InstalacionesClientes?> Guardar(InstalacionesClientes? entidad)
        {
            if (entidad!.Id != 0)
            {
                throw new Exception("lbFaltaInformacion");
            }
            var datos = new Dictionary<string, object>();
            datos["Entidad"] = entidad;

            comunicaciones = new Comunicaciones();
            datos = comunicaciones.ConstruirUrl(datos, "InstalacionesClientes/Guardar");
            var respuesta = await comunicaciones!.Ejecutar(datos);

            if (respuesta.ContainsKey("Error"))
            {
                throw new Exception(respuesta["Error"].ToString()!);
            }
            entidad = JsonConversor.ConvertirAObjeto<InstalacionesClientes>(
                JsonConversor.ConvertirAString(respuesta["Entidad"]));
            return entidad;
        }

        public async Task<InstalacionesClientes?> Modificar(InstalacionesClientes? entidad)
        {
            if (entidad!.Id == 0)
            {
                throw new Exception("lbFaltaInformacion");
            }
            var datos = new Dictionary<string, object>();
            datos["Entidad"] = entidad;

            comunicaciones = new Comunicaciones();
            datos = comunicaciones.ConstruirUrl(datos, "InstalacionesClientes/Modificar");

            var respuesta = await comunicaciones!.Ejecutar(datos);
            if (respuesta.ContainsKey("Error"))
            {
                throw new Exception(respuesta["Error"].ToString()!);
            }
            entidad = JsonConversor.ConvertirAObjeto<InstalacionesClientes>(
                JsonConversor.ConvertirAString(respuesta["Entidad"]));
            return entidad;
        }

        public async Task<InstalacionesClientes?> Borrar(InstalacionesClientes? entidad)
        {
            if (entidad!.Id == 0)
            {
                throw new Exception("lbFaltaInformacion");
            }
            var datos = new Dictionary<string, object>();
            datos["Entidad"] = entidad;

            comunicaciones = new Comunicaciones();
            datos = comunicaciones.ConstruirUrl(datos, "InstalacionesClientes/Borrar");
            var respuesta = await comunicaciones!.Ejecutar(datos);

            if (respuesta.ContainsKey("Error"))
            {
                throw new Exception(respuesta["Error"].ToString()!);
            }
            entidad = JsonConversor.ConvertirAObjeto<InstalacionesClientes>(
                JsonConversor.ConvertirAString(respuesta["Entidad"]));
            return entidad;
        }
    }
}
