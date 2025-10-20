using System.ComponentModel.DataAnnotations.Schema;

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
