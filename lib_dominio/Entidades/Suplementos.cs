using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_dominio.Entidades
{
    public class Suplementos
    {
        public int Id { get; set; }
        public string NombreSuplemento { get; set; }
        public string TipoSuplemento { get; set; }
        public decimal Valor { get; set; }
        public int Cantidad { get; set; }
        public int Proveedor { get; set; }
        [ForeignKey("Proveedor")] public Proveedores? _Proveedor { get; set; }
    }
}
