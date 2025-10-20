using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lib_dominio.Entidades
{
    public class InstalacionesEmpleados
    {
        [Key] public int Id { get; set; }
        public int IdInstalaciones { get; set; }
        [ForeignKey("IdInstalaciones")] public Instalaciones? _IdInstalaciones { get; set; }
        public int IdEmpleados { get; set; }
        [ForeignKey("IdEmpleados")] public Empleados? _IdEmpleados { get; set; }
    }
}
