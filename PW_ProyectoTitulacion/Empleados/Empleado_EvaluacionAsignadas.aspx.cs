using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaDatos;
using CapaNegocio;
namespace PW_ProyectoTitulacion.Empleados
{
    public partial class Empleado_EvaluacionAsignadas : System.Web.UI.Page
    {
        OCKOTipoEvaluacion tipoEvaluacion = new OCKOTipoEvaluacion();
        OCKO_TblTipoEvaluacion tblevaluacion = new OCKO_TblTipoEvaluacion();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Unnamed1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void grvEvaluacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            string idEvaluacion,mensaje;
            pnlBotones.Visible = true;
            try
            {
                //EvaluacionInicio
                GridViewRow row = grvEvaluacion.SelectedRow;
                idEvaluacion = row.Cells[1].Text;
                Session["NoEvaluacion"] = idEvaluacion;
                tblevaluacion = tipoEvaluacion.BuscarIdTipoEvaluacion(Convert.ToInt32(idEvaluacion));
                mensaje = " ¿Esta Seguro de Iniciar :"+ tblevaluacion.TipEvaluacion+"?";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "confirm", "EvaluacionInicio('" + mensaje + "');", true);

            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(' Algo Salio Mal" + ex + "');", true);
            }
        }
    }
}