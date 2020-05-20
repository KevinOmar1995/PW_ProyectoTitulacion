using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaDatos;
using CapaNegocio;

namespace PW_ProyectoTitulacion
{
    public partial class RRHH_EmployeeList : System.Web.UI.Page
    {
        OCKO_Listar ockoListar = new OCKO_Listar();
        OCKOCargo cargo = new OCKOCargo();
        OCKOEmpleadoUsuario empleado = new OCKOEmpleadoUsuario();
        String id;
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);

            if (!IsPostBack)
            {
                upModal.Update();
                CargarCargos();

            }
            //GrvCliente.DataSource = ockoListar.ListarEmpleados();
            //GrvCliente.DataBind();
        }
        protected void SubmitBtn_Click(object sender, EventArgs e)
        {

        }

        private void CargarCargos()
        {
            List<OCKO_TblCargo> ListaCargos = new List<OCKO_TblCargo>();
            ListaCargos = cargo.listaCargos();
            ListaCargos.Insert(0, new OCKO_TblCargo() { CarNombre = "--Seleccionar--" });
            dllCargo.DataSource = ListaCargos;
            dllCargo.DataTextField = "CarNombre";
            dllCargo.DataValueField = "CarId";
            dllCargo.DataBind();
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            OCKO_TblEmpleado emple = empleado.BuscarIdEmpleado(Convert.ToInt32(hdId.Value));
            emple.EmpCedula = txetCargo.Text;
            empleado.ActualizarEmpleado(emple);
            Response.Redirect("RRHH_EmployeeList.aspx");
        }

        protected void GrvCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            try
            {
                GridViewRow row = GrvCliente.SelectedRow;
                id = row.Cells[1].Text;
                hdId.Value = id;
                OCKO_TblEmpleado or = empleado.BuscarIdEmpleado(Convert.ToInt32(hdId.Value));
                txetCargo.Text = or.EmpCedula;
            }
            catch
            {

            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            /*Tbl_Cliente cli = new Tbl_Cliente();
            cli.Cli_Estado = Convert.ToChar("A");
            cli.Cli_Cargo = txtCargo.Text.ToUpper();
            cli.Cli_Per_Id = Convert.ToInt32(txtPersona.Text);
            con.guardarCliente(cli);
            Response.Write("<script>alert('Se A Ingresado Correctamente');window.location.href='ListaCliente.aspx';</script>");
            */
        }

        protected void SubmitBtn_Click1(object sender, EventArgs e)
        {
           /* Tbl_Cliente cliente =
            con.buscarPorIdCliente(Convert.ToInt32(hdId.Value));
            con.eliminarCliente(cliente);
            Response.Redirect("ListaCliente.aspx");
            */
        }

        protected void BtnFiltro_Click(object sender, EventArgs e)
        {
            
            //Response.Redirect("RRHH_EmpleadosLista.aspx");
        }
       
        protected void dllCargo_SelectedIndexChanged(object sender, EventArgs e)
        {
            int evaluacion1 = Convert.ToInt32(dllCargo.SelectedValue);
            Session["CardId"] = evaluacion1;
        }
    }
}