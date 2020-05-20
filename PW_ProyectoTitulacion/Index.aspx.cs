using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using CapaNegocio;

namespace PW_ProyectoTitulacion
{
    public partial class Index : System.Web.UI.Page
    {
        OCKOValidaciones OckoValidaciones = new OCKOValidaciones();
        OCKOEmpleadoUsuario OckoUsuario = new OCKOEmpleadoUsuario();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["intento"] == null)
            {
                Session["intento"] = "0";
            }
        }
        public static bool IsValidPassword(string plainText)
        {
            Regex regex = new Regex(@"^(.{0,7}|[^0-9]*|[^A-Z])$");
            Match match = regex.Match(plainText);
            return match.Success;
        }
        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            int intento = Convert.ToInt32(Session["intento"].ToString());
            OCKO_TblUsuario usuario = OckoUsuario.BuscarUsuario(TxtUserName.Text, TxtPassword.Text);//OckoValidaciones.Encriptar(TxtPassword.Text));

            if (usuario != null)
            {
                string nombre = usuario.OCKO_TblRol.RolNombre;
                if (nombre.Trim()=="RRHH")
                {
                    if (usuario.UsuEstado.Equals(Convert.ToChar("R")))
                    {
                        Response.Redirect("cambiarContraseña.aspx?id=" + usuario.UsuId);
                    }
                    else
                    {
                        Session["usuario"] = usuario;
                        Response.Redirect("RRHH/RRHH_Index.aspx");
                    }
                }
                else
                {
                    //AQUI SE REDIRECCIONA AL TEMPLATE DEL USUARIO
                }
            }
            else
            {
                if (OckoUsuario.OckoBbuscarPorNombre(TxtUserName.Text) != null)
                {
                    Response.Write("<script>window.alert('Contraseña incorrecta')</script>");
                }
                else
                {
                    Response.Write("<script>window.alert('Usuario NO Registrado')</script>");
                }
                if (intento >= 2)
                {
                    btnIngresar.Enabled = false;
                    intentos.Text = "Intente mas tarde";

                }
                else
                {

                    intento = intento + 1;
                    Session["intento"] = intento;
                    intentos.Text = "INTENTOS   :" + intento;

                }
            }
        }
    }
}