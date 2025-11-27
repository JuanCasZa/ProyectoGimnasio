using lib_dominio.Entidades;
using lib_dominio.Nucleo;
using lib_presentaciones.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json.Linq;
namespace asp_presentacion.Pages.Ventanas
{
    public class BeneficiosMembresiasModel : PageModel
    {
        private IBeneficiosMembresiasPresentacion? iPresentacion = null;
        private IMembresiasPresentacion? iPresentacion2 = null;

        public BeneficiosMembresiasModel(IBeneficiosMembresiasPresentacion iPresentacion, IMembresiasPresentacion? iPresentacion2)
        {
            try
            {
                this.iPresentacion = iPresentacion;
                this.iPresentacion2 = iPresentacion2;
                Filtro = new BeneficiosMembresias()
                {
                    _IdMembresias = new Membresias() //Para inicializar el constructor de Membresias
                };
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }

            this.iPresentacion2 = iPresentacion2;
        }

        public IFormFile? FormFile { get; set; }
        [BindProperty] public Enumerables.Ventanas Accion { get; set; }
        [BindProperty] public BeneficiosMembresias? Actual { get; set; }
        [BindProperty] public BeneficiosMembresias? Filtro { get; set; }
        [BindProperty] public List<BeneficiosMembresias>? Lista { get; set; }

        [BindProperty] public List<Membresias>? Lista2 { get; set; }
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
                Filtro ??= new BeneficiosMembresias();
                Filtro._IdMembresias ??= new Membresias();


                Filtro!.Beneficios = Filtro!.Beneficios ?? "";
                Filtro!._IdMembresias!.TipoMembresia = Filtro!._IdMembresias!.TipoMembresia ?? "";
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
                var token = HttpContext.Session.GetString("Token"); //IMPLEMENTANDO COSAS

                Accion = Enumerables.Ventanas.Editar;
                Actual = new BeneficiosMembresias();

                var task2 = this.iPresentacion2!.Listar(token!);
                task2.Wait();
                Lista2 = task2.Result;
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
                Task<BeneficiosMembresias>? task = null;
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
