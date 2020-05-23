using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaDatos;
using CapaNegocio;

namespace PW_ProyectoTitulacion.Jefes
{
    public partial class Jefes_AsigActividades : System.Web.UI.Page
    {
        OCKO_Listar listarClass = new OCKO_Listar();
        OCKO_TblEmpleado empleadoTable = new OCKO_TblEmpleado();
        OCKOAsignacion asignacionClass = new OCKOAsignacion();
        OCKO_TblAsignacion asignacionTable = new OCKO_TblAsignacion();
        String id, mensaje;
        protected void Page_Load(object sender, EventArgs e)
        {
            FillListar();
        }

        protected void Eliminar_Click(object sender, EventArgs e)
        {

        }

        private void FillListar()
        {
            int JefeId = Convert.ToInt32(Session["IdJefe"].ToString());
            List<OCKO_TblEmpleado> ListEmpleaod = new List<OCKO_TblEmpleado>();
            ListEmpleaod = listarClass.ListarACargoInmediato(JefeId);
            ListEmpleaod.Insert(0, new OCKO_TblEmpleado() { EmpPrimerNombre = "--Seleccionar--" });
            ddlPersonal.DataSource = ListEmpleaod;
            ddlPersonal.DataTextField = "EmpPrimerNombre";
            ddlPersonal.DataValueField = "EmpId";
            ddlPersonal.DataBind();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                OCKO_TblAsignacion asignacionLocal = asignacionClass.BuscarIdAsignacion(Convert.ToInt32(hdId.Value));
                asignacionLocal.CodEmpleado = Convert.ToInt32(ddlPersonal.SelectedValue);
                asignacionLocal.AsiEstado = "Asignado";
                asignacionLocal.AsiAvanceTecnico = 0;
                asignacionClass.ActualizarAsignacion(asignacionLocal);
                mensaje = "Tarea Asignada Correctamente";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "confirm", "Mensaje('" + mensaje + "');", true);
            }
            catch (Exception ex)
            {
                Session["ERROR_PM"] = ex;
                Response.Redirect("PM_ERROR.aspx");
            }
        }

        protected void gvrTareas_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlBotones.Visible = true;
            try
            {
                GridViewRow row = gvrTareas.SelectedRow;
                id = row.Cells[1].Text;
                hdId.Value = id;

                //OCKO_TblAsignacion asignacionTable = asignacionClass.BuscarIdAsignacion(Convert.ToInt32(hdId.Value));
                //txtNombreEdit.Text = moduloLocal.ModNombre;
                //txtDescripcionEdit.Text = moduloLocal.ModDescripcion;

            }
            catch (Exception ex)
            {
                Session["ERROR_PM"] = ex;
                Response.Redirect("PM_ERROR.aspx");

            }
        }
    }
}