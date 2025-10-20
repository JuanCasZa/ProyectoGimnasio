using System.ComponentModel.DataAnnotations.Schema;

namespace lib_dominio.Entidades
{
    public class Auditorias
    {
        public int Id { get; set; }
        public string? TipoOperacion { get; set; }
        public DateTime Fecha { get; set; }
        public string? ValoresAntiguos { get; set; }
        public string? ValoresNuevos { get; set; }
        public int IdUsuario { get; set; }
        [ForeignKey("IdUsuario")] public Usuarios? _IdUsuario { get; set; }
    }
}
