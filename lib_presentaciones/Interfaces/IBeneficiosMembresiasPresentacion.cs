using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface IBeneficiosMembresiasPresentacion
    {
        Task<List<BeneficiosMembresias>> Listar(string Token /*Implementando cosas*/);

        Task<List<BeneficiosMembresias>> Filtro(BeneficiosMembresias? entidad, /*IMPLEMENTANDO COSAS*/ string Token);
        Task<BeneficiosMembresias?> Guardar(BeneficiosMembresias? entidad, /*IMPLEMENTANDO COSAS*/ string Token);
        Task<BeneficiosMembresias?> Modificar(BeneficiosMembresias? entidad, /*IMPLEMENTANDO COSAS*/ string Token);
        Task<BeneficiosMembresias?> Borrar(BeneficiosMembresias? entidad, /*IMPLEMENTANDO COSAS*/ string Token);
    }
}
