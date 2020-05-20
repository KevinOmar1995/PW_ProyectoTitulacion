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
    public partial class Empleado_PageMaster : System.Web.UI.MasterPage
    {
        public String sesion;
        OCKOEmpleadoUsuario usu = new OCKOEmpleadoUsuario();
        OCKO_TblUsuario tblusuario = new OCKO_TblUsuario();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] != null)
            {
                tblusuario = usu.OckoBbuscarPorNombre(Session["Username"].ToString());

                sesion = tblusuario.Usunombre.ToUpper();
            }
            else
            {
                Response.Redirect("/Login1.aspx");

            }
        }

        protected void CerrarSesion_Click(object sender, EventArgs e)
        {
            HttpContext.Current.Session.Abandon();
            HttpContext.Current.Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
            Response.Redirect("/Login1.aspx");
        }
    }
}