using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaDatos;
using CapaNegocio;
namespace PW_ProyectoTitulacion.RRHH
{
    public partial class RRHH_Periodos : System.Web.UI.Page
    {
        OCKOPeriodos classPeriodo = new OCKOPeriodos();
        OCKO_TblPeriodo tablePeriodo = new OCKO_TblPeriodo();
        string mensaje;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string periodo = txtnombreCreate.Text;
            bool existe = OCKOPeriodos.BuscarPeriodo(periodo);
            CultureInfo culture = new CultureInfo("es-ES");
            try
            {
                if (!existe)
                {
                   
                    tablePeriodo.PerPeriodo = periodo;
                    tablePeriodo.PerDescripcion = txtDescripcionCreate.Text;
                    tablePeriodo.PerFechaInicio = Convert.ToDateTime(dateFechaInicioCreate.Text).Date;
                    tablePeriodo.PerFechaFin    = Convert.ToDateTime(dateFechaFinCreate.Text).Date;
                    tablePeriodo.PerEstado = "A";
                    classPeriodo.GuardarPeriodo(tablePeriodo);
                    mensaje = "Periodo";
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

        protected void btnEditar_Click(object sender, EventArgs e)
        {

            try
            {
                OCKO_TblPeriodo LocalPerido = classPeriodo.BuscarIdPerido(Convert.ToInt32(hdId.Value));
                LocalPerido.PerPeriodo = txtNombreEdit.Text;
                LocalPerido.PerDescripcion = txtDescripcionEdit.Text;
                LocalPerido.PerFechaInicio = Convert.ToDateTime(dateFechaInicioEdit.Text).Date; 
                LocalPerido.PerFechaFin    = Convert.ToDateTime(datefinEdit.Text).Date;
                classPeriodo.EditarPeriodo(LocalPerido);
                mensaje = LocalPerido.PerPeriodo;
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "confirm", "MensajeEditado('" + mensaje + "');", true);
                ClientScript.RegisterStartupScript(this.GetType(), "", " setTimeout('window.location.href = window.location.href', 3000);", true);
            }
            catch (Exception ex)
            {
                Session["ERROR_RRHH"] = ex;
                Response.Redirect("RRHH_ERROR.aspx");
            }
        }

        protected void BtnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                OCKO_TblPeriodo PeriodoLocal = classPeriodo.BuscarIdPerido(Convert.ToInt32(hdId.Value));
                classPeriodo.eliminarPeriodo(PeriodoLocal);
                mensaje = " " + PeriodoLocal.PerPeriodo + "";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "confirm", "MensajeEliminar('" + mensaje + "');", true);
                ClientScript.RegisterStartupScript(this.GetType(), "", " setTimeout('window.location.href = window.location.href', 3000);", true);

            }
            catch (Exception ex)
            {
                Session["ERROR_RRHH"] = ex;
                Response.Redirect("RRHH_ERROR.aspx");
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id;
            DateTime fechaIncio, FechaFin;
            pnlBotones.Visible = true;
            try
            {
                GridViewRow row = GridView1.SelectedRow;
                id = row.Cells[1].Text;
                hdId.Value = id;
                OCKO_TblPeriodo periodo = classPeriodo.BuscarIdPerido(Convert.ToInt32(hdId.Value));
                txtNombreEdit.Text = periodo.PerPeriodo;
                txtDescripcionEdit.Text = periodo.PerDescripcion;

                dateFechaInicioEdit.Text = Convert.ToDateTime(periodo.PerFechaInicio).ToString("d");// String.Format("{0:dd/MM/yyyy}", periodo.PerFechaInicio);
                datefinEdit.Text = Convert.ToDateTime(periodo.PerFechaFin).ToString("d");  

            }
            catch (Exception ex)
            {
                Session["ERROR_RRHH"] = ex;
                Response.Redirect("RRHH_ERROR.aspx");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
           
        }

        protected void Submit_Click(object sender, EventArgs e)
        {

        }
    }
}