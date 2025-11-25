using lib_dominio.Entidades;
using lib_dominio.Nucleo;
using lib_presentaciones.Interfaces;

namespace lib_presentaciones.Implementaciones
{
    public class InstrumentosPresentacion : IInstrumentosPresentacion
    {
        private Comunicaciones? comunicaciones = null;

        public async Task<List<Instrumentos>> Listar(string token/*Implementando cosas*/)
        {
            var lista = new List<Instrumentos>();
            var datos = new Dictionary<string, object>();

            comunicaciones = new Comunicaciones();
            datos = comunicaciones.ConstruirUrl(datos, "Instrumentos/Listar");
            var respuesta = await comunicaciones!.Ejecutar(datos, token /*IMPLEMENTANDO COSAS*/);

            if (respuesta.ContainsKey("Error"))
            {
                throw new Exception(respuesta["Error"].ToString()!);
            }
            lista = JsonConversor.ConvertirAObjeto<List<Instrumentos>>(
                JsonConversor.ConvertirAString(respuesta["Entidades"]));
            return lista;
        }

        public async Task<List<Instrumentos>> Filtro(Instrumentos? entidad, string token/*Implementando cosas*/)
        {
            var lista = new List<Instrumentos>();
            var datos = new Dictionary<string, object>();
            datos["Entidad"] = entidad!;

            comunicaciones = new Comunicaciones();
            datos = comunicaciones.ConstruirUrl(datos, "Instrumentos/Filtro");
            var respuesta = await comunicaciones!.Ejecutar(datos, token /*Implementando cosas*/);

            if (respuesta.ContainsKey("Error"))
            {
                throw new Exception(respuesta["Error"].ToString()!);
            }
            lista = JsonConversor.ConvertirAObjeto<List<Instrumentos>>(
                JsonConversor.ConvertirAString(respuesta["Entidades"]));
            return lista;
        }

        public async Task<Instrumentos?> Guardar(Instrumentos? entidad, string token/*Implementando cosas*/)
        {
            if (entidad!.Id != 0)
            {
                throw new Exception("lbFaltaInformacion");
            }
            var datos = new Dictionary<string, object>();
            datos["Entidad"] = entidad;

            comunicaciones = new Comunicaciones();
            datos = comunicaciones.ConstruirUrl(datos, "Instrumentos/Guardar");
            var respuesta = await comunicaciones!.Ejecutar(datos, token /*Implementando cosas*/);

            if (respuesta.ContainsKey("Error"))
            {
                throw new Exception(respuesta["Error"].ToString()!);
            }
            entidad = JsonConversor.ConvertirAObjeto<Instrumentos>(
                JsonConversor.ConvertirAString(respuesta["Entidad"]));
            return entidad;
        }

        public async Task<Instrumentos?> Modificar(Instrumentos? entidad, string token/*Implementando cosas*/)
        {
            if (entidad!.Id == 0)
            {
                throw new Exception("lbFaltaInformacion");
            }
            var datos = new Dictionary<string, object>();
            datos["Entidad"] = entidad;

            comunicaciones = new Comunicaciones();
            datos = comunicaciones.ConstruirUrl(datos, "Instrumentos/Modificar");

            var respuesta = await comunicaciones!.Ejecutar(datos, token /*IMPLEMENTANDO COSAS*/);
            if (respuesta.ContainsKey("Error"))
            {
                throw new Exception(respuesta["Error"].ToString()!);
            }
            entidad = JsonConversor.ConvertirAObjeto<Instrumentos>(
                JsonConversor.ConvertirAString(respuesta["Entidad"]));
            return entidad;
        }

        public async Task<Instrumentos?> Borrar(Instrumentos? entidad, string token/*Implementando cosas*/)
        {
            if (entidad!.Id == 0)
            {
                throw new Exception("lbFaltaInformacion");
            }
            var datos = new Dictionary<string, object>();
            datos["Entidad"] = entidad;

            comunicaciones = new Comunicaciones();
            datos = comunicaciones.ConstruirUrl(datos, "Instrumentos/Borrar");
            var respuesta = await comunicaciones!.Ejecutar(datos, token /*IMPLEMENTANDO COSAS*/);

            if (respuesta.ContainsKey("Error"))
            {
                throw new Exception(respuesta["Error"].ToString()!);
            }
            entidad = JsonConversor.ConvertirAObjeto<Instrumentos>(
                JsonConversor.ConvertirAString(respuesta["Entidad"]));
            return entidad;
        }
    }
}