using lib_dominio.Entidades;
using lib_dominio.Nucleo;
using lib_presentaciones.Interfaces;

namespace lib_presentaciones.Implementaciones
{
    public class ClientesMembresiasPresentacion : IClientesMembresiasPresentacion
    {
        private Comunicaciones? comunicaciones = null;

        public async Task<List<ClientesMembresias>> Listar(string token/*Implementando cosas*/)
        {
            var lista = new List<ClientesMembresias>();
            var datos = new Dictionary<string, object>();

            comunicaciones = new Comunicaciones();
            datos = comunicaciones.ConstruirUrl(datos, "ClientesMembresias/Listar");
            var respuesta = await comunicaciones!.Ejecutar(datos, token /*IMPLEMENTANDO COSAS*/);

            if (respuesta.ContainsKey("Error"))
            {
                throw new Exception(respuesta["Error"].ToString()!);
            }
            lista = JsonConversor.ConvertirAObjeto<List<ClientesMembresias>>(
                JsonConversor.ConvertirAString(respuesta["Entidades"]));
            return lista;
        }

        public async Task<List<ClientesMembresias>> Filtro(ClientesMembresias? entidad, string token/*Implementando cosas*/)
        {
            var lista = new List<ClientesMembresias>();
            var datos = new Dictionary<string, object>();
            datos["Entidad"] = entidad!;

            comunicaciones = new Comunicaciones();
            datos = comunicaciones.ConstruirUrl(datos, "ClientesMembresias/Filtro");
            var respuesta = await comunicaciones!.Ejecutar(datos, token /*Implementando cosas*/);

            if (respuesta.ContainsKey("Error"))
            {
                throw new Exception(respuesta["Error"].ToString()!);
            }
            lista = JsonConversor.ConvertirAObjeto<List<ClientesMembresias>>(
                JsonConversor.ConvertirAString(respuesta["Entidades"]));
            return lista;
        }

        public async Task<ClientesMembresias?> Guardar(ClientesMembresias? entidad, string token/*Implementando cosas*/)
        {
            if (entidad!.Id != 0)
            {
                throw new Exception("lbFaltaInformacion");
            }
            var datos = new Dictionary<string, object>();
            datos["Entidad"] = entidad;

            comunicaciones = new Comunicaciones();
            datos = comunicaciones.ConstruirUrl(datos, "ClientesMembresias/Guardar");
            var respuesta = await comunicaciones!.Ejecutar(datos, token /*Implementando cosas*/);

            if (respuesta.ContainsKey("Error"))
            {
                throw new Exception(respuesta["Error"].ToString()!);
            }
            entidad = JsonConversor.ConvertirAObjeto<ClientesMembresias>(
                JsonConversor.ConvertirAString(respuesta["Entidad"]));
            return entidad;
        }

        public async Task<ClientesMembresias?> Modificar(ClientesMembresias? entidad, string token/*Implementando cosas*/)
        {
            if (entidad!.Id == 0)
            {
                throw new Exception("lbFaltaInformacion");
            }
            var datos = new Dictionary<string, object>();
            datos["Entidad"] = entidad;

            comunicaciones = new Comunicaciones();
            datos = comunicaciones.ConstruirUrl(datos, "ClientesMembresias/Modificar");

            var respuesta = await comunicaciones!.Ejecutar(datos, token /*IMPLEMENTANDO COSAS*/);
            if (respuesta.ContainsKey("Error"))
            {
                throw new Exception(respuesta["Error"].ToString()!);
            }
            entidad = JsonConversor.ConvertirAObjeto<ClientesMembresias>(
                JsonConversor.ConvertirAString(respuesta["Entidad"]));
            return entidad;
        }

        public async Task<ClientesMembresias?> Borrar(ClientesMembresias? entidad, string token/*Implementando cosas*/)
        {
            if (entidad!.Id == 0)
            {
                throw new Exception("lbFaltaInformacion");
            }
            var datos = new Dictionary<string, object>();
            datos["Entidad"] = entidad;

            comunicaciones = new Comunicaciones();
            datos = comunicaciones.ConstruirUrl(datos, "ClientesMembresias/Borrar");
            var respuesta = await comunicaciones!.Ejecutar(datos, token /*IMPLEMENTANDO COSAS*/);

            if (respuesta.ContainsKey("Error"))
            {
                throw new Exception(respuesta["Error"].ToString()!);
            }
            entidad = JsonConversor.ConvertirAObjeto<ClientesMembresias>(
                JsonConversor.ConvertirAString(respuesta["Entidad"]));
            return entidad;
        }
    }
}