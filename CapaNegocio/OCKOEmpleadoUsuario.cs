﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
namespace CapaNegocio
{
    public class OCKOEmpleadoUsuario
    {
        public static OCKO_EvaluacionDataContext OckoDc = new OCKO_EvaluacionDataContext();
        //Empleado
        public OCKO_TblEmpleado BuscarIdEmpleado(int id)
        {
            var usu = OckoDc.OCKO_TblEmpleado.First(u => u.EmpId == id);
            return usu;
        }
        //Usuario
        public OCKO_TblUsuario BuscarIdUsuario(int id)
        {
            var usu = OckoDc.OCKO_TblUsuario.First(u => u.UsuId == id);
            return usu;
        }
        public OCKO_TblEmpleado BuscarEmpleadoPorCedula(string cedula)
        {
            var nom = OckoDc.OCKO_TblEmpleado.FirstOrDefault(usu => usu.EmpCedula.Equals(cedula));
            return nom;
        }

        public bool BuscarCedula(string cedula)
        {
            var nom = OckoDc.OCKO_TblEmpleado.FirstOrDefault(usu => usu.EmpCedula.Equals(cedula));
            if (nom == null)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        //Crud
        public void OckoGuardarEmpleado(OCKO_TblEmpleado Empleado)
        {
            OckoDc.OCKO_TblEmpleado.InsertOnSubmit(Empleado);
            OckoDc.SubmitChanges();
        }
        //TDOD: revisar
        public void EliminarEmpleado(OCKO_TblEmpleado Empleado)
        {
            OckoDc.OCKO_TblEmpleado.DeleteOnSubmit(Empleado);
            OckoDc.SubmitChanges();
        }
        public void ActualizarEmpleado(OCKO_TblEmpleado Empleado)
        {
            OckoDc.SubmitChanges();
        }
        //Usuario
        public OCKO_TblUsuario BuscarUsuario(string Usuario, string contraseña)
        {
            var usua = OckoDc.OCKO_TblUsuario.FirstOrDefault(usu => usu.Usunombre.Equals(Usuario) && usu.UsuContraseña.Equals(contraseña));
            return usua;
        }
        public OCKO_TblUsuario OckoRecuperarContrasena(string user, string email)
        {
            var usua = OckoDc.OCKO_TblUsuario.FirstOrDefault(usu => usu.Usunombre.Equals(user) && usu.OCKO_TblEmpleado.EmpEmail.Equals(email));
            return usua;
        }
        public OCKO_TblUsuario OckoBbuscarPorNombre(String usuario)
        {
            var nom = OckoDc.OCKO_TblUsuario.FirstOrDefault(usu => usu.Usunombre.Equals(usuario));
            return nom;
        }

        public bool BuscarUsuario(String usuario)
        {
            var nom = OckoDc.OCKO_TblUsuario.FirstOrDefault(usu => usu.Usunombre.Equals(usuario));
            if (nom != null)
            {
                return true;
            }
            else
            {
                return false;
            }
           
        }


        public OCKO_TblUsuario OckoBuscarPorId(int id)
        {
            var usu = OckoDc.OCKO_TblUsuario.First(u => u.UsuId == id);
            return usu;
        }
        //Crud
        public void GuardarUsuario(OCKO_TblUsuario Usuario)
        {
            OckoDc.OCKO_TblUsuario.InsertOnSubmit(Usuario);
            OckoDc.SubmitChanges();
        }
        public void EliminarUsuario(OCKO_TblUsuario usu)
        {
            OckoDc.OCKO_TblEmpleado.DeleteOnSubmit(usu.OCKO_TblEmpleado);
            OckoDc.SubmitChanges();
        }
        public void ActualizarUsuario(OCKO_TblUsuario usu)
        {
            OckoDc.SubmitChanges();
        }
        //Validar por cedula
        public OCKO_TblEmpleado VerificarCedula(string email)
        {
            var usua = OckoDc.OCKO_TblEmpleado.FirstOrDefault(usu => usu.EmpCedula.Equals(email));
            return usua;
        }
        //Validar las Email
        public static bool recuperarContraseña(string email)
        {
            bool verdadero = true;
            try
            {
                var usua = OckoDc.OCKO_TblEmpleado.FirstOrDefault(usu => usu.EmpEmail.Equals(email));
                if (usua == null)
                    return verdadero = false;
                else
                    return verdadero;

            }
            catch (Exception ex)
            {
                return verdadero = false;
            }
             
        }

        public OCKO_TblEmpleado  recuperarContraseñas(string email)
        {
                var usua = OckoDc.OCKO_TblEmpleado.FirstOrDefault(usu => usu.EmpEmail.Equals(email));
            return usua;
        }


    }
}
