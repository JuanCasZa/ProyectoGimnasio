using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_repositorios.Implementaciones
{
    public class BeneficiosMembresiasAplicacion : IBeneficiosMembresiasAplicacion
    {
        private IConexion? IConexion = null;

        public BeneficiosMembresiasAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public BeneficiosMembresias? Borrar(BeneficiosMembresias? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformación");

            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardó");

            this.IConexion!.BeneficiosMembresias!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public BeneficiosMembresias? Guardar(BeneficiosMembresias? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id != 0)
                throw new Exception("lbYaSeGuardo");

            if (entidad.Beneficios?.Length > 20)
                throw new Exception("Descripcion demasiado larga");

            this.IConexion!.BeneficiosMembresias!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<BeneficiosMembresias> Listar()
        {
            return this.IConexion!.BeneficiosMembresias!.Take(20).ToList();
        }

        public List<BeneficiosMembresias> PorMembresia(BeneficiosMembresias? entidad)
        {
            if (entidad == null)
            {
                return new List<BeneficiosMembresias>();
            }

            return this.IConexion!.BeneficiosMembresias!.Where(x => x.IdMembresias! == entidad!.IdMembresias).ToList();
        }
        public BeneficiosMembresias? Modificar(BeneficiosMembresias? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformación");

            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardó");

            if (entidad.Beneficios?.Length > 20)
                throw new Exception("Descripcion demasiado larga");

            var entry = this.IConexion!.Entry<BeneficiosMembresias>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}
