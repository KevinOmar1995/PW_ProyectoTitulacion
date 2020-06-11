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
        OCKOTipoEvaluacion tipoEvaluacionClass = new OCKOTipoEvaluacion();
        OCKOValidaciones validacionesClass = new OCKOValidaciones();
        String idEvaluacion,mensaje;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private bool validarCamposCreate()
        {
            if (txtEvaluacionCreate.Text == "" || txtEvaDescripcionCreate.Text == "")
                return false;
            else
                return true;
        }
        protected void SubmitBtn_Click(object sender, EventArgs e)
        {
            
            try
            {
               
                bool respuesta;
                OCKO_TblTipoEvaluacion evaluacion = tipoEvaluacionClass.BuscarIdTipoEvaluacion(Convert.ToInt32(hdId.Value));
                respuesta = tipoEvaluacionClass.eliminarEvaluacion(evaluacion);
                if (!respuesta)
                {
                    mensaje = "La " + evaluacion.TipEvaluacion + " está atada a una asignaciòn";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "confirm", "MensajeError('" + mensaje + "');", true);
                }
                else
                {
                    mensaje = " " + evaluacion.TipEvaluacion + " Eliminada";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "confirm", "MensajeEliminar('" + mensaje + "');", true);
                    ClientScript.RegisterStartupScript(this.GetType(), "", " setTimeout('window.location.href = window.location.href', 3000);", true);
                }
               
                
            }
            catch (Exception ex)
            {
                Session["ERROR_RRHH"] = ex;
                Response.Redirect("RRHH_ERROR.aspx");
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

                OCKO_TblTipoEvaluacion eva = tipoEvaluacionClass.BuscarIdTipoEvaluacion(Convert.ToInt32(hdId.Value));
                txtEvaluacionEditar.Text        = eva.TipEvaluacion;
                txtEvaDescripcionEditar.Text    = eva.TipDescripcion;

            }
            catch (Exception ex)
            {
                Session["ERROR_RRHH"] = ex;
                Response.Redirect("RRHH_ERROR.aspx");
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {

            try
            {
                OCKO_TblTipoEvaluacion Evaluacion = new OCKO_TblTipoEvaluacion();
                if (validacionesClass.ValidarCamposVacios(txtEvaDescripcionCreate.Text)
                     && validacionesClass.ValidarCamposVacios(txtEvaluacionCreate.Text))
                {

                    if (tipoEvaluacionClass.BuscarEvaluacion(txtEvaluacionCreate.Text))
                    {
                        Evaluacion.TipEvaluacion = txtEvaluacionCreate.Text.ToUpper();
                        Evaluacion.TipDescripcion = txtEvaDescripcionCreate.Text.ToUpper();
                        tipoEvaluacionClass.GuardarEvaluacion(Evaluacion);
                        mensaje = "Evaluación";
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "confirm", "MensajeGuardado('" + mensaje + "');", true);
                        ClientScript.RegisterStartupScript(this.GetType(), "", " setTimeout('window.location.href = window.location.href', 3000);", true);
                    }
                    else
                    {
                        mensaje = "La Evaluacion Ya Existe !!";
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "confirm", "MensajeError('" + mensaje + "');", true);
                        ClientScript.RegisterStartupScript(this.GetType(), "", " setTimeout('window.location.href = window.location.href', 3000);", true);
                    }
                }
                else
                {
                    mensaje = "No se acepta campos vacios";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "confirm", "MensajeError('" + mensaje + "');", true);
                }
            }
            catch (Exception ex)
            {
                Session["ERROR_RRHH"] = ex;
                Response.Redirect("RRHH_ERROR.aspx");
            }

        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            OCKO_TblTipoEvaluacion evaluacion = tipoEvaluacionClass.BuscarIdTipoEvaluacion(Convert.ToInt32(hdId.Value));
            evaluacion.TipEvaluacion    = txtEvaluacionEditar.Text;
            evaluacion.TipDescripcion   = txtEvaDescripcionEditar.Text;
            try
            {
                tipoEvaluacionClass.EditarEvaluacion(evaluacion);
                mensaje = evaluacion.TipEvaluacion ;
                //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "confirm", "EvaluacionInicio('" + mensaje + "');", true);
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "confirm", "MensajeEditado('" + mensaje + "');", true);
                ClientScript.RegisterStartupScript(this.GetType(), "", " setTimeout('window.location.href = window.location.href', 3000);", true);

            }
            catch (Exception ex)
            {
                Session["ERROR_RRHH"] = ex;
                Response.Redirect("RRHH_ERROR.aspx");
            }

        }
    }
}