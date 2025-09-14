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
        public int IdInstalacion { get; set; }
        [ForeignKey("IdInstalaciones")] public Instalaciones? _IdInstalacion { get; set; }
        public int IdEmpleado { get; set; }
        [ForeignKey("IdEmpleado")] public Empleados? _IdEmpleado { get; set; }
    }
}
