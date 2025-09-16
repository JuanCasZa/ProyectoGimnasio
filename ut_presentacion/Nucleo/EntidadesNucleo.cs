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
            return new InstalacionesClientes
            {
                IdClientes = 1,
                _IdClientes = new Clientes { Id = 1 }, 

                IdInstalaciones = 1,
                _IdInstalaciones = new Instalaciones { Id = 1 } 
            };
        }

        public static InstalacionesEmpleados? InstalacionesEmpleados()
        {
            return new InstalacionesEmpleados
            {
                IdEmpleados = 1,
                _IdEmpleados = new Empleados { Id = 1 },

                IdInstalaciones = 1,
                _IdInstalaciones = new Instalaciones { Id = 1 }
            };
        }



        public static ClientesMembresias? ClientesMembresias()
            {
                return new ClientesMembresias
                {
                    IdClientes = 1,
                    _IdClientes = new Clientes { Id = 1 },   // relación FK
                    IdMembresias = 1,
                    _IdMembresias = new Membresias { Id = 1 } // relación FK
                };
            }



        public static ClientesSuplementos? ClientesSuplementos()
        {
            return new ClientesSuplementos
            {
                IdClientes = 1,
                _IdClientes = new Clientes { Id = 1 },

                IdSuplementos = 1,
                _IdSuplementos = new Suplementos { Id = 1 }
            };
        }

        public static ClientesClasesGrupales? ClientesClasesGrupales()
        {
            return new ClientesClasesGrupales
            {
                IdClientes = 1,
                _IdClientes = new Clientes { Id = 1 },

                IdClasesGrupales = 1,
                _IdClasesGrupales = new ClasesGrupales { Id = 1 }
            };
        }

        public static ClientesInstrumentos? ClientesInstrumentos()
        {
            var entidad = new ClientesInstrumentos();
            entidad.IdClientes = 1; 
            entidad.IdInstrumentos = 1; 

            return entidad;
        }

        public static BeneficiosMembresias? BeneficiosMembresias()
        {
            var entidad = new BeneficiosMembresias();
            entidad.Beneficios = "Acceso ilimitado";
            entidad.IdMembresias = 1;

            return entidad;
        }
    }
}
