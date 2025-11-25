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
            BeneficiosMembresias? entidadvieja = this.IConexion!.BeneficiosMembresias!.FirstOrDefault(x => x.Id! == entidad!.Id);
            if (entidadvieja == null) throw new Exception("La entidad no existe");

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

            if (!(this.IConexion!.Membresias!.Any(x => x.Id! == entidad!.IdMembresias)))
            {
                throw new Exception($"La entidad con id {entidad.IdMembresias} no existe");
            }

            this.IConexion!.BeneficiosMembresias!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<BeneficiosMembresias> Listar()
        {
            return this.IConexion!.BeneficiosMembresias!.Take(20).Include(x=> x._IdMembresias).ToList();
        }

        public List<BeneficiosMembresias> Filtro(BeneficiosMembresias? entidad)
        {
            
            var consulta = this.IConexion!.BeneficiosMembresias!.Include(x=> x._IdMembresias).AsQueryable();

            //Filtro por tipo de la membresia asociada
            if (entidad?._IdMembresias?.TipoMembresia is not null)
            {
                consulta = consulta.Where(x =>
                    x._IdMembresias!.TipoMembresia.Contains(entidad._IdMembresias.TipoMembresia)
                );
            }

            //Filtro por Beneficios
            if (!string.IsNullOrEmpty(entidad?.Beneficios))
            {
                consulta = consulta.Where(x =>
                    x.Beneficios!.Contains(entidad.Beneficios)
                );
            }            

            return consulta.ToList();
        }

        public BeneficiosMembresias? Modificar(BeneficiosMembresias? entidad)
        {
            BeneficiosMembresias? entidadvieja = this.IConexion!.BeneficiosMembresias!.FirstOrDefault(x => x.Id! == entidad!.Id);
            if (entidadvieja == null) throw new Exception("La entidad no existe");

            if (entidad == null)
                throw new Exception("lbFaltaInformación");

            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardó");

            if (entidad.Beneficios?.Length > 20)
                throw new Exception("Descripcion demasiado larga");

            if (entidadvieja.IdMembresias != entidad.IdMembresias) throw new Exception("El id de la membresia debe de ser el mismo");

            var entry = this.IConexion!.Entry<BeneficiosMembresias>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}
