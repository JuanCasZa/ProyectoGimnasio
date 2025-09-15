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
        public int IdClientes { get; set; }
        [ForeignKey("IdClientes")] public Clientes? _IdClientes { get; set; }
        public int IdSuplementos { get; set; }
        [ForeignKey("IdSuplementos")] public Suplementos? _IdSuplementos { get; set; }

    }
}
