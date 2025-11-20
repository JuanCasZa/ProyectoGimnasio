using lib_dominio.Nucleo;
using lib_presentaciones.Implementaciones;
using lib_presentaciones.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Routing;
using System.Numerics;
using System.Threading.Tasks;

namespace asp_presentaciones.Pages
{
    public class IndexModel : PageModel
    {

        // IMPLEMENTANDO COSAS
        private readonly IUsuariosPresentacion? iPresentacion;    

        public IndexModel(IUsuariosPresentacion presentacion)
        {
            iPresentacion = presentacion;
        }
        //

        public bool EstaLogueado = false;

        [BindProperty] public Enumerables.Ventanas Accion { get; set; }
        [BindProperty] public string? Email { get; set; }
        [BindProperty] public string? Contrasenha { get; set; }

        public void OnGet()
        {
            var variable_session = HttpContext.Session.GetString("Usuario");
            if (!String.IsNullOrEmpty(variable_session))
            {
                EstaLogueado = true;
                return;
            }
        }

        public void OnPostBtClean()
        {
            try
            {
                Email = string.Empty;
                Contrasenha = string.Empty;
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public async Task OnPostBtEnter()
        {
            try
            {
                if (string.IsNullOrEmpty(Email) &&
                    string.IsNullOrEmpty(Contrasenha))
                {
                    OnPostBtClean();
                    return;
                }
                // IMPLEMENTANDO COSAS
                var Token = HttpContext.Session.GetString("Token"); //Implementando cosas

                var token = await iPresentacion!.Autenticar(Email!, Contrasenha!, Token!);

                if (token == null)
                {
                    ViewData["Mensaje"] = "Usuario o contraseña incorrecta";
                    OnPostBtClean();
                    return;
                }

                //

                //Usuario quemado, hay que cambiarlo para traer a los usuarios acá
                /*
                if ("admin.123" != Email + "." + Contrasenha)
                {
                    OnPostBtClean();
                    return;
                }*/

                ViewData["Logged"] = true;
                HttpContext.Session.SetString("Usuario", Email!);
                HttpContext.Session.SetString("Token", token); //IMPLEMENTANDO COSAS
                var rol = await iPresentacion.ObtenerRol(token); //IMPLEMENTANDO COSAS
                HttpContext.Session.SetString("Rol", rol ?? ""); //IMPLEMENTANDO COSAS
                EstaLogueado = true;
                OnPostBtClean();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public void OnPostBtClose()
        {
            try
            {
                HttpContext.Session.Clear();
                HttpContext.Response.Redirect("/");
                EstaLogueado = false;
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        //Para cerrar el cuadro emergente
        public void OnPostBtCerrar()
        {
            try
            {
                if (Accion == Enumerables.Ventanas.Listas)
                {
                    OnPostBtClean();
                    HttpContext.Response.Redirect("/");
                }
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }
    }
}
