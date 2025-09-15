using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace lib_repositorios.Implementaciones
{
    public partial class Conexion : DbContext, IConexion
    {
        public string? StringConexion { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(this.StringConexion!, p => { });
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }

        //public DbSet<Personas>? Personas { get; set; }

        public DbSet<Instalaciones>? Instalaciones { get; set; }
        public DbSet<Clientes>? Clientes { get; set; }
        public DbSet<Empleados>? Empleados { get; set; }
        public DbSet<Proveedores>? Proveedores { get; set; }
        public DbSet<Instrumentos>? Instrumentos { get; set; }
        public DbSet<Membresias>? Membresias { get; set; }
        public DbSet<Suplementos>? Suplementos { get; set; }
        public DbSet<ClasesGrupales>? ClasesGrupales { get; set; }
        public DbSet<InstalacionesClientes>? InstalacionesClientes { get; set; }
        public DbSet<InstalacionesEmpleados>? InstalacionesEmpleados { get; set; }
        public DbSet<ClientesMembresias>? ClientesMembresias { get; set; }
        public DbSet<ClientesSuplementos>? ClientesSuplementos { get; set; }
        public DbSet<ClientesClasesGrupales>? ClientesClasesGrupales { get; set; }
        public DbSet<ClientesInstrumentos>? ClientesInstrumentos { get; set; }
        public DbSet<BeneficiosMembresias>? BeneficiosMembresias { get; set; }
    }
}
