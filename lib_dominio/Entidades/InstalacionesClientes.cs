using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_dominio.Entidades
{
    public class InstalacionesClientes
    {
        [Key] public int Id { get; set; }
        public int RegistroIngresoClientes { get; set; }
        public int IdInstalaciones { get; set; }
        [ForeignKey("IdInstalaciones")] public Instalaciones? _IdInstalaciones { get; set; }
        public int IdClientes { get; set; }
        [ForeignKey("IdClientes")] public Clientes? _IdClientes { get; set; }
    }
}
