using lib_dominio.Entidades;
using lib_dominio.Nucleo;
using lib_presentaciones.Interfaces;

namespace lib_presentaciones.Implementaciones
{
    public class ClasesGrupalesPresentacion : IClasesGrupalesPresentacion
    {
        private Comunicaciones? comunicaciones = null;

        public async Task<List<ClasesGrupales>> Listar()
        {
            var lista = new List<ClasesGrupales>();
            var datos = new Dictionary<string, object>();

            comunicaciones = new Comunicaciones();
            datos = comunicaciones.ConstruirUrl(datos, "ClasesGrupales/Listar");
            var respuesta = await comunicaciones!.Ejecutar(datos);

            if (respuesta.ContainsKey("Error"))
            {
                throw new Exception(respuesta["Error"].ToString()!);
            }
            lista = JsonConversor.ConvertirAObjeto<List<ClasesGrupales>>(
                JsonConversor.ConvertirAString(respuesta["Entidades"]));
            return lista;
        }

        //public async Task<List<ClasesGrupales>> PorTipo(ClasesGrupales? entidad)
        //{
        //    var lista = new List<ClasesGrupales>();
        //    var datos = new Dictionary<string, object>();
        //    datos["Entidad"] = entidad!;

        //    comunicaciones = new Comunicaciones();
        //    datos = comunicaciones.ConstruirUrl(datos, "ClasesGrupales/PorTipo");
        //    var respuesta = await comunicaciones!.Ejecutar(datos);

        //    if (respuesta.ContainsKey("Error"))
        //    {
        //        throw new Exception(respuesta["Error"].ToString()!);
        //    }
        //    lista = JsonConversor.ConvertirAObjeto<List<ClasesGrupales>>(
        //        JsonConversor.ConvertirAString(respuesta["Entidades"]));
        //    return lista;
        //}

        public async Task<ClasesGrupales?> Guardar(ClasesGrupales? entidad)
        {
            if (entidad!.Id != 0)
            {
                throw new Exception("lbFaltaInformacion");
            }
            var datos = new Dictionary<string, object>();
            datos["Entidad"] = entidad;

            comunicaciones = new Comunicaciones();
            datos = comunicaciones.ConstruirUrl(datos, "ClasesGrupales/Guardar");
            var respuesta = await comunicaciones!.Ejecutar(datos);

            if (respuesta.ContainsKey("Error"))
            {
                throw new Exception(respuesta["Error"].ToString()!);
            }
            entidad = JsonConversor.ConvertirAObjeto<ClasesGrupales>(
                JsonConversor.ConvertirAString(respuesta["Entidad"]));
            return entidad;
        }

        public async Task<ClasesGrupales?> Modificar(ClasesGrupales? entidad)
        {
            if (entidad!.Id == 0)
            {
                throw new Exception("lbFaltaInformacion");
            }
            var datos = new Dictionary<string, object>();
            datos["Entidad"] = entidad;

            comunicaciones = new Comunicaciones();
            datos = comunicaciones.ConstruirUrl(datos, "ClasesGrupales/Modificar");

            var respuesta = await comunicaciones!.Ejecutar(datos);
            if (respuesta.ContainsKey("Error"))
            {
                throw new Exception(respuesta["Error"].ToString()!);
            }
            entidad = JsonConversor.ConvertirAObjeto<ClasesGrupales>(
                JsonConversor.ConvertirAString(respuesta["Entidad"]));
            return entidad;
        }

        public async Task<ClasesGrupales?> Borrar(ClasesGrupales? entidad)
        {
            if (entidad!.Id == 0)
            {
                throw new Exception("lbFaltaInformacion");
            }
            var datos = new Dictionary<string, object>();
            datos["Entidad"] = entidad;

            comunicaciones = new Comunicaciones();
            datos = comunicaciones.ConstruirUrl(datos, "ClasesGrupales/Borrar");
            var respuesta = await comunicaciones!.Ejecutar(datos);

            if (respuesta.ContainsKey("Error"))
            {
                throw new Exception(respuesta["Error"].ToString()!);
            }
            entidad = JsonConversor.ConvertirAObjeto<ClasesGrupales>(
                JsonConversor.ConvertirAString(respuesta["Entidad"]));
            return entidad;
        }
    }
}
