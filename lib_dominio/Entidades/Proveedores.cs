namespace lib_dominio.Entidades
{
    public class Proveedores
    {
        public int Id { get; set; }
        public string? NombreEntidad { get; set; }
        public decimal? ValorTotalVenta { get; set; }
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }
    }
}
