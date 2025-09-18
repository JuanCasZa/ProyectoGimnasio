using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lib_dominio.Entidades
{
    public class Instrumentos
    {
        [Key]public int Id { get; set; }
        public string NombreInstrumento { get; set; } //?
        public int CantidadEquip { get; set; } //?
        public int Piezas { get; set; } //?
        public string Marca { get; set; } //?
        public string? DescripcionGeneral { get; set; } //? no
        public bool Estado { get; set; } //?
        public int Proveedor { get; set; }
        [ForeignKey("Proveedor")] public Proveedores? _Proveedor { get; set; }
    }
}
