using System.ComponentModel.DataAnnotations.Schema;

namespace lib_dominio.Entidades
{
    public class BeneficiosMembresias
    {
        public int Id { get; set; }
        public string Beneficios { get; set; }
        public int IdMembresias { get; set; }
        [ForeignKey("IdMembresias")] public Membresias? _IdMembresias { get; set; }

    }
}
