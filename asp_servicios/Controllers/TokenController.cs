using Microsoft.AspNetCore.Mvc; 
using lib_dominio.Nucleo;
using lib_repositorios.Implementaciones;
using asp_servicios.Nucleo;
using lib_dominio.Entidades;

namespace asp_servicios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class TokenController : ControllerBase
    {
        private TokenAplicacion? iAplicacion = null;
        public TokenController(TokenAplicacion iAplicacion) 
        { 
            this.iAplicacion = iAplicacion;
        }
        private Dictionary<string, object> ObtenerDatos() 
        { 
            var respuesta = new Dictionary<string, object>(); 
            try 
            { 
                var datos = new StreamReader(Request.Body).ReadToEnd().ToString(); 
                if (string.IsNullOrEmpty(datos)) 
                    datos = "{}";
                return JsonConversor.ConvertirAObjeto(datos);
            } 
            catch (Exception ex) 
            { 
                respuesta["Error"] = ex.Message.ToString(); 
                return respuesta; 
            } 
        }

        [HttpPost]
        public string Autenticar()
        {
            var respuesta = new Dictionary<string, object>(); 
            try
            {
                var datos = ObtenerDatos(); 
                this.iAplicacion!.Configurar(Configuracion.ObtenerValor("StringConexion"));

                var entidad = JsonConversor.ConvertirAObjeto<Usuarios>
                    (JsonConversor.ConvertirAString(datos["Entidad"]));

                respuesta["Llave"] = this.iAplicacion.Llave(entidad);
                respuesta["Respuesta"] = "OK";
                respuesta["Fecha"] = DateTime.Now.ToString();
                return JsonConversor.ConvertirAString(respuesta);
            }
            catch (Exception ex) 
            { 
                respuesta["Error"] = ex.ToString();
                respuesta["Respuesta"] = "ERROR";
                return JsonConversor.ConvertirAString(respuesta); 
            }
        }
    }
}
