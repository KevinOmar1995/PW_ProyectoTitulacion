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
    public partial class PM_Procesos : System.Web.UI.Page
    {
        OCKOProcesos procesoClass = new OCKOProcesos();
        OCKO_TblProceso procesoTable = new OCKO_TblProceso();
        String id, mensaje;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Eliminar_Click(object sender, EventArgs e)
        {
            try
            {
                OCKO_TblProceso procesoLocal = procesoClass.BuscarIdProceso(Convert.ToInt32(hdId.Value));
                mensaje = " ¿Esta Seguro de Eliminar  :" + procesoLocal.ProNombre+ "?";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "confirm", "Evaluacion('" + mensaje + "');", true);
                procesoClass.EliminarProceso(procesoLocal);
            }
            catch (Exception ex)
            {
                Session["ERROR_PM"] = ex;
                Response.Redirect("PM_ERROR.aspx");
            }
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                OCKO_TblProceso procesoLocal = procesoClass.BuscarIdProceso(Convert.ToInt32(hdId.Value));
                procesoLocal.ProNombre = txtNombreEdit.Text;
                procesoLocal.ProDescripcion = txtDescripcionEdit.Text;
                procesoClass.ActualizarProceso(procesoTable);
                mensaje = "Proceso Editado";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "confirm", "MensajeEditado('" + mensaje + "');", true);
                ClientScript.RegisterStartupScript(this.GetType(), "", " setTimeout('window.location.href = window.location.href', 3000);", true);
            }
            catch (Exception ex)
            {
                Session["ERROR_PM"] = ex;
                Response.Redirect("PM_ERROR.aspx");
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string Proceso = txtNombreCreate.Text;
            bool existe = OCKOProcesos.BuscarProcesoxNombre(Proceso);
            int FaseId = int.Parse(Session["FaseId"].ToString());
            try
            {
                if (!existe)
                {

                    procesoTable.ProNombre = Proceso;
                    procesoTable.ProDescripcion = txtDescripcionCreate.Text;
                    procesoTable.CodFase = FaseId;
                    procesoClass.GuardarProceso(procesoTable);
                    mensaje = "Proceso Registrado";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "confirm", "Mensaje('" + mensaje + "');", true);
                    ClientScript.RegisterStartupScript(this.GetType(), "", " setTimeout('window.location.href = window.location.href', 3000);", true);
                }
            }
            catch (Exception ex)
            {
                Session["ERROR_PM"] = ex;
                Response.Redirect("PM_ERROR.aspx");
            }
        }

        protected void gvrProcesos_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlBotones.Visible = true;
            try
            {
                GridViewRow row = gvrProcesos.SelectedRow;
                id = row.Cells[1].Text;
                hdId.Value = id;

                OCKO_TblProceso procesoLocal = procesoClass.BuscarIdProceso(Convert.ToInt32(hdId.Value));
                txtNombreEdit.Text = procesoLocal.ProNombre;
                txtDescripcionEdit.Text = procesoLocal.ProDescripcion;
            }
            catch (Exception ex)
            {
                Session["ERROR_PM"] = ex;
                Response.Redirect("PM_ERROR.aspx");
            }
        }
    }
}