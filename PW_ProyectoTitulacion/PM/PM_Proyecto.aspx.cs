using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaDatos;
using CapaNegocio;

namespace PW_ProyectoTitulacion.PM
{
    public partial class PM_Proyecto : System.Web.UI.Page
    {
        OCKOProyecto proyectoClass = new OCKOProyecto();
        OCKO_TblProyecto proyectoTable = new OCKO_TblProyecto();
        String id,mensaje;
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void Eliminar_Click(object sender, EventArgs e)
        {
            try
            {
                OCKO_TblProyecto proyectoLocal = proyectoClass.BuscarIdProyecto(Convert.ToInt32(hdId.Value));
                mensaje = " ¿Esta Seguro de Eliminar  :" + proyectoLocal.ProNombre + "?";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "confirm", "Evaluacion('" + mensaje + "');", true);
                proyectoClass.EliminarProyecto(proyectoLocal);
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
                OCKO_TblProyecto LocalPerido = proyectoClass.BuscarIdProyecto(Convert.ToInt32(hdId.Value));
                proyectoTable.ProNombre = txtproyectoEdit.Text;
                proyectoTable.ProDescripcion = txtDescripcionEdit.Text;
               // proyectoTable.ProFechaIncio= Convert.ToDateTime(txtFechaInicioEdit.Text).Date;
               // proyectoTable.ProFechaFinal = Convert.ToDateTime(txtfechaFinCreate.Text).Date;
                proyectoClass.ActualizarProyecto(proyectoTable);
                mensaje = "Proyecto Editado";
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
            string Proyecto = txtProyectoCreate.Text;
            bool existe = OCKOProyecto.BuscarProyectoxNombre(Proyecto);
            CultureInfo culture = new CultureInfo("es-ES");
            try
            {
                if (!existe)
                {

                    proyectoTable.ProNombre= Proyecto;
                    proyectoTable.ProDescripcion = txtDescripcionCreate.Text;
                    proyectoTable.ProFechaIncio = Convert.ToDateTime(txtFechaInicioCreate.Text).Date;
                    proyectoTable.ProFechaFinal = Convert.ToDateTime(txtfechaFinCreate.Text).Date;
                    proyectoTable.ProAvance = 0;
                    proyectoClass.GuardarProyecto(proyectoTable);
                    mensaje = "Proyecto Registrado";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "confirm", "Mensaje('" + mensaje + "');", true);
                }
            }
            catch (Exception ex)
            {
                Session["ERROR_PM"] = ex;
                Response.Redirect("PM_ERROR.aspx");
            }
        }

        protected void grvProyecto_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlBotones.Visible = true;
            try
            {
                GridViewRow row = grvProyecto.SelectedRow;
                id = row.Cells[1].Text;
                hdId.Value = id;

                OCKO_TblProyecto proyecto = proyectoClass.BuscarIdProyecto(Convert.ToInt32(hdId.Value));
                txtproyectoEdit.Text = proyecto.ProNombre;
                txtDescripcionEdit.Text = proyecto.ProDescripcion;
                txtFechaInicioEdit.Text = proyecto.ProFechaIncio.ToString();
                txtFechafinalEdit.Text = proyecto.ProFechaFinal.ToString();
            }
            catch (Exception ex)
            {
                Session["ERROR_PM"] = ex;
                Response.Redirect("PM_ERROR.aspx");
            }
        }
    }
}