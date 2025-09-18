namespace lib_dominio.Entidades
{
    public class Empleados
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Identificacion { get; set; }
        public string Telefono { get; set; }
        public int AnhosExperiencia { get; set; }
        public decimal Salario { get; set; }
        public bool Estado { get; set; }
        public string Especialidad { get; set; }
        public string Cargo { get; set; }
        public string HorarioDisponible { get; set; }
        public DateTime? FechaContratacion { get; set; }
    }
}
