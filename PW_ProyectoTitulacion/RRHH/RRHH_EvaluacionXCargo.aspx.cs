using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaDatos;
using CapaNegocio;

namespace PW_ProyectoTitulacion.RRHH
{
    public partial class RRHH_EvaluacionXCargo : System.Web.UI.Page
    {
        OCKOCargo cargo = new OCKOCargo();
        OCKOTipoEvaluacion evaluacion = new OCKOTipoEvaluacion();
        OCKO_StoreProcedureAction procedure = new OCKO_StoreProcedureAction();
        string mensaje;
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);

            if (!IsPostBack)
            {
                upModal.Update();
                CargarEvaluaciones();
                CargarCargo();
            }
        }

        private void CargarEvaluaciones()
        {
            List<OCKO_TblTipoEvaluacion> listaEvaluacion = new List<OCKO_TblTipoEvaluacion>();
            listaEvaluacion = evaluacion.listaEvaluacion();
            listaEvaluacion.Insert(0, new OCKO_TblTipoEvaluacion() { TipEvaluacion = "--Seleccionar--" });
            dllEvaluacion.DataSource = listaEvaluacion;
            dllEvaluacion.DataTextField = "TipEvaluacion";
            dllEvaluacion.DataValueField = "TipId";
            dllEvaluacion.DataBind();
        }

        private void CargarCargo()
        {
            List<OCKO_TblCargo> listaEvaluacion = new List<OCKO_TblCargo>();
            listaEvaluacion = cargo.listaCargos();
            listaEvaluacion.Insert(0, new OCKO_TblCargo() { CarNombre = "--Seleccionar--" });
            dllCargo.DataSource = listaEvaluacion;
            dllCargo.DataTextField = "CarNombre";
            dllCargo.DataValueField = "CarId";
            dllCargo.DataBind();
        }

        protected void dllEvaluacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            int evaluacion1 = Convert.ToInt32(dllEvaluacion.SelectedValue);
            if (evaluacion1 != 0)
            {
                Session["EvaluacionList"] = evaluacion1;
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "confirm", "MensajeError('" + mensaje + "');", true);
                ClientScript.RegisterStartupScript(this.GetType(), "", " setTimeout('window.location.href = window.location.href', 3000);", true);
            }
        }

        protected void dllCargo_SelectedIndexChanged(object sender, EventArgs e)
        {
            int Cargo = Convert.ToInt32(dllCargo.SelectedValue);
            Session["CargoList"] = Cargo;
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            ProcesoGuardar();
        }

        public void ProcesoGuardar()
        {
            int Cargo = Convert.ToInt32(dllCargo.SelectedValue);
            int evaluacion1 = Convert.ToInt32(dllEvaluacion.SelectedValue);
            String texto = procedure.EvaluacionXCargo(Cargo, evaluacion1);
        }
    }
}