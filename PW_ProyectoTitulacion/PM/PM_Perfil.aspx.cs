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
    public partial class PM_Perfil : System.Web.UI.Page
    {
        OCKOEmpleadoUsuario empleadoClass = new OCKOEmpleadoUsuario();
        OCKO_TblEmpleado empleadoTable = new OCKO_TblEmpleado();
        OCKO_TblUsuario usuarioTable = new OCKO_TblUsuario();
        OCKO_TblEmpresa empresatable = new OCKO_TblEmpresa();
        OCKOEmpresa EmpresaClass = new OCKOEmpresa();
        String mensaje;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenarDatos();
                calendarFechaNacimiento.Visible = false;
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
                txtFechaNacimiento.Text = empleadoTable.EmpFechaNacimiento.ToString("d");
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
                Session["ERROR_PM"] = ex;
                Response.Redirect("PM_ERROR.aspx");
            }

        }

        protected void Guardar_Click(object sender, EventArgs e)
        {
            try
            {
                int IdEmp = Convert.ToInt32(hdId.Value);
                empleadoTable = empleadoClass.BuscarIdEmpleado(IdEmp);
                usuarioTable = empleadoClass.BuscarIdUsuario(IdEmp);

                empleadoTable.EmpCedula = txtCedula.Text;
                empleadoTable.EmpPrimerNombre = txtPrimerNombre.Text;
                empleadoTable.EmpSegundoNombre = txtSegundoNombre.Text;
                empleadoTable.EmpPrimerApellido = txtPrimerApellido.Text;
                empleadoTable.EmpSegundoApellidos = txtSegunfoApellido.Text;
                empleadoTable.EmpFechaNacimiento = Convert.ToDateTime(txtFechaNacimiento.Text).Date;
                if (radioFemenino.Checked)
                    empleadoTable.EmpGenero = "F";
                else
                    empleadoTable.EmpGenero = "M";

                empleadoTable.EmpEmail = txtEmail.Text;
                empleadoTable.EmpDireccion = txtDireccion.Text;
                empleadoTable.EmpTelefono = txttelefono.Text;
                usuarioTable.Usunombre = txtUsuario.Text;
                empleadoClass.ActualizarUsuario(usuarioTable);
                empleadoClass.ActualizarEmpleado(empleadoTable);
                mensaje = "su Perfil";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "confirm", "MensajeEditado('" + mensaje + "');", true);
                ClientScript.RegisterStartupScript(this.GetType(), "", " setTimeout('window.location.href = window.location.href', 3000);", true);
            }
            catch (Exception ex)
            {
                Session["ERROR_PM"] = ex;
                Response.Redirect("PM_ERROR.aspx");
            }
        }

        protected void btnCambiarContraseña_Click(object sender, EventArgs e)
        {
            try
            {
                OCKOEmpleadoUsuario empleadoLocalClass = new OCKOEmpleadoUsuario();
                int EmpdId = Convert.ToInt32(Session["EmpId"]);
                usuarioTable = empleadoClass.BuscarIdUsuario(EmpdId);
                if (txtConfirmarContraseña.Text == txtContraseñaNueva.Text)
                {

                    usuarioTable.UsuId = EmpdId;
                    usuarioTable.UsuContraseña = txtContraseñaNueva.Text;
                    empleadoLocalClass.ActualizarUsuario(usuarioTable);
                    mensaje = "su Contraseña";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "confirm", "MensajeEditado('" + mensaje + "');", true);
                    ClientScript.RegisterStartupScript(this.GetType(), "", " setTimeout('window.location.href = window.location.href', 3000);", true);
                }
                else
                {
                    txtConfirmarContraseña.Text = "";
                    txtContraseñaNueva.Text = "";
                    mensaje = "Las Contraseñas no coinciden";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "confirm", "MensajeError('" + mensaje + "');", true);
                }

                if (txtUsuario.Text != usuarioTable.Usunombre)
                {
                    usuarioTable.Usunombre = txtUsuario.Text;
                    empleadoLocalClass.ActualizarUsuario(usuarioTable);
                }
            }
            catch (Exception ex)
            {
                Session["ERROR_PM"] = ex;
                Response.Redirect("PM_ERROR.aspx");
            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            if (calendarFechaNacimiento.Visible)
            {
                calendarFechaNacimiento.Visible = false;
            }
            else
            {
                calendarFechaNacimiento.Visible = true;
            }
        }

        protected void calendarFechaNacimiento_SelectionChanged(object sender, EventArgs e)
        {
            txtFechaNacimiento.Text = calendarFechaNacimiento.SelectedDate.ToString("d");
            calendarFechaNacimiento.Visible = false;
        }

        protected void calendarFechaNacimiento_DayRender(object sender, DayRenderEventArgs e)
        {
            if (e.Day.IsOtherMonth || e.Day.IsWeekend)
            {
                e.Day.IsSelectable = false;
                e.Cell.BackColor = System.Drawing.Color.AliceBlue;
            }
        }
    }
}