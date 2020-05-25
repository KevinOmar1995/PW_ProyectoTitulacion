using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaDatos;
using CapaNegocio;
namespace PW_ProyectoTitulacion
{
    public partial class Login : System.Web.UI.MasterPage
    {
        OCKOValidaciones validacionesClass = new OCKOValidaciones();
        OCKOEmpleadoUsuario empleadoClass = new OCKOEmpleadoUsuario();
        OCKOEmpleadoUsuario usuarioClass = new OCKOEmpleadoUsuario();
        OCKO_TblEmpleado empleadoTable = new OCKO_TblEmpleado();
        OCKO_TblUsuario usuarioTable = new OCKO_TblUsuario();
        String Mensaje;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LogginButton_Click(object sender, EventArgs e)
        {
            try
            {
                String correo = txtEmail.Text;
                String paswordtmp = validacionesClass.CrearPasswordTmp(10);

                //OCKO_TblEmpleado empleadoLocal =  OCKOEmpleadoUsuario.recuperarContraseña(correo);
                if (OCKOEmpleadoUsuario.recuperarContraseña(correo))
                {
                    empleadoTable = empleadoClass.recuperarContraseñas(correo);
                    usuarioTable = usuarioClass.BuscarIdUsuario(empleadoTable.EmpId);
                    usuarioTable.UsuContraseña = paswordtmp;
                    usuarioClass.ActualizarUsuario(usuarioTable);

                    Mensaje = "Estimado " + empleadoTable.EmpPrimerNombre + " " + empleadoTable.EmpPrimerApellido + Environment.NewLine;
                    Mensaje += "Se ha Generado su clave temporal necesaria para ingresar al sistema. " + Environment.NewLine;
                    Mensaje += "Usuario " + usuarioTable.Usunombre + "" + Environment.NewLine;
                    Mensaje += "Contraseña Temporal " + paswordtmp + "" + Environment.NewLine;
                    Mensaje += "Una vez que haya ingresado al sistema favor en su perfil cambiar su Clave. " + Environment.NewLine + Environment.NewLine;
                    Mensaje += "ATT: Administracion.  " + Environment.NewLine + Environment.NewLine;
                    Mensaje += "(Las tildes han sido omitidas intencionalmente para evitar problemas de lectura) " + Environment.NewLine;
                    validacionesClass.enviarEmail(empleadoTable.EmpEmail, "Notificacion Recuperar Contraseña", Mensaje);
                    Response.Write("<script>window.alert('EL EMAIL FUE ENVIADO CORRECTAMENTE')</script>");

                }
                else
                {
                    Response.Write("<script>window.alert('EL CORREO NO EXISTE EN EL SISTEMA')</script>");
                }
            }
            catch (Exception EX)
            {
                Response.Write("<script>window.alert('Sucedio un Error')</script>");
            }


        }
    }
}