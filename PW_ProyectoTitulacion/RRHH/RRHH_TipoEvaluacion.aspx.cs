using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaDatos;
using CapaNegocio;
namespace PW_ProyectoTitulacion.RRHH
{
    public partial class RRHH_TipoEvaluacion : System.Web.UI.Page
    {
        OCKO_TipoEvaluacion tipoEvaluacion = new OCKO_TipoEvaluacion();
        
        String idEvaluacion,mensaje;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SubmitBtn_Click(object sender, EventArgs e)
        {
            
            try
            {
                OCKO_TblTipoEvaluacion evaluacion = tipoEvaluacion.BuscarIdTipoEvaluacion(Convert.ToInt32(hdId.Value));
                tipoEvaluacion.eliminarEvaluacion(evaluacion);
                mensaje = " " + evaluacion.TipEvaluacion + " Eliminada";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "confirm", "EvaluacionInicio('" + mensaje + "');", true);
            }
            catch (Exception ex)
            {
                mensaje = "Algo salio mal " + ex;
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "confirm", "EvaluacionInicio('" + mensaje + "');", true);
            }

        }

        protected void gvrTipoEvaluacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlBotones.Visible = true;
            try
            {
                GridViewRow row = gvrTipoEvaluacion.SelectedRow;
                idEvaluacion = row.Cells[1].Text;
                hdId.Value = idEvaluacion;

                OCKO_TblTipoEvaluacion eva = tipoEvaluacion.BuscarIdTipoEvaluacion(Convert.ToInt32(hdId.Value));
                txtEvaluacionEditar.Text        = eva.TipEvaluacion;
                txtEvaDescripcionEditar.Text    = eva.TipDescripcion;

            }
            catch (Exception ex)
            {
                mensaje = "Algo salio mal " + ex;
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "confirm", "EvaluacionInicio('" + mensaje + "');", true);
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            OCKO_TblTipoEvaluacion Evaluacion = new OCKO_TblTipoEvaluacion();
            Evaluacion.TipEvaluacion = txtEvaluacionCreate.Text.ToUpper();
            Evaluacion.TipDescripcion = txtEvaDescripcionCreate.Text.ToUpper();
            try
            {
                tipoEvaluacion.GuardarEvaluacion(Evaluacion);
                mensaje = " Guardado Correctamente ";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "confirm", "EvaluacionInicio('" + mensaje + "');", true);
            }
            catch (Exception ex)
            {
                mensaje = "Algo salio mal " + ex;
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "confirm", "EvaluacionInicio('" + mensaje + "');", true);
            }

        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            OCKO_TblTipoEvaluacion evaluacion = tipoEvaluacion.BuscarIdTipoEvaluacion(Convert.ToInt32(hdId.Value));
            evaluacion.TipEvaluacion    = txtEvaluacionEditar.Text;
            evaluacion.TipDescripcion   = txtEvaDescripcionEditar.Text;
            try
            {
                tipoEvaluacion.EditarEvaluacion(evaluacion);
                mensaje = " Se ha editado el Registro ";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "confirm", "EvaluacionInicio('" + mensaje + "');", true);
            }
            catch (Exception ex)
            {
                mensaje = "Algo salio mal "+ex;
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "confirm", "EvaluacionInicio('" + mensaje + "');", true);
            }

        }
    }
}