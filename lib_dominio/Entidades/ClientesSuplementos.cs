using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_dominio.Entidades
{
    public class ClientesSuplementos
    {
        [Key] public int Id { get; set; }
        public int CantidadCompraSuplementos { get; set; }
        public decimal ValorTotalCompra { get; set; }
        public int IdCliente { get; set; }
        [ForeignKey("IdCliente")] public Clientes? _IdCliente { get; set; }
        public int IdSuplemento { get; set; }
        [ForeignKey("IdSuplemento")] public Suplementos? _IdSuplemento { get; set; }

    }
}
