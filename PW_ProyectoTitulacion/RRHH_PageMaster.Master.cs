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
    public partial class RRHH_PageMaster : System.Web.UI.MasterPage
    {
        public String sesion;
        OCKOEmpleadoUsuario usu = new OCKOEmpleadoUsuario();
        OCKO_TblUsuario tblusuario = new OCKO_TblUsuario();
        OCKO_TipoEvaluacion evaluacion = new OCKO_TipoEvaluacion();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarEvaluaciones();

            }
            
            if (Session["Username"] != null)
            {
                tblusuario = usu.OckoBbuscarPorNombre(Session["Username"].ToString()) ;

                sesion = tblusuario.Usunombre.ToUpper();
            }
            else
            {
                Response.Redirect("/Login1.aspx");

            }
        }
        private void CargarEvaluaciones()
        {
            List<OCKO_TblTipoEvaluacion> listaEvaluacion = new List<OCKO_TblTipoEvaluacion>();
            listaEvaluacion = evaluacion.listaEvaluacion();
            listaEvaluacion.Insert(0, new OCKO_TblTipoEvaluacion() { TipEvaluacion = "--Seleccionar--" });
            dllEvaluacion.DataSource = listaEvaluacion;
            dllEvaluacion.DataTextField = "TipEvaluacion";
            dllEvaluacion.DataValueField = "TipId";
            dllEvaluacion.DataBind();

            ddlEvaluacionR.DataSource = listaEvaluacion;
            ddlEvaluacionR.DataTextField = "TipEvaluacion";
            ddlEvaluacionR.DataValueField = "TipId";
            ddlEvaluacionR.DataBind();


        }

        protected void CerrarSesion(object sender, EventArgs e)
        {
            /*String a= Session["Username"].ToString();
            Session["usuario"] = null;
            Response.Redirect("/Login1.aspx");*/
            HttpContext.Current.Session.Abandon();
            HttpContext.Current.Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
            Response.Redirect("/Login1.aspx");
        }

        protected void dllEvaluacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            int evaluacion1 = Convert.ToInt32(dllEvaluacion.SelectedValue);
            Session["TipoEvaluacion"] = evaluacion1;
            Response.Redirect("./RRHH_EvaluacionesPendientes.aspx");
        }

        protected void ddlEvaluacionR_SelectedIndexChanged(object sender, EventArgs e)
        {
            int evaluacion1 = Convert.ToInt32(ddlEvaluacionR.SelectedValue);
            Session["TipoEvaluacion"] = evaluacion1;
            Response.Redirect("./RRHH_EvaluacionesRealizadas.aspx");
        }
    }
}