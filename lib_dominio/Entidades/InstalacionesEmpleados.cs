using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
