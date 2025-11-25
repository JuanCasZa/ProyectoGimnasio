using lib_dominio.Entidades;
using lib_dominio.Nucleo;
using lib_presentaciones.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
<<<<<<< HEAD
=======
using Newtonsoft.Json.Linq;
>>>>>>> 4513b1bb842d2298da43cd4afc1208b322bd6b1d
namespace asp_presentacion.Pages.Ventanas
{
    public class EmpleadosModel : PageModel
    {
        private IEmpleadosPresentacion? iPresentacion = null;

        public EmpleadosModel(IEmpleadosPresentacion iPresentacion)
        {
            try
            {
                this.iPresentacion = iPresentacion;
<<<<<<< HEAD
                Filtro = new Empleados();
=======
>>>>>>> 4513b1bb842d2298da43cd4afc1208b322bd6b1d
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public IFormFile? FormFile { get; set; }
        [BindProperty] public Enumerables.Ventanas Accion { get; set; }
        [BindProperty] public Empleados? Actual { get; set; }
        [BindProperty] public Empleados? Filtro { get; set; }
        [BindProperty] public List<Empleados>? Lista { get; set; }
        public virtual void OnGet() { OnPostBtRefrescar(); }

        public void OnPostBtRefrescar()
        {
            try
            {
<<<<<<< HEAD
=======
                var token = HttpContext.Session.GetString("Token"); //IMPLEMENTANDO COSAS
>>>>>>> 4513b1bb842d2298da43cd4afc1208b322bd6b1d
                var variable_session = HttpContext.Session.GetString("Usuario");
                if (String.IsNullOrEmpty(variable_session))
                {
                    HttpContext.Response.Redirect("/");
                    return;
                }
<<<<<<< HEAD

                Filtro!.Nombre = Filtro!.Nombre ?? "";
                Accion = Enumerables.Ventanas.Listas;
                var task = this.iPresentacion!.Listar();
=======
                Filtro ??= new Empleados();

                Filtro!.Especialidad = Filtro!.Especialidad ?? "";
                Filtro!.Identificacion = Filtro!.Identificacion ?? "";
                Filtro!.Telefono = Filtro!.Telefono ?? "";
                Filtro!.Cargo = Filtro!.Cargo ?? "";
                Accion = Enumerables.Ventanas.Listas;
                var task = this.iPresentacion!.Filtro(Filtro!, token!);
>>>>>>> 4513b1bb842d2298da43cd4afc1208b322bd6b1d
                task.Wait();
                Lista = task.Result;
                Actual = null;
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
<<<<<<< HEAD
=======
                ViewData["TipoError"] = "Acceso";
>>>>>>> 4513b1bb842d2298da43cd4afc1208b322bd6b1d
            }
        }

        public virtual void OnPostBtNuevo()
        {
            try
            {
                Accion = Enumerables.Ventanas.Editar;
                Actual = new Empleados();
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
<<<<<<< HEAD
                Accion = Enumerables.Ventanas.Editar;
                Task<Empleados>? task = null;
                if (Actual!.Id == 0)
                    task = this.iPresentacion!.Guardar(Actual!)!;
                else
                    task = this.iPresentacion!.Modificar(Actual!)!;
=======
                var token = HttpContext.Session.GetString("Token"); //Implementando cosas
                Accion = Enumerables.Ventanas.Editar;
                Task<Empleados>? task = null;
                if (Actual!.Id == 0)
                    task = this.iPresentacion!.Guardar(Actual!, token! /*Implementando cosas*/)!;
                else
                    task = this.iPresentacion!.Modificar(Actual!, token! /*Implementando cosas*/)!;
>>>>>>> 4513b1bb842d2298da43cd4afc1208b322bd6b1d
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
<<<<<<< HEAD
                var task = this.iPresentacion!.Borrar(Actual!);
=======
                var token = HttpContext.Session.GetString("Token"); //Implementando cosas
                var task = this.iPresentacion!.Borrar(Actual!, token!/*Implementando cosas*/);
>>>>>>> 4513b1bb842d2298da43cd4afc1208b322bd6b1d
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

<<<<<<< HEAD
=======
        //Este BtCerrar cierra el cuadro emergente en caso de ocurrir un error de acceso
>>>>>>> 4513b1bb842d2298da43cd4afc1208b322bd6b1d
        public void OnPostBtCerrar()
        {
            try
            {
<<<<<<< HEAD
=======
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
>>>>>>> 4513b1bb842d2298da43cd4afc1208b322bd6b1d
                if (Accion == Enumerables.Ventanas.Listas)
                    OnPostBtRefrescar();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }
<<<<<<< HEAD
=======

>>>>>>> 4513b1bb842d2298da43cd4afc1208b322bd6b1d
    }
}
