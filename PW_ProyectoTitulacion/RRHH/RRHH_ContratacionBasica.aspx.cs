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
    public partial class RRHH_ContratacionBasica : System.Web.UI.Page
    {
        OCKOListar listarClass = new OCKOListar();
        OCKOEmpleadoUsuario empleadoClass = new OCKOEmpleadoUsuario();
        OCKO_StoreProcedureAction storeProClass = new OCKO_StoreProcedureAction();
        OCKOCargo cargoClass = new OCKOCargo();
        OCKOValidaciones validacionesClass = new OCKOValidaciones();
        int Cargo, jefe,Empresa;
        string CargoAplicar,mensaje;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.CargarEmpresa();
                this.CargarCargo();

            }
        }

        private void CargarEmpresa()
        {
            List<OCKO_TblEmpresa> listaEmpresa = new List<OCKO_TblEmpresa>();
            listaEmpresa = listarClass.ListarEmpresa();
            listaEmpresa.Insert(0, new OCKO_TblEmpresa() { EmpNombre = "--Seleccionar--" });
            ddlEmpresa.DataSource = listaEmpresa;
            ddlEmpresa.DataTextField = "EmpNombre";
            ddlEmpresa.DataValueField = "EmpId";
            ddlEmpresa.DataBind();
        }

        private void CargarCargo()
        {
            List<OCKO_TblCargo> listaEmpresa = new List<OCKO_TblCargo>();
            listaEmpresa = cargoClass.listaCargos();
            listaEmpresa.Insert(0, new OCKO_TblCargo() { CarNombre = "--Seleccionar--" });
            ddlCargo.DataSource = listaEmpresa;
            ddlCargo.DataTextField = "CarNombre";
            ddlCargo.DataValueField = "CarId";
            ddlCargo.DataBind();
        }

        protected void ddlEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        protected void ddlCargo_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargoAplicar = ddlCargoAplicar.SelectedValue;
            Cargo = Convert.ToInt32(ddlCargo.SelectedValue);

            if (CargoAplicar == "Empleado")
            {
                ddljefeInmediato.Visible = true;
                lblJefeInmediato.Visible = true;
                List<OCKO_TblEmpleado> ListEmpleaod = new List<OCKO_TblEmpleado>();
                ListEmpleaod = listarClass.ListarJefeInmediato(Cargo);
                ListEmpleaod.Insert(0, new OCKO_TblEmpleado() { EmpPrimerNombre = "--Seleccionar--" });
                ddljefeInmediato.DataSource = ListEmpleaod;
                ddljefeInmediato.DataTextField = "EmpPrimerNombre";
                ddljefeInmediato.DataValueField = "EmpId";
                ddljefeInmediato.DataBind();
            }
            
        }

        protected void ddljefeInmediato_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlCargoAplicar_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        protected void Guardar_Click(object sender, EventArgs e)
        {
            CargoAplicar = ddlCargoAplicar.SelectedValue;
            Cargo = Convert.ToInt32(ddlCargo.SelectedValue);
            jefe = Convert.ToInt32(ddljefeInmediato.SelectedValue);
            Empresa = Convert.ToInt32(ddlEmpresa.SelectedValue);

            if (CargoAplicar != "--Seleccionar--" && Cargo != 0 && jefe != 0 && Empresa != 0)
            {
                if (empleadoClass.BuscarCedula(txtCedula.Text))
                {
                    if (validacionesClass.ValidarCedula(txtCedula.Text))
                    {
                        try
                        {
                            OCKO_TblEmpleado empleado = new OCKO_TblEmpleado();
                            empleado.EmpCedula = txtCedula.Text;
                            empleado.EmpPrimerNombre = txtPrimerNombre.Text;
                            empleado.EmpSegundoNombre = txtSegundoNombre.Text;
                            empleado.EmpPrimerApellido = txtPrimerApellido.Text;
                            empleado.EmpSegundoApellidos = txtSegunfoApellido.Text;
                            empleado.EmpEmail = txtEmail.Text;
                            empleado.EmpDireccion = txtDireccion.Text;
                            if (RadioMasculino.Checked == true)
                                empleado.EmpGenero = "M";
                            else
                                empleado.EmpGenero = "F";

                            empleado.EmpFechaNacimiento = Convert.ToDateTime(txtFechaNacimiento.Text).Date;
                            empleado.EmpTelefono = txttelefono.Text;
                            if (CargoAplicar == "Empleado")
                            {

                                empleado.EmpJefeId = jefe;
                                empleado.EmpJefe = "N";
                            }
                            else
                            if (CargoAplicar == "Jefe")
                            {
                                empleado.EmpJefe = "Y";
                            }
                            empleado.CodCargo = Cargo;
                            empleado.CodEmpresa = Empresa;
                            empleado.EmpFechaContratacion = Convert.ToDateTime(DateTime.Today).Date;
                            empleadoClass.OckoGuardarEmpleado(empleado);

                            // insertar Procedure al Nuevo Usuario
                            if (CargoAplicar == "Empleado")
                            {
                                if (Cargo == 1)
                                    storeProClass.GuardaUsuario(5);
                                else if (Cargo == 2)
                                    storeProClass.GuardaUsuario(6);
                                else
                                    storeProClass.GuardaUsuario(1);
                            }
                            else
                            if (CargoAplicar == "Jefe")
                            {
                                if (Cargo == 1)
                                    storeProClass.GuardaUsuario(3);
                                else if (Cargo == 2)
                                    storeProClass.GuardaUsuario(4);
                            }
                            mensaje = "Empleado Contratado";
                            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "confirm", "MensajeGuardado('" + mensaje + "');", true);
                            ClientScript.RegisterStartupScript(this.GetType(), "", " setTimeout('window.location.href = window.location.href', 3000);", true);
                            Guardar.Enabled = false;
                        }
                        catch (Exception ex)
                        {

                            Session["ERROR_RRHH"] = ex;
                            Response.Redirect("RRHH_ERROR.aspx");
                        }
                    }
                    else
                    {
                        mensaje = "Cedula Invalida";
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "confirm", "MensajeError('" + mensaje + "');", true);
                    }
                }
                else
                {
                    mensaje = "Esta Cedula "+txtCedula.Text+"Ya existe !!";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "confirm", "MensajeError('" + mensaje + "');", true);
                }
            }
            else
            {
                mensaje = "No ha seleccionado algunos items";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "confirm", "MensajeError('" + mensaje + "');", true);
            }
        }
    }
}