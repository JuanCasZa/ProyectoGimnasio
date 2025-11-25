using lib_dominio.Entidades;
using lib_dominio.Nucleo;
using lib_presentaciones.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json.Linq;
namespace asp_presentacion.Pages.Ventanas
{
    public class UsuariosModel : PageModel
    {
        //IMPORTANTE: MIRAR COMO HACER PARA QUE LOS BOTONES DE MODIFICAR, BORRAR Y EL LINK FUNCIONEN CORRECTAMENTE

        private IUsuariosPresentacion? iPresentacion = null;

        public UsuariosModel(IUsuariosPresentacion iPresentacion)
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

        //Se agrego para hacer el desplegable
        public List<(int Id, string Nombre)> Roles { get; set; } = new()
        {
            (1, "Administrador"),
            (2, "Entrenador"),
            (3, "Recepcionista"),
            (4, "Ventas")
        };
        //

        public IFormFile? FormFile { get; set; }
        [BindProperty] public Enumerables.Ventanas Accion { get; set; }
        [BindProperty] public Usuarios? Actual { get; set; }
        [BindProperty] public List<Usuarios>? Lista { get; set; }
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

<<<<<<< HEAD:asp_presentaciones/Pages/Ventanas/Clientes.cshtml.cs
                Filtro!.Edad = Filtro!.Edad;
                Accion = Enumerables.Ventanas.Listas;
                var task = this.iPresentacion!.PorEdad(Filtro!);
=======

                Accion = Enumerables.Ventanas.Listas;
                var task = this.iPresentacion!.Listar(token!);
>>>>>>> 4513b1bb842d2298da43cd4afc1208b322bd6b1d:asp_presentaciones/Pages/Ventanas/Usuarios.cshtml.cs
                task.Wait();
                Lista = task.Result;
                Actual = null;
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public virtual void OnPostBtNuevo()
        {
            try
            {
                Accion = Enumerables.Ventanas.Editar;
                Actual = new Usuarios();
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
                Task<Usuarios>? task = null;
                if (Actual!.Id == 0)
                    task = this.iPresentacion!.Guardar(Actual!)!;
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


        public void OnPostBtCerrar()
        {
            try
            {
                HttpContext.Response.Redirect("/"); //
                //if (Accion == Enumerables.Ventanas.Listas)
                //OnPostBtRefrescar();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }
    }
}
