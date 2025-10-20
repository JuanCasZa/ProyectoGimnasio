using System.ComponentModel.DataAnnotations.Schema;

namespace lib_dominio.Entidades
{
    public class Roles
    {
        public int Id { get; set; }
        public string? Tipo { get; set; }
        public int IdUsuario { get; set; }
        [ForeignKey("IdUsuario")] public Usuarios? _IdUsuario { get; set; }
    }
}
