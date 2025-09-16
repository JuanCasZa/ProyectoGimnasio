using lib_dominio.Entidades;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lib_dominio.Entidades
{
    public class ClientesMembresias
    {
        [Key] public int Id { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public int IdClientes { get; set; }
        [ForeignKey("IdClientes")] public Clientes? _IdClientes { get; set; }
        public int IdMembresias { get; set; }

        [ForeignKey("IdMembresias")] public Membresias? _IdMembresias { get; set; }
    }
}
