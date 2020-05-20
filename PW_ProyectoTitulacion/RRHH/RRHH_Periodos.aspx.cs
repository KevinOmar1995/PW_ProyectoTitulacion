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
                    mensaje = "Periodo Registrado";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "confirm", "Mensaje('" + mensaje + "');", true);
                }
            }
            catch (Exception ex)
            {
                mensaje = "Algo Salio Mal " + ex;
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "confirm", "Mensaje('" + mensaje + "');", true);
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
                mensaje = "Registro Editado";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "confirm", "Mensaje('" + mensaje + "');", true);
            }
            catch (Exception ex)
            {
                mensaje = "Algo salio mal " + ex;
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "confirm", "Mensaje('" + mensaje + "');", true);
            }
        }

        protected void BtnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                OCKO_TblPeriodo PeriodoLocal = classPeriodo.BuscarIdPerido(Convert.ToInt32(hdId.Value));
                classPeriodo.eliminarPeriodo(PeriodoLocal);
                mensaje = " ¿Esta Seguro de Eliminar  :" + PeriodoLocal.PerPeriodo + "?";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "confirm", "Evaluacion('" + mensaje + "');", true);
            }
            catch (Exception ex)
            {
                mensaje = "Algo Salio Mal" + ex;
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "confirm", "Mensaje('" + mensaje + "');", true);
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
                fechaIncio = Convert.ToDateTime( periodo.PerFechaInicio);
                dateFechaInicioEdit.Text = fechaIncio.ToShortDateString();// String.Format("{0:dd/MM/yyyy}", periodo.PerFechaInicio);
                datefinEdit.Text = String.Format("{0:dd/MM/yyyy}", periodo.PerFechaFin);
                datefinEdit.Text = periodo.PerFechaFin.ToString();

            }
            catch (Exception ex)
            {
                mensaje = "Algo Salio Mal" + ex;
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "confirm", "Mensaje('" + mensaje + "');", true);
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