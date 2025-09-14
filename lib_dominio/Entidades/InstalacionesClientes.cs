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
        public int IdInstalacion { get; set; }
        [ForeignKey("IdInstalacion")] public Instalaciones? _IdInstalacion { get; set; }
        public int IdCliente { get; set; }
        [ForeignKey("IdCliente")] public Clientes? _IdCliente { get; set; }
    }
}
