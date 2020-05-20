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
    public partial class PM_Seccion : System.Web.UI.Page
    {
        OCKOSeccion seccionClass = new OCKOSeccion();
        OCKO_TblSeccion seccionTable = new OCKO_TblSeccion();
                OCKOModulos moduloClass = new OCKOModulos();
        OCKOProyecto proyectoClass = new OCKOProyecto();
        String id, mensaje;
        protected void Page_Load(object sender, EventArgs e)
        {

           //     CargarDDL();
        }

       /* private void CargarDDL()
        {
            List<OCKO_TblProyecto> listaProyecto = new List<OCKO_TblProyecto>();
            listaProyecto = proyectoClass.ListaProyecto();
            listaProyecto.Insert(0, new OCKO_TblProyecto() { ProNombre = "--Seleccionar--" });
            ddlProyecto.DataSource = listaProyecto;
            ddlProyecto.DataTextField = "ProNombre";
            ddlProyecto.DataValueField = "ProId";
            ddlProyecto.DataBind();

            List<OCKO_TblModulos> listaModulos = new List<OCKO_TblModulos>();
            listaModulos = moduloClass.ListaModulos();
            listaModulos.Insert(0, new OCKO_TblModulos() { ModNombre = "--Seleccionar--" });
            ddlModulo.DataSource = listaModulos;
            ddlModulo.DataTextField = "ModNombre";
            ddlModulo.DataValueField = "ModId";
            ddlModulo.DataBind();

        }*/
        protected void btnGuardar_Click(object sender, EventArgs e)
        {

            int moduloId = Convert.ToInt32(Session["ModuloId"].ToString());
            int ProyectoId = Convert.ToInt32(Session["ProyectoId"].ToString());

            string seccion = txtNombreCreate.Text;
            bool existe = OCKOSeccion.BuscarSeccion(seccion);
            try
            {
                if (!existe)
                {

                    seccionTable.SecNombre = seccion;
                    seccionTable.SecDescripcion = txtDescripcionCreate.Text;
                    seccionTable.CodModulos = moduloId;
                    seccionTable.CodProyecto = ProyectoId;
                    seccionClass.GuardarSeccion(seccionTable);
                    mensaje = "Sección Registrada";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "confirm", "Mensaje('" + mensaje + "');", true);
                }
                else
                {
                    mensaje = "La Secciòn ya está Registrada";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "confirm", "Mensaje('" + mensaje + "');", true);
                }
            }
            catch (Exception ex)
            {
                mensaje = "Algo Salio Mal " + ex;
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "confirm", "Mensaje('" + mensaje + "');", true);
            }

        }

        protected void SubmitBtn_Click(object sender, EventArgs e)
        {
            try
            {
                OCKO_TblSeccion seccionLocal = seccionClass.BuscarIdSeccion(Convert.ToInt32(hdId.Value));
                seccionClass.EliminarSeccion(seccionLocal);
                mensaje = " ¿Esta Seguro de Eliminar  :" + seccionLocal.SecNombre + "?";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "confirm", "Evaluacion('" + mensaje + "');", true);
            }
            catch (Exception ex)
            {
                mensaje = "Algo Salio Mal" + ex;
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "confirm", "Mensaje('" + mensaje + "');", true);
            }
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                OCKO_TblSeccion seccionLocal = seccionClass.BuscarIdSeccion(Convert.ToInt32(hdId.Value));
                seccionLocal.SecNombre= txtNombreEdit.Text;
                seccionLocal.SecDescripcion = txtDescripcionEdit.Text;
                //seccionLocal.CodModulos = Convert.ToInt32(ddlModulo.SelectedValue);
                //seccionLocal.CodProyecto = Convert.ToInt32(ddlProyecto.SelectedValue);
                seccionClass.ActualizarSeccion(seccionLocal);
                mensaje = "Seción Editada";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "confirm", "Mensaje('" + mensaje + "');", true);
            }
            catch (Exception ex)
            {
                Session["ERROR_PM"] = ex;
                Response.Redirect("PM_ERROR.aspx");
            }
        }

        protected void GvrSeccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlBotones.Visible = true;
            try
            {
                GridViewRow row = GvrSeccion.SelectedRow;
                id = row.Cells[1].Text;
                hdId.Value = id;

                OCKO_TblSeccion seccionLocal = seccionClass.BuscarIdSeccion(Convert.ToInt32(hdId.Value));
                txtNombreEdit.Text = seccionLocal.SecNombre;
                txtDescripcionEdit.Text = seccionLocal.SecDescripcion;
                //ddlProyecto.SelectedValue = seccionLocal.CodProyecto.ToString();
                //ddlModulo.SelectedValue = seccionLocal.CodModulos.ToString();
                //ddlModulo.SelectedIndex =  2;//Convert.ToInt32(seccionLocal.CodModulos);
            }
            catch (Exception ex)
            {
                Session["ERROR_PM"] = ex;
                Response.Redirect("PM_ERROR.aspx");

            }
        }
    }
}