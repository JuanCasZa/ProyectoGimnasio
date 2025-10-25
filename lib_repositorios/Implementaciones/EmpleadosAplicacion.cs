﻿using lib_dominio.Entidades;
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
            if (entidad == null)
                throw new Exception("lbFaltaInformación");

            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardó");

            if (entidad.Estado == true)
                throw new Exception("Primero cambiar el estado a negativo");

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

        public List<Empleados> PorCargo(Empleados? entidad)
        {
            if (entidad == null)
            {
                return new List<Empleados>();
            }

            return this.IConexion!.Empleados!.Where(x => x.Cargo!.Contains(entidad!.Cargo!)).ToList();
        }

        public List<Empleados> PorEspecialidad(Empleados? entidad)
        {
            if (entidad == null)
            {
                return new List<Empleados>();
            }

            return this.IConexion!.Empleados!.Where(x => x.Especialidad!.Contains(entidad!.Especialidad!)).ToList();
        }

        public Empleados? Modificar(Empleados? entidad)
        {
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
    }
}
