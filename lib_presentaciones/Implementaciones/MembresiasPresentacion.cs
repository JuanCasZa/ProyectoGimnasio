using lib_dominio.Entidades;
using lib_dominio.Nucleo;
using lib_presentaciones.Interfaces;

namespace lib_presentaciones.Implementaciones
{
    public class MembresiasPresentacion : IMembresiasPresentacion
    {
        private Comunicaciones? comunicaciones = null;

        public async Task<List<Membresias>> Listar()
        {
            var lista = new List<Membresias>();
            var datos = new Dictionary<string, object>();

            comunicaciones = new Comunicaciones();
            datos = comunicaciones.ConstruirUrl(datos, "Membresias/Listar");
            var respuesta = await comunicaciones!.Ejecutar(datos);

            if (respuesta.ContainsKey("Error"))
            {
                throw new Exception(respuesta["Error"].ToString()!);
            }
            lista = JsonConversor.ConvertirAObjeto<List<Membresias>>(
                JsonConversor.ConvertirAString(respuesta["Entidades"]));
            return lista;
        }

        //public async Task<List<Membresias>> PorTipo(Membresias? entidad)
        //{
        //    var lista = new List<Membresias>();
        //    var datos = new Dictionary<string, object>();
        //    datos["Entidad"] = entidad!;

        //    comunicaciones = new Comunicaciones();
        //    datos = comunicaciones.ConstruirUrl(datos, "Membresias/PorTipo");
        //    var respuesta = await comunicaciones!.Ejecutar(datos);

        //    if (respuesta.ContainsKey("Error"))
        //    {
        //        throw new Exception(respuesta["Error"].ToString()!);
        //    }
        //    lista = JsonConversor.ConvertirAObjeto<List<Membresias>>(
        //        JsonConversor.ConvertirAString(respuesta["Entidades"]));
        //    return lista;
        //}

        public async Task<Membresias?> Guardar(Membresias? entidad)
        {
            if (entidad!.Id != 0)
            {
                throw new Exception("lbFaltaInformacion");
            }
            var datos = new Dictionary<string, object>();
            datos["Entidad"] = entidad;

            comunicaciones = new Comunicaciones();
            datos = comunicaciones.ConstruirUrl(datos, "Membresias/Guardar");
            var respuesta = await comunicaciones!.Ejecutar(datos);

            if (respuesta.ContainsKey("Error"))
            {
                throw new Exception(respuesta["Error"].ToString()!);
            }
            entidad = JsonConversor.ConvertirAObjeto<Membresias>(
                JsonConversor.ConvertirAString(respuesta["Entidad"]));
            return entidad;
        }

        public async Task<Membresias?> Modificar(Membresias? entidad)
        {
            if (entidad!.Id == 0)
            {
                throw new Exception("lbFaltaInformacion");
            }
            var datos = new Dictionary<string, object>();
            datos["Entidad"] = entidad;

            comunicaciones = new Comunicaciones();
            datos = comunicaciones.ConstruirUrl(datos, "Membresias/Modificar");

            var respuesta = await comunicaciones!.Ejecutar(datos);
            if (respuesta.ContainsKey("Error"))
            {
                throw new Exception(respuesta["Error"].ToString()!);
            }
            entidad = JsonConversor.ConvertirAObjeto<Membresias>(
                JsonConversor.ConvertirAString(respuesta["Entidad"]));
            return entidad;
        }

        public async Task<Membresias?> Borrar(Membresias? entidad)
        {
            if (entidad!.Id == 0)
            {
                throw new Exception("lbFaltaInformacion");
            }
            var datos = new Dictionary<string, object>();
            datos["Entidad"] = entidad;

            comunicaciones = new Comunicaciones();
            datos = comunicaciones.ConstruirUrl(datos, "Membresias/Borrar");
            var respuesta = await comunicaciones!.Ejecutar(datos);

            if (respuesta.ContainsKey("Error"))
            {
                throw new Exception(respuesta["Error"].ToString()!);
            }
            entidad = JsonConversor.ConvertirAObjeto<Membresias>(
                JsonConversor.ConvertirAString(respuesta["Entidad"]));
            return entidad;
        }
    }
}
