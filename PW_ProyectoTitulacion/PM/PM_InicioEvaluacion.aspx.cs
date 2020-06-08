using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaDatos;
using CapaNegocio;
namespace PW_ProyectoTitulacion.PM
{
    public partial class PM_InicioEvaluacion : System.Web.UI.Page
    {
        OCKOPeriodos ClassPeriodo = new OCKOPeriodos();
        OCKO_TblPeriodo peridoTable = new OCKO_TblPeriodo();
        string mensaje;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarPeriodos();
            }
        }
        private void CargarPeriodos()
        {
            List<OCKO_TblPeriodo> listaPeriodo = new List<OCKO_TblPeriodo>();
            listaPeriodo = ClassPeriodo.ListarPeriodo();
            listaPeriodo.Insert(0, new OCKO_TblPeriodo() { PerPeriodo = "--Seleccionar--" });
            dllPeriodos.DataSource = listaPeriodo;
            dllPeriodos.DataTextField = "PerPeriodo";
            dllPeriodos.DataValueField = "PerId";
            dllPeriodos.DataBind();
        }
        GridView hijo;
        protected void gvrCalificaciones_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string empleado = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "EmpId"));
                hijo = (GridView)e.Row.FindControl("gvrEvaluaciones");
                sdsEvaluaciones.FilterExpression = "CodEmpleado=" + empleado;
                hijo.DataSource = sdsEvaluaciones;
                hijo.DataBind();


            }
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {

            int periodoID = int.Parse(dllPeriodos.SelectedValue);
            peridoTable = ClassPeriodo.BuscarIdPerido(periodoID);
            //obtener systemdate
            DateTime datesystem = System.DateTime.Now;
            //string date = dd.ToString("dd/MM/yyyy");

            if (datesystem > Convert.ToDateTime(peridoTable.PerFechaFin))
            {
                mensaje = "Fecha :" + datesystem.ToString("d") + " pertenece a otro Periodo";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "confirm", "MensajeError('" + mensaje + "');", true);
                ClientScript.RegisterStartupScript(this.GetType(), "", " setTimeout('window.location.href = window.location.href', 3000);", true);
            }
            else
            { 
                int periodo = Convert.ToInt32(dllPeriodos.SelectedValue);
                if (periodo != 0)
                {
                    String Strperiodo = "Periodo=" + periodo + "&";
                    String Ruta = Strperiodo + hd1.Value;
                    Session["Categoria"] = 1;
                    Response.Redirect("PM_StartEvaluacion.aspx?" + Ruta);
                }
            }
        }

        protected void dllPeriodos_SelectedIndexChanged(object sender, EventArgs e)
        {
            int periodoID = int.Parse(dllPeriodos.SelectedValue);
            peridoTable = ClassPeriodo.BuscarIdPerido(periodoID);
            //obtener systemdate
            DateTime datesystem = System.DateTime.Now;
            //string date = dd.ToString("dd/MM/yyyy");

            if (datesystem > Convert.ToDateTime(peridoTable.PerFechaFin))
            {
                mensaje = "Fecha :" + datesystem.ToString("d") + " pertenece a otro Periodo";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "confirm", "MensajeError('" + mensaje + "');", true);
                ClientScript.RegisterStartupScript(this.GetType(), "", " setTimeout('window.location.href = window.location.href', 3000);", true);
            }
        }

        protected void gvrCalificaciones_RowDataBound1(object sender, GridViewRowEventArgs e)
        {

        }

        protected void gvrEvaluaciones_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void gvrEvaluaciones_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void gvrEvaluaciones_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }
    }
}