using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaDatos;
using CapaNegocio;

namespace PW_ProyectoTitulacion.Empleados
{
    public partial class Empleado_Asignadas : System.Web.UI.Page
    {
        String estado;
        String id, mensaje ;
        int valorPorcentaje, estadoId;
        OCKOAsignacion asignacionClass = new OCKOAsignacion();
        OCKO_TblAsignacion asignacionTable = new OCKO_TblAsignacion();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void gvrAsignacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ModalView", "<script>$('#exampleModal').modal('show');</script>", false);

            try
            {
                GridViewRow row = gvrAsignacion.SelectedRow;
                id = row.Cells[1].Text;
                hdId.Value = id;

                OCKO_TblAsignacion asignacionTable = asignacionClass.BuscarIdAsignacion(Convert.ToInt32(hdId.Value));
                
                switch (asignacionTable.AsiEstado)
                {
                    case "Inicio":
                        estadoId = 1;

                        break;
                    case "Analisis":
                        estadoId = 2;

                        break;
                    case "Proceso":
                        estadoId = 3;

                        break;

                    case "Pruebas":
                        estadoId = 4;

                        break;
                    case "Terminado":
                        estadoId = 5;
                        break;
                }
                if (estadoId!=0)
                {
                    ddlEstados.SelectedValue = estadoId.ToString();
                }
               

                //txtNombreEdit.Text = moduloLocal.ModNombre;
                //txtDescripcionEdit.Text = moduloLocal.ModDescripcion;

            }
            catch (Exception ex)
            {
                Session["ERROR_PM"] = ex;
                Response.Redirect("PM_ERROR.aspx");

            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            int estadoSelect = Convert.ToInt32(ddlEstados.SelectedValue);
            estado = "";
            switch (estadoSelect)
            {
                case 1:
                    estado = "Inicio";
                    valorPorcentaje = 0;
                    break;
                case 2:
                    estado = "Analisis";
                    valorPorcentaje = 25;
                    break;
                case 3:
                    estado = "Proceso";
                    valorPorcentaje = 50;
                    break;

                case 4:
                    estado = "Pruebas";
                    valorPorcentaje = 75;
                    break;
                case 5:
                    estado = "Terminado";
                    valorPorcentaje = 100;
                    break;
            }
            OCKO_TblAsignacion asignacionTable = asignacionClass.BuscarIdAsignacion(Convert.ToInt32(hdId.Value));
            asignacionTable.AsiEstado = estado;
            asignacionTable.AsiAvanceTecnico = valorPorcentaje;
            asignacionClass.ActualizarAsignacion(asignacionTable);
            mensaje = "Cambio de estado a :     "+ estado +"    la tarea :  "+ asignacionTable .AsiDescripcion;
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "confirm", "Mensaje('" + mensaje + "');", true);

        }
 
    }
}