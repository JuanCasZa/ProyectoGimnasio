using System.ComponentModel.DataAnnotations.Schema;

namespace lib_dominio.Entidades
{
    public class Usuarios
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Contrasenha { get; set; }
        public int IdEmpleado { get; set; }
        [ForeignKey("IdEmpleado")] public Empleados? _IdEmpleado { get; set; }

    }
}
