using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_dominio.Entidades
{
    public class BeneficiosMembresias
    {
        [Key] public int Id { get; set; }
        public string? Beneficios { get; set; }
        public int IdMembresias { get; set; }
        [ForeignKey("IdMembresias")] public Membresias? _IdMembresias { get; set; }

    }
}
