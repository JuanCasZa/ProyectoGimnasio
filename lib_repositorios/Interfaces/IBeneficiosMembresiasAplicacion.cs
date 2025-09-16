﻿using lib_dominio.Entidades;

namespace lib_repositorios.Interfaces
{
    public interface IBeneficiosMembresiasAplicacion
    {
        void Configurar(string StringConexion);
        List<BeneficiosMembresias> Listar();
        BeneficiosMembresias? Guardar(BeneficiosMembresias? entidad);
        BeneficiosMembresias? Modificar(BeneficiosMembresias? entidad);
        BeneficiosMembresias? Borrar(BeneficiosMembresias? entidad);
    }
}
