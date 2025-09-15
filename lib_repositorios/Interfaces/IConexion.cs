using lib_dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace lib_repositorios.Interfaces
{
    public interface IConexion
    {
        string? StringConexion { get; set; }
        //DbSet<Personas>? Personas { get; set; }
        DbSet<Instalaciones>? Instalaciones { get; set; }
        DbSet<Clientes>? Clientes { get; set; }
        DbSet<Empleados>? Empleados { get; set; }
        DbSet<Proveedores>? Proveedores { get; set; }
        DbSet<Instrumentos>? Instrumentos { get; set; }
        DbSet<Membresias>? Membresias { get; set; }
        DbSet<Suplementos>? Suplementos { get; set; }
        DbSet<ClasesGrupales>? ClasesGrupales { get; set; }
        DbSet<InstalacionesClientes>? InstalacionesClientes { get; set; }
        DbSet<InstalacionesEmpleados>? InstalacionesEmpleados { get; set; }
        DbSet<ClientesMembresias>? ClientesMembresias { get; set; }
        DbSet<ClientesSuplementos>? ClientesSuplementos { get; set; }
        DbSet<ClientesClasesGrupales>? ClientesClasesGrupales { get; set; }
        DbSet<ClientesInstrumentos>? ClientesInstrumentos { get; set; }
        DbSet<BeneficiosMembresias>? BeneficiosMembresias { get; set; }
        EntityEntry<T> Entry<T>(T entity) where T : class;
        int SaveChanges();

    }
}
