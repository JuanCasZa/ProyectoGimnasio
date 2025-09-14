using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_dominio.Entidades
{
    public class ClasesGrupales
    {
        [Key] public int Id { get; set; }
        public decimal Duracion { get; set; }
        public string TipoClase { get; set; }
        public int CapacidadMax { get; set; }
        public string Nivel { get; set; }
    }
}
