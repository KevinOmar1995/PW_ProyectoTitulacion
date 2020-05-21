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
    public partial class PM_IniciarProyecto : System.Web.UI.Page
    {
        public string ProyectoName, ArquitectoSoftware, ArquitectaFinanciera;
        OCKOEmpleadoUsuario empleadoClass = new OCKOEmpleadoUsuario();
        OCKOProyecto proyectoClass = new OCKOProyecto();
        OCKO_TblEmpleado empleadoTable = new OCKO_TblEmpleado();
        OCKO_TblProyecto proyectoTable = new OCKO_TblProyecto();

        protected void Eliminar_Click(object sender, EventArgs e)
        {

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {

        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {

        }


        protected void gvrAsignacion_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetNombresAsp();
            }
        }

        private void GetNombresAsp()
        {
            int proyectoId = int.Parse(Session["ProyectoIdAsignacion"].ToString());
            int encargadoFuncional = int.Parse(Session["EncargadoFuncional"].ToString());
            int encargadoTecnico = int.Parse(Session["EncargadoTecnico"].ToString());

            empleadoTable = empleadoClass.BuscarIdEmpleado(encargadoFuncional);
            ArquitectaFinanciera = empleadoTable.EmpPrimerNombre + " " + empleadoTable.EmpSegundoApellidos;
 
            empleadoTable = empleadoClass.BuscarIdEmpleado(encargadoTecnico);
            ArquitectoSoftware = empleadoTable.EmpPrimerNombre + " " + empleadoTable.EmpSegundoApellidos;

            proyectoTable = proyectoClass.BuscarIdProyecto(proyectoId);
            ProyectoName = proyectoTable.ProNombre;
        }
    }
}