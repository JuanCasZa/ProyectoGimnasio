using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_dominio.Entidades
{
    public class ClientesInstrumentos
    {
        [Key] public int Id { get; set; }
        public int IdCliente { get; set; }
        [ForeignKey("IdCliente")] public Clientes? _IdCliente { get; set; }
        public int IdInstrumento { get; set; }
        [ForeignKey("IdInstrumento")] public Instrumentos? _IdInstrumento { get; set; }

    }
}
