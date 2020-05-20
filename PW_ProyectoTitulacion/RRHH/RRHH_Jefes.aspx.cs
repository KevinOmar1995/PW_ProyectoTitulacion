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
    public partial class RRHH_Jefes : System.Web.UI.Page
    {
        String id;
        OCKOEmpleadoUsuario empleado = new OCKOEmpleadoUsuario();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void grvJefes_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlBotones.Visible = true;
            try
            {
                GridViewRow row = grvJefes.SelectedRow;
                id = row.Cells[0].Text;
                hdId.Value = id;

                OCKO_TblEmpleado or = empleado.BuscarIdEmpleado(Convert.ToInt32(hdId.Value));
                txtCedula.Text          = or.EmpCedula;
                txtPrimerNombre.Text    = or.EmpPrimerNombre;
                txtSegundoNombre.Text   = or.EmpSegundoNombre;
                txtPrimerApellido.Text  = or.EmpPrimerApellido;
                txtSegundoApellido.Text = or.EmpSegundoApellidos;


            }
            catch
            {

            }
        }

        protected void SubmitBtn_Click(object sender, EventArgs e)
        {

        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {

        }
    }
}