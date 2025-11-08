using asp_servicios.Nucleo;
using lib_repositorios.Interfaces;
using lib_dominio.Entidades;
using lib_dominio.Nucleo;
using Microsoft.AspNetCore.Mvc;
using lib_repositorios.Implementaciones;
using System.Runtime.CompilerServices;

namespace asp_servicios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class SuplementosController : ControllerBase
    {
        private ISuplementosAplicacion? iAplicacion = null;
        private TokenAplicacion? iAplicacionToken = null;
        private AuditoriasAplicacion? iAplicacionAuditoria = null;

        public SuplementosController(ISuplementosAplicacion? iAplicacion, TokenAplicacion iAplicacionToken, AuditoriasAplicacion iAuditoriasAplicacion)
        {
            this.iAplicacion = iAplicacion;
            this.iAplicacionToken = iAplicacionToken;
            this.iAplicacionAuditoria = iAuditoriasAplicacion;
        }

        private Dictionary<string, object> ObtenerDatos()
        {
            var datos = new StreamReader(Request.Body).ReadToEnd().ToString();
            if (string.IsNullOrEmpty(datos))
                datos = "{}";
            var respuesta = JsonConversor.ConvertirAObjeto(datos);
            ConfigurarAuditoria();
            return respuesta;
        }

        public void ConfigurarAuditoria()
        {
            this.iAplicacionAuditoria!.Configurar(Configuracion.ObtenerValor("StringConexion"));
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
                    || iAplicacionToken.ValidarRol(datos["Llave"].ToString()!).Equals("Ventas"))))
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
        public string PorTipoSuplemento()
        {
            var respuesta = new Dictionary<string, object>();
            try
            {
                var datos = ObtenerDatos();
                this.iAplicacion!.Configurar(Configuracion.ObtenerValor("StringConexion"));
                this.iAplicacionToken!.Configurar(Configuracion.ObtenerValor("StringConexion"));
                if (!(iAplicacionToken!.Validar(datos) && (iAplicacionToken.ValidarRol(datos["Llave"].ToString()!).Equals("Administrador")
                    || iAplicacionToken.ValidarRol(datos["Llave"].ToString()!).Equals("Ventas"))))
                {
                    respuesta["Error"] = "lbNoAutenticacion";
                    return JsonConversor.ConvertirAString(respuesta);
                }
                var entidad = JsonConversor.ConvertirAObjeto<Suplementos>(
                JsonConversor.ConvertirAString(datos["Entidad"]));

                respuesta["Entidades"] = this.iAplicacion!.PorTipoSuplemento(entidad);
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
        public string PorProveedor()
        {
            var respuesta = new Dictionary<string, object>();
            try
            {
                var datos = ObtenerDatos();
                this.iAplicacion!.Configurar(Configuracion.ObtenerValor("StringConexion"));
                this.iAplicacionToken!.Configurar(Configuracion.ObtenerValor("StringConexion"));
                if (!(iAplicacionToken!.Validar(datos) && (iAplicacionToken.ValidarRol(datos["Llave"].ToString()!).Equals("Administrador")
                    || iAplicacionToken.ValidarRol(datos["Llave"].ToString()!).Equals("Ventas"))))
                {
                    respuesta["Error"] = "lbNoAutenticacion";
                    return JsonConversor.ConvertirAString(respuesta);
                }
                var entidad = JsonConversor.ConvertirAObjeto<Suplementos>(
                JsonConversor.ConvertirAString(datos["Entidad"]));

                respuesta["Entidades"] = this.iAplicacion!.PorProveedor(entidad);
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
                iAplicacionAuditoria!.AgregarAuditoria(iAplicacionToken!.GetAuditoria(), iAplicacionToken!.GetUsuario(datos["Llave"].ToString()!), 1);
                this.iAplicacion!.Configurar(Configuracion.ObtenerValor("StringConexion"));
                this.iAplicacionToken!.Configurar(Configuracion.ObtenerValor("StringConexion"));
                if (!(iAplicacionToken!.Validar(datos) && (iAplicacionToken.ValidarRol(datos["Llave"].ToString()!).Equals("Administrador")
                    || iAplicacionToken.ValidarRol(datos["Llave"].ToString()!).Equals("Ventas"))))
                {
                    respuesta["Error"] = "lbNoAutenticacion";
                    return JsonConversor.ConvertirAString(respuesta);
                }
                var entidad = JsonConversor.ConvertirAObjeto<Suplementos>(JsonConversor.ConvertirAString(datos["Entidad"]));

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
                iAplicacionAuditoria!.AgregarAuditoria(iAplicacionToken!.GetAuditoria(), iAplicacionToken!.GetUsuario(datos["Llave"].ToString()!), 2);
                this.iAplicacion!.Configurar(Configuracion.ObtenerValor("StringConexion"));
                this.iAplicacionToken!.Configurar(Configuracion.ObtenerValor("StringConexion"));
                if (!(iAplicacionToken!.Validar(datos) && (iAplicacionToken.ValidarRol(datos["Llave"].ToString()!).Equals("Administrador")
                    || iAplicacionToken.ValidarRol(datos["Llave"].ToString()!).Equals("Ventas"))))
                {
                    respuesta["Error"] = "lbNoAutenticacion";
                    return JsonConversor.ConvertirAString(respuesta);
                }
                var entidad = JsonConversor.ConvertirAObjeto<Suplementos>(
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
                iAplicacionAuditoria!.AgregarAuditoria(iAplicacionToken!.GetAuditoria(), iAplicacionToken!.GetUsuario(datos["Llave"].ToString()!), 3);
                this.iAplicacion!.Configurar(Configuracion.ObtenerValor("StringConexion"));
                this.iAplicacionToken!.Configurar(Configuracion.ObtenerValor("StringConexion"));
                if (!(iAplicacionToken!.Validar(datos) && (iAplicacionToken.ValidarRol(datos["Llave"].ToString()!).Equals("Administrador")
                    || iAplicacionToken.ValidarRol(datos["Llave"].ToString()!).Equals("Ventas"))))
                {
                    respuesta["Error"] = "lbNoAutenticacion";
                    return JsonConversor.ConvertirAString(respuesta);
                }
                var entidad = JsonConversor.ConvertirAObjeto<Suplementos>(
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
