using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_repositorios.Implementaciones
{
    public class EmpleadosAplicacion : IEmpleadosAplicacion
    {
        private IConexion? IConexion = null;

        public EmpleadosAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public Empleados? Borrar(Empleados? entidad)
        {
            Empleados? entidadvieja = this.IConexion!.Empleados!.FirstOrDefault(x => x.Id! == entidad!.Id);
            if (entidadvieja == null) throw new Exception("La entidad no existe");

            if (entidad == null)
                throw new Exception("lbFaltaInformación");

            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardó");

            if (entidad.Estado == true)
                throw new Exception("Primero cambiar el estado a negativo");

            if (this.IConexion!.InstalacionesEmpleados!.Any(s => s.IdEmpleados == entidad.Id))
                throw new Exception("lbEmpleado ligado a otras tablas");
            if (this.IConexion!.Usuarios!.Any(s => s.IdEmpleado == entidad.Id))
                throw new Exception("lbEmpleado ligado a otras tablas");

            this.IConexion!.Empleados!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Empleados? Guardar(Empleados? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id != 0)
                throw new Exception("lbYaSeGuardo");

            if(entidad.Especialidad.Equals("Ninguna"))
            {
                if (entidad.Salario > 1600000)
                    throw new Exception("Salario mal ingresado");
            }

            if (entidad.Estado != true)
                throw new Exception("El estado ha de ser inicializado como verdadero");
            


            this.IConexion!.Empleados!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Empleados> Listar()
        {
            return this.IConexion!.Empleados!.Take(20).ToList();
        }

        public List<Empleados> Filtro(Empleados? entidad)
        {
            var consulta = this.IConexion!.Empleados!.AsQueryable();

            //Filtro por Especialidad, Identificacion, Telefono y Cargo
            consulta = consulta.Where(x => x.Especialidad!.Contains(entidad!.Especialidad!) && x.Identificacion!.Contains(entidad!.Identificacion!)
            && x.Telefono!.Contains(entidad!.Telefono!) && x.Cargo!.Contains(entidad!.Cargo!)).Take(50);

            return consulta.ToList();
        }

        public Empleados? Modificar(Empleados? entidad)
        {
            Empleados? entidadvieja = this.IConexion!.Empleados!.FirstOrDefault(x => x.Id! == entidad!.Id);
            if (entidadvieja == null) throw new Exception("La entidad no existe");

            if (entidad == null)
                throw new Exception("lbFaltaInformación");

            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardó");

            if (entidad.Telefono?.Length > 10)
            {
                throw new Exception("Telefeono demasido largo");
            }
            else if (entidad.Telefono?.Length < 7)
            {
                throw new Exception("Telefono demasiado corto");
            }

            var entry = this.IConexion!.Entry<Empleados>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
        public String toStrigEmpleado(Empleados? empleado)
        {
            if (empleado == null)
                throw new Exception("lbFaltaInformación");
            return $"Id: {empleado.Id}, Nombre: {empleado.Nombre}, Identificacion: {empleado.Identificacion}, Telefono: {empleado.Telefono}, Años de Experiencia: {empleado.AnhosExperiencia}, Salario: {empleado.Salario}, Estado: {empleado.Estado}, Especialidad: {empleado.Especialidad}, Cargo: {empleado.Cargo}, Horario Disponible: {empleado.HorarioDisponible}, Fecha de Contratacion: {empleado.FechaContratacion}";
        }
    }
}
