using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface IBeneficiosMembresiasPresentacion
    {
        Task<List<BeneficiosMembresias>> Listar();
        Task<BeneficiosMembresias?> Guardar(BeneficiosMembresias? entidad);
        Task<BeneficiosMembresias?> Modificar(BeneficiosMembresias? entidad);
        Task<BeneficiosMembresias?> Borrar(BeneficiosMembresias? entidad);
    }
}
