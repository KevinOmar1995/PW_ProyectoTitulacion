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
    public partial class PM_Modulos : System.Web.UI.Page
    {
        OCKOModulos modulosClass = new OCKOModulos();
        OCKO_TblModulos moduloTable = new OCKO_TblModulos();
        String id, mensaje;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Eliminar_Click(object sender, EventArgs e)
        {
            try
            {
                OCKO_TblModulos moduloLocal = modulosClass.BuscarIdModulos(Convert.ToInt32(hdId.Value));
                modulosClass.EliminarModulos(moduloLocal);
                mensaje = " ¿Esta Seguro de Eliminar  :" + moduloLocal.ModNombre + "?";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "confirm", "Evaluacion('" + mensaje + "');", true);
            }
            catch (Exception ex)
            {
                Session["ERROR_PM"] = ex;
                Response.Redirect("PM_ERROR.aspx");
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string Modulo = txtnombreCreate.Text;
            bool existe = OCKOModulos.BuscarModulosxNombre(Modulo);
            try
            {
                if (!existe)
                {

                    moduloTable.ModNombre = Modulo;
                    moduloTable.ModDescripcion = txtDescripcionCreate.Text;
                    modulosClass.GuardarModulos(moduloTable);
                    mensaje = "Modulo Registrado";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "confirm", "Mensaje('" + mensaje + "');", true);
                }
                else
                {
                    mensaje = "Modulo ya està Registrado";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "confirm", "Mensaje('" + mensaje + "');", true);
                }
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
                OCKO_TblModulos moduloLocal = modulosClass.BuscarIdModulos(Convert.ToInt32(hdId.Value));
                moduloTable.ModNombre= txtNombreEdit.Text;
                moduloTable.ModDescripcion = txtDescripcionEdit.Text;
                modulosClass.ActualizarModulos(moduloTable);
                mensaje = "Modulo Editado";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "confirm", "Mensaje('" + mensaje + "');", true);
            }
            catch (Exception ex)
            {
                Session["ERROR_PM"] = ex;
                Response.Redirect("PM_ERROR.aspx");
            }
        }

        protected void grvmodulos_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlBotones.Visible = true;
            try
            {
                GridViewRow row = grvmodulos.SelectedRow;
                id = row.Cells[1].Text;
                hdId.Value = id;

                OCKO_TblModulos moduloLocal = modulosClass.BuscarIdModulos(Convert.ToInt32(hdId.Value));
                txtNombreEdit.Text = moduloLocal.ModNombre;
                txtDescripcionEdit.Text = moduloLocal.ModDescripcion;
                
            }
            catch (Exception ex)
            {
                Session["ERROR_PM"] = ex;
                Response.Redirect("PM_ERROR.aspx");

            }
        }
    }
}