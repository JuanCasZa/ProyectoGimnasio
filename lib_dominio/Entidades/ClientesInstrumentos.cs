using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lib_dominio.Entidades
{
    public class ClientesInstrumentos
    {
        [Key] public int Id { get; set; }
        public int IdClientes { get; set; }
        [ForeignKey("IdClientes")] public Clientes? _IdClientes { get; set; }
        public int IdInstrumentos { get; set; }
        [ForeignKey("IdInstrumentos")] public Instrumentos? _IdInstrumentos { get; set; }

    }
}
