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

        public void AgregarAuditoria(Auditorias? auditoria, Usuarios? usuario, String entidad,  int Tipo)
        {
            auditoria!.Fecha = DateTime.Now;
            auditoria.IdUsuario = usuario!.Id;

            switch (Tipo)
            {
                case 1:
                    auditoria!.TipoOperacion = "INSERT";
                    auditoria.ValoresAntiguos = "Sin valores";
                    auditoria.ValoresNuevos = entidad;
                    break;
                case 2:
                    auditoria!.TipoOperacion = "UPDATE";
                    auditoria.ValoresAntiguos = entidad;
                    auditoria.ValoresNuevos = "Se realizó una actualización";
                    break;
                case 3:
                    auditoria!.TipoOperacion = "DELETE";
                    auditoria.ValoresAntiguos = entidad;
                    auditoria.ValoresNuevos = "Se eliminó el registro";
                    break;
            }
            this.IConexion!.Auditorias!.Add(auditoria!);
            this.IConexion.SaveChanges();
        }
    }
}
