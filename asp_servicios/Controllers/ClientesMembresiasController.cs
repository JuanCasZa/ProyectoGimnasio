using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace asp_servicios.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ClientesMembresiasController : ControllerBase
    {
        private readonly IClientesMembresiasAplicacion _servicio;

        public ClientesMembresiasController(IClientesMembresiasAplicacion servicio)
        {
            _servicio = servicio;
            _servicio.Configurar(Configuracion.ObtenerValor("StringConexion"));
        }

        [HttpGet("listar")]
        public ActionResult<List<ClientesMembresias>> Listar()
        {
            return Ok(_servicio.Listar());
        }

        [HttpPost("guardar")]
        public ActionResult<ClientesMembresias> Guardar([FromBody] ClientesMembresias entidad)
        {
            return Ok(_servicio.Guardar(entidad));
        }
    }
}

