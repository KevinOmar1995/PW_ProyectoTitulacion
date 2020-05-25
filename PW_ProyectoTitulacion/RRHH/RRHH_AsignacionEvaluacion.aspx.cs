using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaDatos;
using CapaNegocio;
using System.Threading;

namespace PW_ProyectoTitulacion.RRHH
{
    public partial class RRHH_AsignacionEvaluacion : System.Web.UI.Page
    {
        OCKOTipoEvaluacion evaluacion = new OCKOTipoEvaluacion();
        OCKOEvaluacionEmpleado evaEmpleado = new OCKOEvaluacionEmpleado();
        OCKO_TblEvaluacionEmpleado _OCKO_TblEvaluacionEmpleado = new OCKO_TblEvaluacionEmpleado();
        int codevaluacion;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarEvaluaciones();
                lblMensajevisto.Text = String.Empty;
            }
            lblMensajevisto.Text = String.Empty;
        }

        private void CargarEvaluaciones()
        {
            List<OCKO_TblTipoEvaluacion> listaEvaluacion = new List<OCKO_TblTipoEvaluacion>();
            listaEvaluacion = evaluacion.listaEvaluacion();
            listaEvaluacion.Insert(0, new OCKO_TblTipoEvaluacion() { TipEvaluacion = "--Seleccionar--" });
            ddlEvaluaciones.DataSource = listaEvaluacion;
            ddlEvaluaciones.DataTextField = "TipEvaluacion";
            ddlEvaluaciones.DataValueField = "TipId";
            ddlEvaluaciones.DataBind();
        }

        protected void Btn_Regitrar_Click(object sender, EventArgs e)
        {

        }

        protected void gvrEmpelados_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lblMensajevisto.Text = String.Empty;
                codevaluacion = Convert.ToInt32(ddlEvaluaciones.SelectedValue);
                GridViewRow row = gvrEmpelados.SelectedRow;
                string id = row.Cells[0].Text;
                int idEmpleado = Convert.ToInt32(id);
                DateTime tiempo = DateTime.UtcNow;
                int resultado = 0;
                _OCKO_TblEvaluacionEmpleado.CodEmpleado = idEmpleado;
                _OCKO_TblEvaluacionEmpleado.EvaFecha = tiempo;
                _OCKO_TblEvaluacionEmpleado.EvaResultado = resultado;
                bool existe = OCKOEvaluacionEmpleado.AsignacionEvaluacion(idEmpleado, codevaluacion);
                if (!existe)
                {
                    evaEmpleado.GuardarEvaluacionEmpleado(_OCKO_TblEvaluacionEmpleado);
                    lblMensajevisto.ForeColor = System.Drawing.Color.Green;
                    lblMensajevisto.Text = "Registrado con Exito ";
                    
                }
                else
                {
                    lblMensajevisto.ForeColor = System.Drawing.Color.Red;
                    lblMensajevisto.Text = "Evaluacion ya está asignada ";
                    
                }
                
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Sucedio un Error ');window.location.href='RRHH_AsignacionEvaluacion.aspx';</script>");
            }
        }

    }
}