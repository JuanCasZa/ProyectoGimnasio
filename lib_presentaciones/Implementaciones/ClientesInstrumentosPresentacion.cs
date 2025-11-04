using lib_dominio.Entidades;
using lib_dominio.Nucleo;
using lib_presentaciones.Interfaces;

namespace lib_presentaciones.Implementaciones
{
    public class ClientesInstrumentosPresentacion : IClientesInstrumentosPresentacion
    {
        private Comunicaciones? comunicaciones = null;

        public async Task<List<ClientesInstrumentos>> Listar()
        {
            var lista = new List<ClientesInstrumentos>();
            var datos = new Dictionary<string, object>();

            comunicaciones = new Comunicaciones();
            datos = comunicaciones.ConstruirUrl(datos, "ClientesInstrumentos/Listar");
            var respuesta = await comunicaciones!.Ejecutar(datos);

            if (respuesta.ContainsKey("Error"))
            {
                throw new Exception(respuesta["Error"].ToString()!);
            }
            lista = JsonConversor.ConvertirAObjeto<List<ClientesInstrumentos>>(
                JsonConversor.ConvertirAString(respuesta["Entidades"]));
            return lista;
        }

        //public async Task<List<ClientesInstrumentos>> PorTipo(ClientesInstrumentos? entidad)
        //{
        //    var lista = new List<ClientesInstrumentos>();
        //    var datos = new Dictionary<string, object>();
        //    datos["Entidad"] = entidad!;

        //    comunicaciones = new Comunicaciones();
        //    datos = comunicaciones.ConstruirUrl(datos, "ClientesInstrumentos/PorTipo");
        //    var respuesta = await comunicaciones!.Ejecutar(datos);

        //    if (respuesta.ContainsKey("Error"))
        //    {
        //        throw new Exception(respuesta["Error"].ToString()!);
        //    }
        //    lista = JsonConversor.ConvertirAObjeto<List<ClientesInstrumentos>>(
        //        JsonConversor.ConvertirAString(respuesta["Entidades"]));
        //    return lista;
        //}

        public async Task<ClientesInstrumentos?> Guardar(ClientesInstrumentos? entidad)
        {
            if (entidad!.Id != 0)
            {
                throw new Exception("lbFaltaInformacion");
            }
            var datos = new Dictionary<string, object>();
            datos["Entidad"] = entidad;

            comunicaciones = new Comunicaciones();
            datos = comunicaciones.ConstruirUrl(datos, "ClientesInstrumentos/Guardar");
            var respuesta = await comunicaciones!.Ejecutar(datos);

            if (respuesta.ContainsKey("Error"))
            {
                throw new Exception(respuesta["Error"].ToString()!);
            }
            entidad = JsonConversor.ConvertirAObjeto<ClientesInstrumentos>(
                JsonConversor.ConvertirAString(respuesta["Entidad"]));
            return entidad;
        }

        public async Task<ClientesInstrumentos?> Modificar(ClientesInstrumentos? entidad)
        {
            if (entidad!.Id == 0)
            {
                throw new Exception("lbFaltaInformacion");
            }
            var datos = new Dictionary<string, object>();
            datos["Entidad"] = entidad;

            comunicaciones = new Comunicaciones();
            datos = comunicaciones.ConstruirUrl(datos, "ClientesInstrumentos/Modificar");

            var respuesta = await comunicaciones!.Ejecutar(datos);
            if (respuesta.ContainsKey("Error"))
            {
                throw new Exception(respuesta["Error"].ToString()!);
            }
            entidad = JsonConversor.ConvertirAObjeto<ClientesInstrumentos>(
                JsonConversor.ConvertirAString(respuesta["Entidad"]));
            return entidad;
        }

        public async Task<ClientesInstrumentos?> Borrar(ClientesInstrumentos? entidad)
        {
            if (entidad!.Id == 0)
            {
                throw new Exception("lbFaltaInformacion");
            }
            var datos = new Dictionary<string, object>();
            datos["Entidad"] = entidad;

            comunicaciones = new Comunicaciones();
            datos = comunicaciones.ConstruirUrl(datos, "ClientesInstrumentos/Borrar");
            var respuesta = await comunicaciones!.Ejecutar(datos);

            if (respuesta.ContainsKey("Error"))
            {
                throw new Exception(respuesta["Error"].ToString()!);
            }
            entidad = JsonConversor.ConvertirAObjeto<ClientesInstrumentos>(
                JsonConversor.ConvertirAString(respuesta["Entidad"]));
            return entidad;
        }
    }
}
