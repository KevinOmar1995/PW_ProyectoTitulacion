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
    public partial class RRHH_Perfil : System.Web.UI.Page
    {
        OCKOEmpleadoUsuario empleadoClass = new OCKOEmpleadoUsuario();
        OCKO_TblEmpleado empleadoTable = new OCKO_TblEmpleado();
        OCKO_TblUsuario usuarioTable = new OCKO_TblUsuario();
        OCKO_TblEmpresa empresatable = new OCKO_TblEmpresa();
        OCKOEmpresa EmpresaClass = new OCKOEmpresa();
        String mensaje;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                LlenarDatos();
            }
           
        }

        private void LlenarDatos()
        {
            try
            {
                int EmpdId = Convert.ToInt32(Session["EmpId"]);

                hdId.Value = EmpdId.ToString();
                empleadoTable = empleadoClass.BuscarIdEmpleado(EmpdId);
                usuarioTable = empleadoClass.BuscarIdUsuario(EmpdId);

                txtCedula.Text = empleadoTable.EmpCedula;
                txtPrimerNombre.Text = empleadoTable.EmpPrimerNombre;
                txtSegundoNombre.Text = empleadoTable.EmpSegundoNombre;
                txtPrimerApellido.Text = empleadoTable.EmpPrimerApellido;
                txtSegunfoApellido.Text = empleadoTable.EmpSegundoApellidos;
                txtFechaNacimiento.Text = empleadoTable.EmpFechaNacimiento.ToString("yyyy - MM - dd");
                if (empleadoTable.EmpGenero == "F")
                    radioFemenino.Checked = true;
                else
                    radioMasculino.Checked = true;

                txtEmail.Text = empleadoTable.EmpEmail;
                txtDireccion.Text = empleadoTable.EmpDireccion;
                txttelefono.Text = empleadoTable.EmpTelefono;
                empresatable = EmpresaClass.BuscarIdEmpresa(Convert.ToInt32(empleadoTable.CodEmpresa));
                txtEmpresa.Text = empresatable.EmpNombre;

                //Seccion de Usuario Y contraseña
                txtUsuario.Text = usuarioTable.Usunombre;
                
            }
            catch (Exception ex)
            {
                mensaje = "Algo Salio mal. Estado: "+ex;
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "confirm", "Mensaje('" + mensaje + "');", true);
            }

        }

        protected void btnCambiarContraseña_Click(object sender, EventArgs e)
        {
            try
            {
                OCKOEmpleadoUsuario empleadoLocalClass = new OCKOEmpleadoUsuario();
                if (txtConfirmarContraseña.Text == txtContraseñaNueva.Text)
                {
                    int EmpdId = Convert.ToInt32(Session["EmpId"]);
                    usuarioTable.UsuId          = EmpdId;
                    usuarioTable.UsuContraseña  = txtContraseñaNueva.Text;
                    empleadoLocalClass.ActualizarUsuario(usuarioTable);
                    mensaje = "Contraseña Guardada con èxito";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "confirm", "Mensaje('" + mensaje + "');", true);
                }
                else
                {
                    txtConfirmarContraseña.Text = "";
                    txtContraseñaNueva.Text = "";
                    mensaje = "Las Contraseñas no coinciden";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "confirm", "Mensaje('" + mensaje + "');", true);
                }
            }
            catch (Exception ex)
            {
                mensaje = "Algo Salio mal. Estado: " + ex;
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "confirm", "Mensaje('" + mensaje + "');", true);
            }
        }

    }
}