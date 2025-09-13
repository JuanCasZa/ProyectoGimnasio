using lib_dominio.Entidades;

namespace ut_presentacion.Nucleo
{
    public class EntidadesNucleo
    {
        public static Personas? Personas()
        {
            var entidad = new Personas();
            entidad.Nombre = "Julián Arias";
            entidad.Identificacion = "1000194984";
            entidad.Edad = 24;
            entidad.CorreoElectronico = "correo@hotmail.com";
            entidad.Telefono = "3104207950";
            entidad.Genero = "M";

            return entidad;
        }
    }
}
