using lib_dominio.Entidades;
using lib_dominio.Nucleo;
using lib_presentaciones.Interfaces;

namespace lib_presentaciones.Implementaciones
{
    public class InstalacionesEmpleadosPresentacion : IInstalacionesEmpleadosPresentacion
    {
        private Comunicaciones? comunicaciones = null;

        public async Task<List<InstalacionesEmpleados>> Listar(string token/*Implementando cosas*/)
        {
            var lista = new List<InstalacionesEmpleados>();
            var datos = new Dictionary<string, object>();

            comunicaciones = new Comunicaciones();
            datos = comunicaciones.ConstruirUrl(datos, "InstalacionesEmpleados/Listar");
            var respuesta = await comunicaciones!.Ejecutar(datos, token /*IMPLEMENTANDO COSAS*/);

            if (respuesta.ContainsKey("Error"))
            {
                throw new Exception(respuesta["Error"].ToString()!);
            }
            lista = JsonConversor.ConvertirAObjeto<List<InstalacionesEmpleados>>(
                JsonConversor.ConvertirAString(respuesta["Entidades"]));
            return lista;
        }

        public async Task<List<InstalacionesEmpleados>> Filtro(InstalacionesEmpleados? entidad, string token/*Implementando cosas*/)
        {
            var lista = new List<InstalacionesEmpleados>();
            var datos = new Dictionary<string, object>();
            datos["Entidad"] = entidad!;

            comunicaciones = new Comunicaciones();
            datos = comunicaciones.ConstruirUrl(datos, "InstalacionesEmpleados/Filtro");
            var respuesta = await comunicaciones!.Ejecutar(datos, token /*Implementando cosas*/);

            if (respuesta.ContainsKey("Error"))
            {
                throw new Exception(respuesta["Error"].ToString()!);
            }
            lista = JsonConversor.ConvertirAObjeto<List<InstalacionesEmpleados>>(
                JsonConversor.ConvertirAString(respuesta["Entidades"]));
            return lista;
        }

        public async Task<InstalacionesEmpleados?> Guardar(InstalacionesEmpleados? entidad, string token/*Implementando cosas*/)
        {
            if (entidad!.Id != 0)
            {
                throw new Exception("lbFaltaInformacion");
            }
            var datos = new Dictionary<string, object>();
            datos["Entidad"] = entidad;

            comunicaciones = new Comunicaciones();
            datos = comunicaciones.ConstruirUrl(datos, "InstalacionesEmpleados/Guardar");
            var respuesta = await comunicaciones!.Ejecutar(datos, token /*Implementando cosas*/);

            if (respuesta.ContainsKey("Error"))
            {
                throw new Exception(respuesta["Error"].ToString()!);
            }
            entidad = JsonConversor.ConvertirAObjeto<InstalacionesEmpleados>(
                JsonConversor.ConvertirAString(respuesta["Entidad"]));
            return entidad;
        }

        public async Task<InstalacionesEmpleados?> Modificar(InstalacionesEmpleados? entidad, string token/*Implementando cosas*/)
        {
            if (entidad!.Id == 0)
            {
                throw new Exception("lbFaltaInformacion");
            }
            var datos = new Dictionary<string, object>();
            datos["Entidad"] = entidad;

            comunicaciones = new Comunicaciones();
            datos = comunicaciones.ConstruirUrl(datos, "InstalacionesEmpleados/Modificar");

            var respuesta = await comunicaciones!.Ejecutar(datos, token /*IMPLEMENTANDO COSAS*/);
            if (respuesta.ContainsKey("Error"))
            {
                throw new Exception(respuesta["Error"].ToString()!);
            }
            entidad = JsonConversor.ConvertirAObjeto<InstalacionesEmpleados>(
                JsonConversor.ConvertirAString(respuesta["Entidad"]));
            return entidad;
        }

        public async Task<InstalacionesEmpleados?> Borrar(InstalacionesEmpleados? entidad, string token/*Implementando cosas*/)
        {
            if (entidad!.Id == 0)
            {
                throw new Exception("lbFaltaInformacion");
            }
            var datos = new Dictionary<string, object>();
            datos["Entidad"] = entidad;

            comunicaciones = new Comunicaciones();
            datos = comunicaciones.ConstruirUrl(datos, "InstalacionesEmpleados/Borrar");
            var respuesta = await comunicaciones!.Ejecutar(datos, token /*IMPLEMENTANDO COSAS*/);

            if (respuesta.ContainsKey("Error"))
            {
                throw new Exception(respuesta["Error"].ToString()!);
            }
            entidad = JsonConversor.ConvertirAObjeto<InstalacionesEmpleados>(
                JsonConversor.ConvertirAString(respuesta["Entidad"]));
            return entidad;
        }
    }
}