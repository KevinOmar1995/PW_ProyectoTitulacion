using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaDatos;
using CapaNegocio;
namespace PW_ProyectoTitulacion.Jefes
{
    public partial class Jefes_Evaluaciones : System.Web.UI.Page
    {
        OCKOPeriodos ClassPeriodo = new OCKOPeriodos();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarPeriodos();


            }
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
        protected void gvrEvaluaciones_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            
        }
        protected void gvrEvaluaciones_RowCommand(object sender, GridViewCommandEventArgs e)
        {
          
        }

        protected void gvrEvaluaciones_RowDataBound(object sender, GridViewRowEventArgs e)
        {
           
        }

        protected void dllPeriodos_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Periodos
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            //Comenzar
            int periodo = Convert.ToInt32(dllPeriodos.SelectedValue);
            if(periodo !=0)
            {
                String Strperiodo = "Periodo="+ periodo+"&";
                String Ruta = Strperiodo+ hd1.Value;
                Response.Redirect("Jefes_InicioEvaluacion.aspx?"+ Ruta);
            }
        }
    }
}