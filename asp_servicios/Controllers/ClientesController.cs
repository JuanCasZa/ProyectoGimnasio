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
    public class ClientesController : ControllerBase
    {
        private IClientesAplicacion? iAplicacion = null;
        private TokenAplicacion? iAplicacionToken = null;
        private AuditoriasAplicacion? iAplicacionAuditoria = null;

        public ClientesController(IClientesAplicacion? iAplicacion, TokenAplicacion iAplicacionToken, AuditoriasAplicacion? iAplicacionAuditoria)
        {
            this.iAplicacion = iAplicacion;
            this.iAplicacionToken = iAplicacionToken;
            this.iAplicacionAuditoria = iAplicacionAuditoria;
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
                    || iAplicacionToken.ValidarRol(datos["Llave"].ToString()!).Equals("Recepcionista"))))
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
                    || iAplicacionToken.ValidarRol(datos["Llave"].ToString()!).Equals("Recepcionista"))))
                {
                    respuesta["Error"] = "lbNoAutenticacion";
                    return JsonConversor.ConvertirAString(respuesta);
                }
                var entidad = JsonConversor.ConvertirAObjeto<Clientes>(
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
                iAplicacionAuditoria!.AgregarAuditoria(iAplicacionToken!.GetAuditoria(), iAplicacionToken!.GetUsuario(datos["Llave"].ToString()!), 2);
                this.iAplicacion!.Configurar(Configuracion.ObtenerValor("StringConexion"));
                this.iAplicacionToken!.Configurar(Configuracion.ObtenerValor("StringConexion"));
                if (!(iAplicacionToken!.Validar(datos) && (iAplicacionToken.ValidarRol(datos["Llave"].ToString()!).Equals("Administrador")
                    || iAplicacionToken.ValidarRol(datos["Llave"].ToString()!).Equals("Recepcionista"))))
                {
                    respuesta["Error"] = "lbNoAutenticacion";
                    return JsonConversor.ConvertirAString(respuesta);
                }
                var entidad = JsonConversor.ConvertirAObjeto<Clientes>(
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
                    || iAplicacionToken.ValidarRol(datos["Llave"].ToString()!).Equals("Recepcionista"))))
                {
                    respuesta["Error"] = "lbNoAutenticacion";
                    return JsonConversor.ConvertirAString(respuesta);
                }
                var entidad = JsonConversor.ConvertirAObjeto<Clientes>(
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
