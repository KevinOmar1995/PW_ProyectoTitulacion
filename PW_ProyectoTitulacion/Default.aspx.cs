using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaDatos;
using System.Data;
using System.Data.SqlClient;
namespace PW_ProyectoTitulacion
{
    public partial class Default : System.Web.UI.Page
    {
        private OCKO_ConexionSP con = new OCKO_ConexionSP();
        SqlCommand comando = new SqlCommand();
        OCKO_StoreProcedureAction spActions = new OCKO_StoreProcedureAction();
        protected void Page_Load(object sender, EventArgs e)
        {
            ProcesoGuardar();
        }


        public void ProcesoGuardar()
        {
           /*int evaluacion = 1;
            int Empleado = 5;
            int[] resultado;
            //resultado = spActions.puntuacion(evaluacion, Empleado);

            // spActions.ActualizaPuntuacion(resultado, evaluacion, Empleado, 0);
            Response.Redirect("Empleado_EvaluacionRealizadas.aspx");*/
        }
        protected void GvCalificaciones_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    string alumno = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "idAlumno"));
                    GridView hijo = (GridView)e.Row.FindControl("gvCalificacion");
                    sdsCalificacion.FilterExpression = "idAlumno=" + alumno;
                    hijo.DataSource = sdsCalificacion;
                    hijo.DataBind();
                }
            }
            catch (Exception)
            {

                throw ;
            }
            
        }
    }
}