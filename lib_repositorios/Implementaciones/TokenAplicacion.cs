using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Update.Internal;
using Microsoft.Extensions.Configuration;
using System.Reflection.Metadata.Ecma335;

namespace lib_repositorios.Implementaciones
{
    public class TokenAplicacion
    {
        private IConexion? IConexion = null;
        private Auditorias? auditoria = null;
        private static Dictionary<string, Usuarios> LlavesActivas = new();

        public TokenAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        private static string GenerarLlave()
        {
            string llave = "";
            string caracteres = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            Random random = new Random();
            for (int i = 0; i < 5; i++)
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

        public string Llave(Usuarios? entidad)
        {
            var usuario = this.IConexion!.Usuarios!
                .FirstOrDefault(x => x.Nombre == entidad!.Nombre &&
                                     x.Contrasenha == entidad.Contrasenha);
            if (usuario == null)
                throw new Exception("Usuario o contraseña incorrecta");

            string nuevaLlave = GenerarLlave();
            LlavesActivas[nuevaLlave] = usuario;
            return nuevaLlave;
        }

        public bool Validar(Dictionary<string, object> datos)
        {
            if (!datos.ContainsKey("Llave"))
                return false;

            string llaveRecibida = datos["Llave"].ToString()!;
            return LlavesActivas.ContainsKey(llaveRecibida);
        }

        
        public string ValidarRol(string llave)
        {

            if (!LlavesActivas.ContainsKey(llave)) return string.Empty;

            Usuarios usuario = LlavesActivas[llave];

            bool rolExiste = this.IConexion!.Roles!.Any(p => p.Id == usuario.IdRol);

            if (rolExiste == false) return "El rol no existe";

            string Rol = this.IConexion!.Roles!.FirstOrDefault(p => p.Id == usuario.IdRol)!.Tipo!;

            return Rol;
        }
        public Auditorias? GetAuditoria()
        {

            return this.auditoria = new Auditorias();
        }

        public Usuarios? GetUsuario(string llave)
        {
            if (!LlavesActivas.ContainsKey(llave))
                throw new Exception("Usuario no encontrado para registrar auditoria");

            return LlavesActivas[llave];
        }
    }

}
