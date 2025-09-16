using lib_dominio.Entidades;

namespace ut_presentacion.Nucleo
{
    public class EntidadesNucleo
    {
        /*Todas las claves foraneas estan en 1, por razones de pruebas*/
        public static Instalaciones? Instalaciones()
        {
            var entidad = new Instalaciones();
            entidad.Direccion = "Calle 70 #59-193";
            entidad.Telefono = "3104207950";

            return entidad;
        }

        public static Clientes? Clientes() 
        {
            var entidad = new Clientes();
            entidad.Nombre = "ClientePrueba";
            entidad.Identificacion = "IdPrueba";
            entidad.Edad = 24;
            entidad.CorreoElectronico = "prueba@hotmail.com";
            entidad.Telefono = "3006807950";
            entidad.Estatura = 1.82m;
            entidad.Peso = 78.5m;

            return entidad;
        }

        public static Empleados? Empleados()
        {
            var entidad = new Empleados();
            entidad.Nombre = "EmpleadoPrueba";
            entidad.Identificacion = "EMP123";
            entidad.Telefono = "3001234567";
            entidad.AnhosExperiencia = 3;
            entidad.Salario = 2500000m;
            entidad.Estado = true;
            entidad.Especialidad = "Entrenamiento Personalizado";
            entidad.Cargo = "Instructor";
            entidad.HorarioDisponible = "Lunes a Viernes 8am-6pm";
            entidad.FechaContratacion = DateTime.Now;

            return entidad;
        }

        public static Proveedores? Proveedores()
        {
            var entidad = new Proveedores();
            entidad.NombreEntidad = "ProveedorPrueba S.A.S.";
            entidad.ValorTotalVenta = 15000000m;
            entidad.Direccion = "Calle 123 #45-67";
            entidad.Telefono = "6012345678";

            return entidad;
        }

        public static Instrumentos? Instrumentos()
        {
            var entidad = new Instrumentos();
            entidad.NombreInstrumento = "Mancuerna";
            entidad.CantidadEquip = 20;
            entidad.Piezas = 1;
            entidad.Marca = "PowerFit";
            entidad.DescripcionGeneral = "Mancuerna de 10kg";
            entidad.Estado = true;
            entidad.Proveedor = 1; // ID de proveedor por defecto
            var entidadP = new Proveedores();
            entidadP.NombreEntidad = "ProveedorPrueba SOAS";
            entidadP.ValorTotalVenta = 105000m;
            entidadP.Direccion = "Calle 39";
            entidadP.Telefono = "12333434";
            entidad._Proveedor = entidadP;

            return entidad;
        }

        public static Membresias? Membresias()
        {
            var entidad = new Membresias();
            entidad.Valor = 120000m;
            entidad.TipoMembresia = "Premium";

            return entidad;
        }

        public static Suplementos? Suplementos()
        {
            var entidad = new Suplementos();
            entidad.NombreSuplemento = "Proteína Whey";
            entidad.TipoSuplemento = "Proteína";
            entidad.Valor = 80000m;
            entidad.Cantidad = 50;
            entidad.Proveedor = 1;
            var entidadP = new Proveedores();
            entidadP.NombreEntidad = "ProveedorPrueba SASO";
            entidadP.ValorTotalVenta = 9000000m;
            entidadP.Direccion = "Calle 45";
            entidadP.Telefono = "12354689";
            entidad._Proveedor = entidadP;

            return entidad;
        }

        public static ClasesGrupales? ClasesGrupales()
        {
            var entidad = new ClasesGrupales();
            entidad.Duracion = 1.5m;
            entidad.TipoClase = "Yoga";
            entidad.CapacidadMax = 15;
            entidad.Nivel = "Intermedio";

            return entidad;
        }

        public static InstalacionesClientes? InstalacionesClientes()
        {
            var entidad = new InstalacionesClientes();
            entidad.IdInstalaciones = 1; 
            entidad.IdClientes = 1; 
            entidad.RegistroIngresoClientes = 5;

            return entidad;
        }

        public static InstalacionesEmpleados? InstalacionesEmpleados()
        {
            var entidad = new InstalacionesEmpleados();
            entidad.IdInstalaciones = 1; 
            entidad.IdEmpleados = 1; 

            return entidad;
        }

        public static ClientesMembresias? ClientesMembresias()
        {
            var entidad = new ClientesMembresias();
            entidad.IdClientes = 1; 
            entidad.IdMembresias = 1; 
            entidad.FechaInicio = DateTime.Now;
            entidad.FechaFin = DateTime.Now.AddMonths(1);

            return entidad;
        }

        public static ClientesSuplementos? ClientesSuplementos()
        {
            var entidad = new ClientesSuplementos();
            entidad.IdClientes = 1; 
            entidad.IdSuplementos = 1; 
            entidad.CantidadCompraSuplementos = 2;
            entidad.ValorTotalCompra = 160000m;

            return entidad;
        }

        public static ClientesClasesGrupales? ClientesClasesGrupales()
        {
            var entidad = new ClientesClasesGrupales();
            entidad.IdClientes = 1; 
            entidad.IdClasesGrupales = 1; 
            entidad.Asistencias = 8;

            return entidad;
        }

        public static ClientesInstrumentos? ClientesInstrumentos()
        {
            var entidad = new ClientesInstrumentos();
            entidad.IdClientes = 1; 
            entidad.IdInstrumentos = 1; 
            var entidadC= new Clientes();
            entidadC.Nombre = "ClientePrueba CliIns";
            entidadC.Identificacion = "IdPrueba CliIns";
            entidadC.Edad = 25;
            entidadC.CorreoElectronico = "pruebaCliIns@gmail.com";
            entidadC.Telefono = "3334454545";
            entidadC.Estatura = 1.83m;
            entidadC.Peso = 78.5m;
            entidad._IdClientes = 1;
            entidad._IdInstrumentos = 1;

            return entidad;
        }

        public static BeneficiosMembresias? BeneficiosMembresias()
        {
            var entidad = new BeneficiosMembresias();
            entidad.Beneficios = "Acceso ilimitado";
            entidad.IdMembresias = 1;
            var entidadM = new Membresias();
            entidadM.Valor = 100000m;
            entidadM.TipoMembresia = "Completa";
            entidad._IdMembresias = entidadM;

            return entidad;
        }
    }
}
