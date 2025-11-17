using lib_dominio.Nucleo;
using lib_presentaciones.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Routing;

namespace asp_presentaciones.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IUsuariosPresentacion? iPresentacion;    

        public IndexModel(IUsuariosPresentacion presentacion)
        {
            iPresentacion = presentacion;
        }

        public bool EstaLogueado = false;
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

        public void OnPostBtEnter()
        {
            try
            {
                if (string.IsNullOrEmpty(Email) &&
                    string.IsNullOrEmpty(Contrasenha))
                {
                    OnPostBtClean();
                    return;
                }

                
                //Usuario quemado, hay que cambiarlo para traer a los usuarios acá
                if ("admin.123" != Email + "." + Contrasenha)
                {
                    OnPostBtClean();
                    return;
                }
                

                /*
                var lista = await this.iPresentacion!.Listar();

                var usuario = lista.FirstOrDefault(x => x.Nombre == Email && x.Contrasenha == Contrasenha);

                if (usuario == null)
                {
                    OnPostBtClean();
                    return;
                }
                */

                ViewData["Logged"] = true;
                HttpContext.Session.SetString("Usuario", Email!);
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
    }
}
