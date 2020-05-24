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
        OCKOAsignacion asignacionClass = new OCKOAsignacion();
        OCKO_TblAsignacion asignacionTable = new OCKO_TblAsignacion();
        OCKO_TblAsignacion asignacionTableTecnico = new OCKO_TblAsignacion();
        OCKOSeccion seccionclass = new OCKOSeccion();
        OCKO_TblSeccion seccionTable = new OCKO_TblSeccion();
        OCKOProcesos procesoClass = new OCKOProcesos();
        OCKO_TblProceso procesoTable = new OCKO_TblProceso();
        String id, mensaje;
        protected void Eliminar_Click(object sender, EventArgs e)
        {
            try
            {
                OCKO_TblAsignacion asignacionLocal = asignacionClass.BuscarIdAsignacion(Convert.ToInt32(hdId.Value));
                asignacionClass.EliminarAsignacion(asignacionLocal);
                mensaje = " ¿Esta Seguro de Eliminar  :" + asignacionLocal.AsiDescripcion + "?";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "confirm", "Evaluacion('" + mensaje + "');", true);
            }
            catch (Exception ex)
            {
                Session["ERROR_PM"] = ex;
                Response.Redirect("PM_ERROR.aspx");
            }
        }
        private void FillComboBox()
        {
           
                List<OCKO_TblSeccion> listaSeccion = new List<OCKO_TblSeccion>();
                listaSeccion = seccionclass.ListaSeccion();
                listaSeccion.Insert(0, new OCKO_TblSeccion() { SecNombre = "--Seleccionar--" });

                ddlSeccionEdit.DataSource = listaSeccion;
                ddlSeccionEdit.DataTextField = "SecNombre";
                ddlSeccionEdit.DataValueField = "SecId";
                ddlSeccionEdit.DataBind();

                ddlSeccion.DataSource = listaSeccion;
                ddlSeccion.DataTextField = "SecNombre";
                ddlSeccion.DataValueField = "SecId";
                ddlSeccion.DataBind();

                List<OCKO_TblProceso> listaProcesos = new List<OCKO_TblProceso>();
                listaProcesos = procesoClass.ListaProceso();
                listaProcesos.Insert(0, new OCKO_TblProceso() { ProNombre= "--Seleccionar--" });
                ddlProceso.DataSource = listaProcesos;
                ddlProceso.DataTextField = "ProNombre";
                ddlProceso.DataValueField = "ProId";
                ddlProceso.DataBind();

                ddlProcesoEdit.DataSource = listaProcesos;
                ddlProcesoEdit.DataTextField = "ProNombre";
                ddlProcesoEdit.DataValueField = "ProId";
                ddlProcesoEdit.DataBind();


        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string Descripcion = txtDescripcionCreate.Text;
            bool existe = OCKOAsignacion.BuscarAsignacionxNombre(Descripcion);
            try
            {
                if (!existe)
                {
                    var dateAndTime = DateTime.Now;
                    var date = dateAndTime.Date;

                    if (cbxFuncional.Checked == true)
                    {
                        asignacionTable.AsiDescripcion = Descripcion;
                        asignacionTable.AsiFechaAsignacion = date;
                        asignacionTable.AsiFechaInicio = Convert.ToDateTime(dateFechaInicioCreate.Text).Date;
                        asignacionTable.AsiFechafin = Convert.ToDateTime(dateFechaFinCreate.Text).Date;
                        asignacionTable.AsiEstado = "Pendiente";
                        asignacionTable.CodProceso = int.Parse(ddlProceso.SelectedValue);
                        asignacionTable.CodSeccion = int.Parse(ddlSeccion.SelectedValue);
                        asignacionTable.CodJefe = int.Parse(Session["EncargadoFuncional"].ToString());
                        asignacionTable.AsiAvanceFuncional = int.Parse(Session["ProyectoIdAsignacion"].ToString());

                        asignacionClass.GuardarAsignacion(asignacionTable);
                        mensaje = "Asignación Registrada para cargo FUNCIONAL <br/>";
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "confirm", "Mensaje('" + mensaje + "');", true);
                    }
                    
                    if (cbxtecnico.Checked == true)
                    {
                        asignacionTableTecnico.AsiDescripcion = Descripcion;
                        asignacionTableTecnico.AsiFechaAsignacion = date;
                        asignacionTableTecnico.AsiFechaInicio = Convert.ToDateTime(dateFechaInicioCreate.Text).Date;
                        asignacionTableTecnico.AsiFechafin = Convert.ToDateTime(dateFechaFinCreate.Text).Date;
                        asignacionTableTecnico.AsiEstado = "Pendiente";
                        asignacionTableTecnico.CodProceso = int.Parse(ddlProceso.SelectedValue);
                        asignacionTableTecnico.CodSeccion = int.Parse(ddlSeccion.SelectedValue);
                        asignacionTableTecnico.CodJefe = int.Parse(Session["EncargadoTecnico"].ToString());
                        asignacionTableTecnico.AsiAvanceFuncional = int.Parse(Session["ProyectoIdAsignacion"].ToString());

                        asignacionClass.GuardarAsignacion(asignacionTableTecnico);
                        mensaje = "Asignación Registrada para cargo DESARROLLO ";
                        
                    }
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "confirm", "Mensaje('" + mensaje + "');", true);


                }
                else
                {
                    mensaje = "Modulo ya està Registrado";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "confirm", "Mensaje('" + mensaje + "');", true);
                }
            }
            catch (Exception ex)
            {
                Session["ERROR_PM"] = ex;
                Response.Redirect("PM_ERROR.aspx");
            }
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                OCKO_TblAsignacion asignacionLocalF = asignacionClass.BuscarIdAsignacion(Convert.ToInt32(hdId.Value));
                OCKO_TblAsignacion asignacionLocalT = asignacionClass.BuscarIdAsignacion(Convert.ToInt32(hdId.Value));
                if (cbxFuncionalEdit.Checked == true)
                {
                    asignacionLocalF.AsiDescripcion = txtDescripcionEdit.Text;
                    asignacionLocalF.AsiFechaInicio = Convert.ToDateTime(datefechaInicioEdit.Text).Date;
                    asignacionLocalF.AsiFechafin = Convert.ToDateTime(datefechaFinEdit.Text).Date;
                    asignacionLocalF.CodProceso = int.Parse(ddlProcesoEdit.SelectedValue);
                    asignacionLocalF.CodSeccion = int.Parse(ddlSeccionEdit.SelectedValue);
                    asignacionLocalF.CodJefe = int.Parse(Session["EncargadoFuncional"].ToString());
                    asignacionClass.ActualizarAsignacion(asignacionTable);
                    mensaje = "Tarea Funcional -";
                }

                if (cbxTecnicoEdit.Checked == true)
                {
                    asignacionLocalT.AsiDescripcion = txtDescripcionEdit.Text;
                    asignacionLocalT.AsiFechaInicio = Convert.ToDateTime(datefechaInicioEdit.Text).Date;
                    asignacionLocalT.AsiFechafin = Convert.ToDateTime(datefechaFinEdit.Text).Date;
                    asignacionLocalT.CodProceso = int.Parse(ddlProcesoEdit.SelectedValue);
                    asignacionLocalT.CodSeccion = int.Parse(ddlSeccionEdit.SelectedValue);
                    asignacionLocalT.CodJefe = int.Parse(Session["EncargadoFuncional"].ToString());
                    asignacionClass.ActualizarAsignacion(asignacionTable);
                    mensaje += " Tarea Tècnica  ";
                }
                mensaje += " Editada Correctamente";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "confirm", "Mensaje('" + mensaje + "');", true);

            }
            catch (Exception ex)
            {
                Session["ERROR_PM"] = ex;
                Response.Redirect("PM_ERROR.aspx");
            }
        }


        protected void gvrAsignacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlBotones.Visible = true;
            try
            {
                GridViewRow row = gvrAsignacion.SelectedRow;
                id = row.Cells[1].Text;
                hdId.Value = id;

                OCKO_TblAsignacion asignacionLocal = asignacionClass.BuscarIdAsignacion(Convert.ToInt32(hdId.Value));
                txtDescripcionEdit.Text = asignacionLocal.AsiDescripcion;
                datefechaInicioEdit.Text = asignacionLocal.AsiFechaInicio.ToString();
                datefechaFinEdit.Text = asignacionLocal.AsiFechafin.ToString();
                ddlSeccionEdit.SelectedValue = asignacionLocal.CodSeccion.ToString();
                ddlProcesoEdit.SelectedValue = asignacionLocal.CodProceso.ToString();

            }
            catch (Exception ex)
            {
                Session["ERROR_PM"] = ex;
                Response.Redirect("PM_ERROR.aspx");

            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetNombresAsp();
                FillComboBox();
            }
            GetNombresAsp();
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