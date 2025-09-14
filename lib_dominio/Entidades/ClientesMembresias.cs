using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_dominio.Entidades
{
    public class ClientesMembresias
    {
        [Key] public int Id { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public int IdCliente { get; set; }
        [ForeignKey("IdCliente")] public Clientes? _IdCliente { get; set; }
        public int IdMembresia { get; set; }
        [ForeignKey("IdMembresia")] public Membresias? _IdMembresia { get; set; }
    }
}
