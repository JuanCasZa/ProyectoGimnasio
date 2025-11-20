using lib_dominio.Nucleo;

namespace lib_presentaciones
{
    public class Comunicaciones
    {
        private string? URL = string.Empty, llave = null;

        //Se establece la URL del servicio web
        public Comunicaciones(string url = "http://localhost:5291/") //EL NUMERO DE AQUI DEBE COINCIDIR CON EL DEL ASP_SERVICIOS CUANDO SE INICIA
        {
            URL = url;
        }

        //Se construye la URL del método a invocar
        public Dictionary<string, object> ConstruirUrl(Dictionary<string, object> data, string Metodo)
        {
            data["Url"] = URL + Metodo;                 //URL completa del método a invocar
            data["UrlLlave"] = URL + "Token/Autenticar";     //URL para obtener la llave de autenticación
            return data;
            //Acá se prepararon los datos necesarios para la invocación del servicio web
        }

        /*
        public async Task<Dictionary<string, object>> Ejecutar(Dictionary<string, object> datos)
        {
            var respuesta = new Dictionary<string, object>();
            try
            {
                respuesta = await Llave(datos);
                if (respuesta == null || respuesta.ContainsKey("Error"))
                    return respuesta!;
                respuesta.Clear();

                var url = datos["Url"].ToString();
                datos.Remove("Url");
                datos.Remove("UrlLlave");
                datos["Llave"] = llave!;
                var stringData = JsonConversor.ConvertirAString(datos);

                var httpClient = new HttpClient();
                httpClient.Timeout = new TimeSpan(0, 4, 0);
                var message = await httpClient.PostAsync(url, new StringContent(stringData));
                if (!message.IsSuccessStatusCode)
                {
                    respuesta.Add("Error", "lbErrorComunicacion");
                    return respuesta;
                }

                var resp = await message.Content.ReadAsStringAsync();
                httpClient.Dispose(); httpClient = null;
                if (string.IsNullOrEmpty(resp))
                {
                    respuesta.Add("Error", "lbErrorComunicacion");
                    return respuesta;
                }

                resp = Replace(resp);
                respuesta = JsonConversor.ConvertirAObjeto(resp);
                return respuesta;
            }
            catch (Exception ex)
            {
                respuesta["Error"] = ex.ToString();
                return respuesta;
            }
        }*/

        //Nuevo Ejecutar
        public async Task<Dictionary<string, object>> Ejecutar(Dictionary<string, object> datos, string token)
        {
            var respuesta = new Dictionary<string, object>();
            try
            {
                var url = datos["Url"].ToString();
                datos.Remove("Url");
                datos.Remove("UrlLlave");

                datos["Llave"] = token;

                var stringData = JsonConversor.ConvertirAString(datos);

                var httpClient = new HttpClient();
                httpClient.Timeout = new TimeSpan(0, 4, 0);

                var message = await httpClient.PostAsync(url, new StringContent(stringData));

                if (!message.IsSuccessStatusCode)
                {
                    respuesta["Error"] = "lbErrorComunicacion";
                    return respuesta;
                }

                var resp = await message.Content.ReadAsStringAsync();
                httpClient.Dispose();

                resp = Replace(resp);
                return JsonConversor.ConvertirAObjeto(resp);
            }
            catch (Exception ex)
            {
                respuesta["Error"] = ex.ToString();
                return respuesta;
            }
        }
        
        //"Eliminando al metodo Llave"
        /*
        private async Task<Dictionary<string, object>> Llave(Dictionary<string, object> datos)
        {
            var respuesta = new Dictionary<string, object>();
            try
            {
                var url = datos["UrlLlave"].ToString();

                var temp = new Dictionary<string, object>();

                //HAY QUE SOLUCIONAR ESTO, PORQUE ES UN USUARIO QUEMADO
                temp["Entidad"] = new Dictionary<string, object>()
                {
                    { "Nombre", "JuanPerez" },
                    { "Contrasenha", "1234Segura!" }
                };

                var stringData = JsonConversor.ConvertirAString(temp);

                var httpClient = new HttpClient();
                httpClient.Timeout = new TimeSpan(0, 1, 0);

                var mensaje = await httpClient.PostAsync(url!, new StringContent(stringData));
                if (!mensaje.IsSuccessStatusCode)
                {
                    respuesta.Add("Error", "lbErrorComunicacion");
                    return respuesta;
                }

                var resp = await mensaje.Content.ReadAsStringAsync();
                httpClient.Dispose(); //Liberar recursos
                httpClient = null;
                if (string.IsNullOrEmpty(resp))
                {
                    respuesta.Add("Error", "lbErrorComunicacion");
                    return respuesta;
                }

                resp = Replace(resp);
                respuesta = JsonConversor.ConvertirAObjeto(resp);
                llave = respuesta["Llave"].ToString();
                return respuesta;
            }
            catch (Exception ex)
            {
                respuesta["Error"] = ex.ToString();
                return respuesta;
            }
        }
        */

        private string Replace(string resp)
        {
            return resp.Replace("\\\\r\\\\n", "")
            .Replace("\\r\\n", "")
            .Replace("\\", "")
            .Replace("\\\"", "\"")
            .Replace("\"", "'")
            .Replace("'[", "[")
            .Replace("]'", "]")
            .Replace("'{'", "{'")
            .Replace("\\\\", "\\")
            .Replace("'}'", "'}")
            .Replace("}'", "}")
            .Replace("\\n", "")
            .Replace("\\r", "")
            .Replace(" ", "")
            .Replace("'{", "{")
            .Replace("\"", "")
            .Replace(" ", "")
            .Replace("null", "''");
        }
    }
}