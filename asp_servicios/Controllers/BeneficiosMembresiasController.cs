using asp_servicios.Nucleo;
using lib_repositorios.Interfaces;
using lib_dominio.Entidades;
using lib_dominio.Nucleo;
using Microsoft.AspNetCore.Mvc;
using lib_repositorios.Implementaciones;

namespace asp_servicios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class BeneficiosMembresiasController : ControllerBase
    {
        private IBeneficiosMembresiasAplicacion? iAplicacion = null;
        private TokenAplicacion? iAplicacionToken = null;

        public BeneficiosMembresiasController(IBeneficiosMembresiasAplicacion? iAplicacion, TokenAplicacion iAplicacionToken)
        {
            this.iAplicacion = iAplicacion;
            this.iAplicacionToken = iAplicacionToken;
        }

        private Dictionary<string, object> ObtenerDatos()
        {
            var datos = new StreamReader(Request.Body).ReadToEnd().ToString();
            if (string.IsNullOrEmpty(datos))
                datos = "{}";
            return JsonConversor.ConvertirAObjeto(datos);
        }

        [HttpPost]
        public string Listar()
        {
            var respuesta = new Dictionary<string, object>();
            try
            {
                var datos = ObtenerDatos();
                this.iAplicacion!.Configurar(Configuracion.ObtenerValor("StringConexion"));
                this.iAplicacionToken!.Configurar(Configuracion.ObtenerValor("StringConexion"));
                if (!(iAplicacionToken!.Validar(datos) && (iAplicacionToken.ValidarRol(datos["Llave"].ToString()!).Equals("Administrador")
                    || iAplicacionToken.ValidarRol(datos["Llave"].ToString()!).Equals("Entrenador") || iAplicacionToken.ValidarRol(datos["Llave"].ToString()!).Equals("Recepcionista"))))
                {
                    respuesta["Error"] = "lbNoAutenticacion";
                    return JsonConversor.ConvertirAString(respuesta);
                }

                respuesta["Entidades"] = this.iAplicacion!.Listar();
                respuesta["Respuesta"] = "OK";
                respuesta["Fecha"] = DateTime.Now.ToString();
                return JsonConversor.ConvertirAString(respuesta);
            }
            catch (Exception ex)
            {
                respuesta["Error"] = ex.Message.ToString();
                respuesta["Respuesta"] = "Error";
                return JsonConversor.ConvertirAString(respuesta);
            }
        }

        [HttpPost]
        public string Filtro()
        {
            var respuesta = new Dictionary<string, object>();
            try
            {
                var datos = ObtenerDatos();
                this.iAplicacion!.Configurar(Configuracion.ObtenerValor("StringConexion"));
                this.iAplicacionToken!.Configurar(Configuracion.ObtenerValor("StringConexion"));
                if (!(iAplicacionToken!.Validar(datos) && (iAplicacionToken.ValidarRol(datos["Llave"].ToString()!).Equals("Administrador")
                    || iAplicacionToken.ValidarRol(datos["Llave"].ToString()!).Equals("Entrenador") || iAplicacionToken.ValidarRol(datos["Llave"].ToString()!).Equals("Recepcionista"))))
                {
                    respuesta["Error"] = "lbNoAutenticacion";
                    return JsonConversor.ConvertirAString(respuesta);
                }
                var entidad = JsonConversor.ConvertirAObjeto<BeneficiosMembresias>(
                JsonConversor.ConvertirAString(datos["Entidad"]));

                respuesta["Entidades"] = this.iAplicacion!.Filtro(entidad);
                respuesta["Respuesta"] = "OK";
                respuesta["Fecha"] = DateTime.Now.ToString();
                return JsonConversor.ConvertirAString(respuesta);
            }
            catch (Exception ex)
            {
                respuesta["Error"] = ex.Message.ToString();
                respuesta["Respuesta"] = "Error";
                return JsonConversor.ConvertirAString(respuesta);
            }
        }

        [HttpPost]
        public string Guardar()
        {
            var respuesta = new Dictionary<string, object>();
            try
            {
                var datos = ObtenerDatos();
                this.iAplicacion!.Configurar(Configuracion.ObtenerValor("StringConexion"));
                this.iAplicacionToken!.Configurar(Configuracion.ObtenerValor("StringConexion"));
                if (!(iAplicacionToken!.Validar(datos) && (iAplicacionToken.ValidarRol(datos["Llave"].ToString()!).Equals("Administrador"))))
                {
                    respuesta["Error"] = "lbNoAutenticacion";
                    return JsonConversor.ConvertirAString(respuesta);
                }
                var entidad = JsonConversor.ConvertirAObjeto<BeneficiosMembresias>(
                    JsonConversor.ConvertirAString(datos["Entidad"]));

                entidad = this.iAplicacion!.Guardar(entidad);
                respuesta["Entidad"] = entidad!;
                respuesta["Respuesta"] = "OK";
                respuesta["Fecha"] = DateTime.Now.ToString();
                return JsonConversor.ConvertirAString(respuesta);
            }
            catch (Exception ex)
            {
                respuesta["Error"] = ex.Message.ToString();
                respuesta["Respuesta"] = "Error";
                return JsonConversor.ConvertirAString(respuesta);
            }
        }

        [HttpPost]
        public string Modificar()
        {
            var respuesta = new Dictionary<string, object>();
            try
            {
                var datos = ObtenerDatos();
                this.iAplicacion!.Configurar(Configuracion.ObtenerValor("StringConexion"));
                this.iAplicacionToken!.Configurar(Configuracion.ObtenerValor("StringConexion"));
                if (!(iAplicacionToken!.Validar(datos) && (iAplicacionToken.ValidarRol(datos["Llave"].ToString()!).Equals("Administrador"))))
                {
                    respuesta["Error"] = "lbNoAutenticacion";
                    return JsonConversor.ConvertirAString(respuesta);
                }
                var entidad = JsonConversor.ConvertirAObjeto<BeneficiosMembresias>(
                    JsonConversor.ConvertirAString(datos["Entidad"]));

                entidad = this.iAplicacion!.Modificar(entidad);
                respuesta["Entidad"] = entidad!;
                respuesta["Respuesta"] = "OK";
                respuesta["Fecha"] = DateTime.Now.ToString();
                return JsonConversor.ConvertirAString(respuesta);
            }
            catch (Exception ex)
            {
                respuesta["Error"] = ex.Message.ToString();
                respuesta["Respuesta"] = "Error";
                return JsonConversor.ConvertirAString(respuesta);
            }
        }

        [HttpPost]
        public string Borrar()
        {
            var respuesta = new Dictionary<string, object>();
            try
            {
                var datos = ObtenerDatos();
                this.iAplicacion!.Configurar(Configuracion.ObtenerValor("StringConexion"));
                this.iAplicacionToken!.Configurar(Configuracion.ObtenerValor("StringConexion"));
                if (!(iAplicacionToken!.Validar(datos) && (iAplicacionToken.ValidarRol(datos["Llave"].ToString()!).Equals("Administrador"))))
                {
                    respuesta["Error"] = "lbNoAutenticacion";
                    return JsonConversor.ConvertirAString(respuesta);
                }
                var entidad = JsonConversor.ConvertirAObjeto<BeneficiosMembresias>(
                    JsonConversor.ConvertirAString(datos["Entidad"]));

                entidad = this.iAplicacion!.Borrar(entidad);
                respuesta["Entidad"] = entidad!;
                respuesta["Respuesta"] = "OK";
                respuesta["Fecha"] = DateTime.Now.ToString();
                return JsonConversor.ConvertirAString(respuesta);
            }
            catch (Exception ex)
            {
                respuesta["Error"] = ex.Message.ToString();
                respuesta["Respuesta"] = "Error";
                return JsonConversor.ConvertirAString(respuesta);
            }
        }
    }
}
