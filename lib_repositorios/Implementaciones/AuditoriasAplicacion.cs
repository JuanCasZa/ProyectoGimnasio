using lib_dominio.Entidades;
using lib_repositorios.Interfaces;


namespace lib_repositorios.Implementaciones
{
    public class AuditoriasAplicacion
    {
        private IConexion? IConexion = null;

        public AuditoriasAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }
        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public void AgregarAuditoria(Auditorias? entidad, Usuarios? usuario, int Tipo)
        {
            entidad!.Fecha = DateTime.Now;
            entidad.IdUsuario = usuario!.Id;

            switch (Tipo)
            {
                case 1:
                    entidad!.TipoOperacion = "INSERT";
                    entidad.ValoresAntiguos = "Sin valores";
                    entidad.ValoresNuevos = entidad.ToString();
                    break;
                case 2:
                    entidad!.TipoOperacion = "UPDATE";
                    entidad.ValoresAntiguos = entidad.ToString();
                    entidad.ValoresNuevos = "Se realizó una actualización";
                    break;
                case 3:
                    entidad!.TipoOperacion = "DELETE";
                    entidad.ValoresAntiguos = entidad.ToString();
                    entidad.ValoresNuevos = "Se eliminó el registro";
                    break;
            }
            this.IConexion!.Auditorias!.Add(entidad!);
            this.IConexion.SaveChanges();
        }
    }
}
