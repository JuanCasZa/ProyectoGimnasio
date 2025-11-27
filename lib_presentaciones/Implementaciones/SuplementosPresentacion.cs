using lib_dominio.Entidades;
using lib_dominio.Nucleo;
using lib_presentaciones.Interfaces;

namespace lib_presentaciones.Implementaciones
{
    public class SuplementosPresentacion : ISuplementosPresentacion
    {
        private Comunicaciones? comunicaciones = null;

        public async Task<List<Suplementos>> Listar(string token/*Implementando cosas*/)
        {
            var lista = new List<Suplementos>();
            var datos = new Dictionary<string, object>();

            comunicaciones = new Comunicaciones();
            datos = comunicaciones.ConstruirUrl(datos, "Suplementos/Listar");
            var respuesta = await comunicaciones!.Ejecutar(datos, token /*IMPLEMENTANDO COSAS*/);

            if (respuesta.ContainsKey("Error"))
            {
                throw new Exception(respuesta["Error"].ToString()!);
            }
            lista = JsonConversor.ConvertirAObjeto<List<Suplementos>>(
                JsonConversor.ConvertirAString(respuesta["Entidades"]));
            return lista;
        }

        public async Task<List<Suplementos>> Filtro(Suplementos? entidad, string token/*Implementando cosas*/)
        {
            var lista = new List<Suplementos>();
            var datos = new Dictionary<string, object>();
            datos["Entidad"] = entidad!;

            comunicaciones = new Comunicaciones();
            datos = comunicaciones.ConstruirUrl(datos, "Suplementos/Filtro");
            var respuesta = await comunicaciones!.Ejecutar(datos, token /*Implementando cosas*/);

            if (respuesta.ContainsKey("Error"))
            {
                throw new Exception(respuesta["Error"].ToString()!);
            }
            lista = JsonConversor.ConvertirAObjeto<List<Suplementos>>(
                JsonConversor.ConvertirAString(respuesta["Entidades"]));
            return lista;
        }

        public async Task<Suplementos?> Guardar(Suplementos? entidad, string token/*Implementando cosas*/)
        {
            if (entidad!.Id != 0)
            {
                throw new Exception("lbFaltaInformacion");
            }

            //Validacion para campos no vacios
            if (entidad!.NombreSuplemento == null || entidad!.TipoSuplemento == null)
                throw new Exception("CamposVacios");

            var datos = new Dictionary<string, object>();
            datos["Entidad"] = entidad;

            comunicaciones = new Comunicaciones();
            datos = comunicaciones.ConstruirUrl(datos, "Suplementos/Guardar");
            var respuesta = await comunicaciones!.Ejecutar(datos, token /*Implementando cosas*/);

            if (respuesta.ContainsKey("Error"))
            {
                throw new Exception(respuesta["Error"].ToString()!);
            }
            entidad = JsonConversor.ConvertirAObjeto<Suplementos>(
                JsonConversor.ConvertirAString(respuesta["Entidad"]));
            return entidad;
        }

        public async Task<Suplementos?> Modificar(Suplementos? entidad, string token/*Implementando cosas*/)
        {
            if (entidad!.Id == 0)
            {
                throw new Exception("lbFaltaInformacion");
            }

            //Validacion para campos no vacios
            if (entidad!.NombreSuplemento == null || entidad!.TipoSuplemento == null)
                throw new Exception("CamposVacios");

            var datos = new Dictionary<string, object>();
            datos["Entidad"] = entidad;

            comunicaciones = new Comunicaciones();
            datos = comunicaciones.ConstruirUrl(datos, "Suplementos/Modificar");

            var respuesta = await comunicaciones!.Ejecutar(datos, token /*IMPLEMENTANDO COSAS*/);
            if (respuesta.ContainsKey("Error"))
            {
                throw new Exception(respuesta["Error"].ToString()!);
            }
            entidad = JsonConversor.ConvertirAObjeto<Suplementos>(
                JsonConversor.ConvertirAString(respuesta["Entidad"]));
            return entidad;
        }

        public async Task<Suplementos?> Borrar(Suplementos? entidad, string token/*Implementando cosas*/)
        {
            if (entidad!.Id == 0)
            {
                throw new Exception("lbFaltaInformacion");
            }
            var datos = new Dictionary<string, object>();
            datos["Entidad"] = entidad;

            comunicaciones = new Comunicaciones();
            datos = comunicaciones.ConstruirUrl(datos, "Suplementos/Borrar");
            var respuesta = await comunicaciones!.Ejecutar(datos, token /*IMPLEMENTANDO COSAS*/);

            if (respuesta.ContainsKey("Error"))
            {
                throw new Exception(respuesta["Error"].ToString()!);
            }
            entidad = JsonConversor.ConvertirAObjeto<Suplementos>(
                JsonConversor.ConvertirAString(respuesta["Entidad"]));
            return entidad;
        }
    }
}