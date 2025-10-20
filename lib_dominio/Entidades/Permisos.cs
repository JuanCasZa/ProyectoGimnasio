using System.ComponentModel.DataAnnotations.Schema;

namespace lib_dominio.Entidades
{
    public class Permisos
    {
        public int Id { get; set; }
        public string? TipoPermiso { get; set; }
        public bool Permitido { get; set; }
        public int IdRol { get; set; }
        [ForeignKey("IdRol")] public Roles? _IdRol { get; set; }
    }
}
