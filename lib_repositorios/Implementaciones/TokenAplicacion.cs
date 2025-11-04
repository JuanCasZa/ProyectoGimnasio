using lib_dominio.Entidades;
using lib_repositorios.Interfaces;

namespace lib_repositorios.Implementaciones
{
    public class TokenAplicacion
    {
        private IConexion? IConexion = null;
        private string llave = TokenAplicacion.GenerarLlave();
        private Usuarios? usuario = null;
        private static string GenerarLlave()
        {
            string llave = "";
            string caracteres = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            Random random = new Random();
            for (int i= 0; i < 5; i++)
            {
                llave = llave + (random.Next(9).ToString());
            }
            for (int i = 0; i < 5; i++)
            {
                int indice = random.Next(caracteres.Length);
                llave = llave + caracteres[indice];
            }

            return llave;
        }

        public TokenAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public Usuarios? GetUsuario()
        {
            return this.usuario;
        }

        public string Llave(Usuarios? entidad)
        {
            var usuario = this.IConexion!.Usuarios!
                .FirstOrDefault(x => x.Nombre == entidad!.Nombre &&
                                x.Contrasenha == entidad.Contrasenha);
            this.usuario = usuario;
            if (usuario == null)
                return string.Empty;
            return llave;
        }

        public bool Validar(Dictionary<string, object> datos)
        {
            if (!datos.ContainsKey("Llave"))
                return false;
            return this.llave == datos["Llave"].ToString();
        }

        public string ValidarRol()
        {
            string rol = "";

            rol = this.IConexion!.Usuarios!
                .FirstOrDefault(x => x.Nombre == this.usuario!.Nombre &&
                                x.Contrasenha == this.usuario!.Contrasenha)!._IdRol!.Tipo!;

            return rol;
        }
    }
}
