using lib_dominio.Entidades;
using lib_dominio.Nucleo;
using lib_presentaciones.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json.Linq;
namespace asp_presentacion.Pages.Ventanas
{
    public class ClasesGrupalesModel : PageModel
    {
        private IClasesGrupalesPresentacion? iPresentacion = null;

        public ClasesGrupalesModel(IClasesGrupalesPresentacion iPresentacion)
        {
            try
            {
                this.iPresentacion = iPresentacion;

            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public IFormFile? FormFile { get; set; }
        [BindProperty] public Enumerables.Ventanas Accion { get; set; }
        [BindProperty] public ClasesGrupales? Actual { get; set; }
        [BindProperty] public ClasesGrupales? Filtro { get; set; }
        [BindProperty] public List<ClasesGrupales>? Lista { get; set; }
        public virtual void OnGet() { OnPostBtRefrescar(); }

        public void OnPostBtRefrescar()
        {
            try
            {
                var token = HttpContext.Session.GetString("Token"); //IMPLEMENTANDO COSAS
                var variable_session = HttpContext.Session.GetString("Usuario");
                if (String.IsNullOrEmpty(variable_session))
                {
                    HttpContext.Response.Redirect("/");
                    return;
                }
                Filtro ??= new ClasesGrupales();


                Filtro!.Duracion = Filtro!.Duracion;
                Filtro!.TipoClase = Filtro!.TipoClase ?? "";
                Filtro!.CapacidadMax = Filtro!. CapacidadMax;
                Filtro!.Nivel = Filtro!.Nivel ?? "";
                Accion = Enumerables.Ventanas.Listas;
                var task = this.iPresentacion!.Filtro(Filtro!, token!);
                task.Wait();
                Lista = task.Result;
                Actual = null;
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
                ViewData["TipoError"] = "Acceso";
            }
        }

        public virtual void OnPostBtNuevo()
        {
            try
            {
                Accion = Enumerables.Ventanas.Editar;
                Actual = new ClasesGrupales();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public virtual void OnPostBtModificar(string data)
        {
            try
            {
                OnPostBtRefrescar();
                Accion = Enumerables.Ventanas.Editar;
                Actual = Lista!.FirstOrDefault(x => x.Id.ToString() == data);
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public virtual void OnPostBtGuardar()
        {
            try
            {
                var token = HttpContext.Session.GetString("Token"); //Implementando cosas
                Accion = Enumerables.Ventanas.Editar;
                Task<ClasesGrupales>? task = null;
                if (Actual!.Id == 0)
                    task = this.iPresentacion!.Guardar(Actual!, token! /*Implementando cosas*/)!;
                else
                    task = this.iPresentacion!.Modificar(Actual!, token! /*Implementando cosas*/)!;
                task.Wait();
                Actual = task.Result;
                Accion = Enumerables.Ventanas.Listas;
                OnPostBtRefrescar();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public virtual void OnPostBtBorrarVal(string data)
        {
            try
            {
                OnPostBtRefrescar();
                Accion = Enumerables.Ventanas.Borrar;
                Actual = Lista!.FirstOrDefault(x => x.Id.ToString() == data);
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public virtual void OnPostBtBorrar()
        {
            try
            {
                var token = HttpContext.Session.GetString("Token"); //Implementando cosas
                var task = this.iPresentacion!.Borrar(Actual!, token!/*Implementando cosas*/);
                Actual = task.Result;
                OnPostBtRefrescar();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public void OnPostBtCancelar()
        {
            try
            {
                Accion = Enumerables.Ventanas.Listas;
                OnPostBtRefrescar();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        //Este BtCerrar cierra el cuadro emergente en caso de ocurrir un error de acceso
        public void OnPostBtCerrar()
        {
            try
            {
                HttpContext.Response.Redirect("/");
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        //Este BtCerrar cierra el cuadro emergente en caso de ocurrir algun error de datos invalidos
        public void OnPostBtCerrar2()
        {
            try
            {
                if (Accion == Enumerables.Ventanas.Listas)
                    OnPostBtRefrescar();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

    }
}
