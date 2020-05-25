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
    public partial class RRHH_PreguntasLista : System.Web.UI.Page
    {
        OCKOPreguntas preguntas = new OCKOPreguntas();
        OCKO_TblPreguntas tblPreguntas = new OCKO_TblPreguntas();
        OCKO_StoreProcedureAction spActions = new OCKO_StoreProcedureAction();
        String LocalAccion, mensaje;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["EvaluacionList"] == null)
                {
                    mensaje = "No se ha seleccionado una Evaluaciòn";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "confirm", "Evaluacion('"+ mensaje + "');", true);
                }
                //valido que tipo de formulario va a ser
                if (Request.QueryString["e"].ToString() == "t")
                {
                    pnlBotonEditar.Visible = true;
                }
                else
                if (Request.QueryString["d"].ToString() == "t")
                {
                    pnlBotonEliminar.Visible = true;
                }
                else
                if (Request.QueryString["v"].ToString() == "t")
                {
                    LocalAccion = "Visualizar";
                }
                else
                if(Request.QueryString["a"].ToString() == "t")
                {
                    LocalAccion = "Crear";
                    pnlBotonCrear.Visible = true;
                }
               
            }

        }

        protected void SubmitBtn_Click(object sender, EventArgs e)
        {
            OCKO_TblPreguntas pregunta = preguntas.BuscarIdPregunta(Convert.ToInt32(hdId.Value));
            preguntas.eliminarPregunta(pregunta);
            mensaje = "Pregunta Eliminada";
            //updPnael.Update();
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "confirm", "Evaluacion('" + mensaje + "');", true);
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            int evaluacion = Convert.ToInt32( Session["EvaluacionList"].ToString());
            int categoria = Convert.ToInt32(Session["CategoriaId"].ToString());
            string pregunta = txtPreguntaC.Text;
            bool existe = OCKOPreguntas.BuscarPregunta(pregunta);
            try
            {
                if (!existe)
                {
                    tblPreguntas.PrePregunta = pregunta;
                    tblPreguntas.CodTipoEvaluacion = evaluacion;
                    tblPreguntas.PreDescripcion = txtDescripcionC.Text;
                    tblPreguntas.CodCategoria = categoria;
                    preguntas.GuardarPregunta(tblPreguntas);
                    //procedimiento almacenado donde guarda las respuestas
                    spActions.GenerarRespuestas();
                    mensaje = "Pregunta ";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "confirm", "MensajeGuardado('" + mensaje + "');", true);
                    ClientScript.RegisterStartupScript(this.GetType(), "", " setTimeout('window.location.href = window.location.href', 3000);", true);
                }
            }
            catch (Exception ex)
            {
                Session["ERROR_RRHH"] = ex;
                Response.Redirect("RRHH_ERROR.aspx");
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            try
            {
            
                OCKO_TblPreguntas pregunta = preguntas.BuscarIdPregunta(Convert.ToInt32(hdId.Value));
                pregunta.PrePregunta = txtPreguntaEditar.Text;
                pregunta.PreDescripcion = txtDescripcionEdit.Text;
                preguntas.EditarPregunta(pregunta);
                mensaje = pregunta.PrePregunta;
                //updPnael.Update();
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "confirm", "MensajeEditado('" + mensaje + "');", true);
                ClientScript.RegisterStartupScript(this.GetType(), "", " setTimeout('window.location.href = window.location.href', 3000);", true);
            }
            catch (Exception ex)
            {
                Session["ERROR_RRHH"] = ex;
                Response.Redirect("RRHH_ERROR.aspx");
            }
        }

        protected void grvPreguntas_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow row = grvPreguntas.SelectedRow;
                string id = row.Cells[1].Text;
                hdId.Value = id;
                OCKO_TblPreguntas pregunta = preguntas.BuscarIdPregunta(Convert.ToInt32(hdId.Value));
                txtPreguntaEditar.Text = pregunta.PrePregunta;
                txtDescripcionEdit.Text = pregunta.PreDescripcion;
            }
            catch (Exception ex)
            {
                Session["ERROR_RRHH"] = ex;
                Response.Redirect("RRHH_ERROR.aspx");
            }
        }
    }
}