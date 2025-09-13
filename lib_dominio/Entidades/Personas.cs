namespace lib_dominio.Entidades
{
    public class Personas
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Identificacion { get; set; }
        public int Edad { get; set; }
        public string CorreoElectronico { get; set; }
        public string? Telefono { get; set; }
        public string? Genero { get; set; }
    }
}
