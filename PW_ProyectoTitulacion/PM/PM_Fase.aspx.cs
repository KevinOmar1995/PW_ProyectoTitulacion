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
    public partial class PM_Fase : System.Web.UI.Page
    {
        OCKOFases fasesClases = new OCKOFases();
        OCKO_TblFase faseTable = new OCKO_TblFase();
        String id, mensaje;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                OCKO_TblFase faseLocal = fasesClases.BuscarIdFases(Convert.ToInt32(hdId.Value));
                faseLocal.FasNombre = txtNombreEdit.Text;
                faseLocal.FasDescripcion = txtDescripcionEdit.Text;
                fasesClases.ActualizarFases(faseLocal);
                mensaje = "Fase Editado";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "confirm", "Mensaje('" + mensaje + "');", true);
            }
            catch (Exception ex)
            {
                Session["ERROR_PM"] = ex;
                Response.Redirect("PM_ERROR.aspx");
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string Fase = txtnombreCreate.Text;
            bool existe = OCKOFases.BuscarFasesxNombre(Fase);
            try
            {
                if (!existe)
                {

                    faseTable.FasNombre= Fase;
                    faseTable.FasDescripcion= txtDescripcionCreate.Text;
                    fasesClases.GuardarFases(faseTable);
                    mensaje = "Fase Registrado";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "confirm", "Mensaje('" + mensaje + "');", true);
                }
            }
            catch (Exception ex)
            {
                mensaje = "Algo Salio Mal " + ex;
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "confirm", "Mensaje('" + mensaje + "');", true);
            }
        }

        protected void grvFase_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlBotones.Visible = true;
            try
            {
                GridViewRow row = grvFase.SelectedRow;
                id = row.Cells[1].Text;
                hdId.Value = id;

                OCKO_TblFase fasesLocal = fasesClases.BuscarIdFases(Convert.ToInt32(hdId.Value));
                txtNombreEdit.Text = fasesLocal.FasNombre;
                txtDescripcionEdit.Text = fasesLocal.FasDescripcion;

            }
            catch (Exception ex)
            {
                Session["ERROR_PM"] = ex;
                Response.Redirect("PM_ERROR.aspx");

            }
        }

        protected void Eliminar_Click(object sender, EventArgs e)
        {
            try
            {
                OCKO_TblFase fasesLocal = fasesClases.BuscarIdFases(Convert.ToInt32(hdId.Value));
                fasesClases.EliminarFases(fasesLocal);
                mensaje = " ¿Esta Seguro de Eliminar  :" + fasesLocal.FasNombre + "?";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "confirm", "Evaluacion('" + mensaje + "');", true);
            }
            catch (Exception ex)
            {
                mensaje = "Algo Salio Mal" + ex;
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "confirm", "Mensaje('" + mensaje + "');", true);
            }
        }
    }
}