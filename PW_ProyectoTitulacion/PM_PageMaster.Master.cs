using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaDatos;
using CapaNegocio;
namespace PW_ProyectoTitulacion
{
    public partial class PM_PageMaster : System.Web.UI.MasterPage
    {
        public String sesion;
        OCKOEmpleadoUsuario usu = new OCKOEmpleadoUsuario();
        OCKO_TblUsuario tblusuario = new OCKO_TblUsuario();
        OCKOModulos moduloClass = new OCKOModulos();
        OCKOProyecto proyectoClass = new OCKOProyecto();
        OCKOProyecto proyectoClass2 = new OCKOProyecto();
        OCKOFases faseClass = new OCKOFases();
        OCKOListar listarClass = new OCKOListar();
        OCKOListar listarClassT = new OCKOListar();
        OCKOAsignacion asignacionClass = new OCKOAsignacion();
        OCKO_TblAsignacion asignacionTable = new OCKO_TblAsignacion();
        OCKO_TblAsignacion asignacionTableT = new OCKO_TblAsignacion();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarDDL();

            }
            if (Session["Username"] != null)
            {
                tblusuario = usu.OckoBbuscarPorNombre(Session["Username"].ToString());

                sesion = tblusuario.Usunombre.ToUpper();
                
            }
            else
            {
                Response.Redirect("/Login1.aspx");

            }
        }

        protected void CerrarSesion_Click(object sender, EventArgs e)
        {
            HttpContext.Current.Session.Abandon();
            HttpContext.Current.Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
            Response.Redirect("/Login1.aspx");
        }
        private void CargarDDL()
        {
            List<OCKO_TblProyecto> listaProyecto = new List<OCKO_TblProyecto>();
            listaProyecto = proyectoClass.ListaProyecto();
            listaProyecto.Insert(0, new OCKO_TblProyecto() { ProNombre = "--Seleccionar--" });
            ddlProyecto.DataSource = listaProyecto;
            ddlProyecto.DataTextField = "ProNombre";
            ddlProyecto.DataValueField = "ProId";
            ddlProyecto.DataBind();

            List<OCKO_TblModulos> listaModulos = new List<OCKO_TblModulos>();
            listaModulos = moduloClass.ListaModulos();
            listaModulos.Insert(0, new OCKO_TblModulos() { ModNombre = "--Seleccionar--" });
            ddlModulo.DataSource = listaModulos;
            ddlModulo.DataTextField = "ModNombre";
            ddlModulo.DataValueField = "ModId";
            ddlModulo.DataBind();

            List<OCKO_TblFase> listaFase = new List<OCKO_TblFase>();
            listaFase = faseClass.ListaFases();
            listaFase.Insert(0, new OCKO_TblFase() { FasNombre= "--Seleccionar--" });
            ddlFase.DataSource = listaFase;
            ddlFase.DataTextField = "FasNombre";
            ddlFase.DataValueField = "FasId";
            ddlFase.DataBind();


            List<OCKO_TblEmpleado> ListEmpleaod = new List<OCKO_TblEmpleado>();
            ListEmpleaod = listarClass.ListarJefeInmediato(2);
            ListEmpleaod.Insert(0, new OCKO_TblEmpleado() { EmpPrimerNombre = "--Seleccionar--" });
            ddlFuncional.DataSource = ListEmpleaod;
            ddlFuncional.DataTextField = "EmpPrimerNombre";
            ddlFuncional.DataValueField = "EmpId";
            ddlFuncional.DataBind();

            List<OCKO_TblEmpleado> ListEmpleadoT = new List<OCKO_TblEmpleado>();
            ListEmpleadoT = listarClassT.ListarJefeInmediato(1);
            ListEmpleadoT.Insert(0, new OCKO_TblEmpleado() { EmpPrimerNombre = "--Seleccionar--" });
            ddlTecnico.DataSource = ListEmpleadoT;
            ddlTecnico.DataTextField = "EmpPrimerNombre";
            ddlTecnico.DataValueField = "EmpId";
            ddlTecnico.DataBind();

            List<OCKO_TblProyecto> listaProyectoInicio = new List<OCKO_TblProyecto>();
            listaProyectoInicio = proyectoClass2.ListaProyecto();
            listaProyectoInicio.Insert(0, new OCKO_TblProyecto() { ProNombre = "--Seleccionar--" });
            ddlProyectoInicio.DataSource = listaProyecto;
            ddlProyectoInicio.DataTextField = "ProNombre";
            ddlProyectoInicio.DataValueField = "ProId";
            ddlProyectoInicio.DataBind();
        }
     
        protected void ddlProyecto_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlModulo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            int proyectoId = Convert.ToInt32(ddlProyecto.SelectedValue);
            int moduloId = Convert.ToInt32(ddlModulo.SelectedValue);
            Session["ProyectoId"] = proyectoId;
            Session["ModuloId"] = moduloId;
            Response.Redirect("./PM_Seccion.aspx");
        }

        protected void GuardarFase_Click(object sender, EventArgs e)
        {
            int faseId = Convert.ToInt32(ddlFase.SelectedValue);
            Session["FaseId"] = faseId;
            Response.Redirect("./PM_Procesos.aspx");
        }

        protected void Asignacion_Click(object sender, EventArgs e)
        {
            int proyectoId = int.Parse(ddlProyectoInicio.SelectedValue);
            int encargadoFuncional = int.Parse(ddlFuncional.SelectedValue);
            int encargadoTecnico = int.Parse(ddlTecnico.SelectedValue);
            Session["ProyectoIdAsignacion"] = proyectoId;
            Session["EncargadoFuncional"] = encargadoFuncional;
            Session["EncargadoTecnico"] = encargadoTecnico;
            Response.Redirect("./PM_IniciarProyecto.aspx");
        }

        protected void NewProject_Click(object sender, EventArgs e)
        {
            var dateAndTime = DateTime.Now;
            var date = dateAndTime.Date;

            int proyectoId = int.Parse(ddlProyectoInicio.SelectedValue);
            int encargadoFuncional = int.Parse(ddlFuncional.SelectedValue);
            int encargadoTecnico = int.Parse(ddlTecnico.SelectedValue);
            Session["ProyectoIdAsignacion"] = proyectoId;
            Session["EncargadoFuncional"] = encargadoFuncional;
            Session["EncargadoTecnico"] = encargadoTecnico;

            asignacionTable.CodJefe = encargadoFuncional;
            asignacionTable.CodSeccion = 7;
            asignacionTable.AsiFechaAsignacion = date;
            asignacionClass.GuardarAsignacion(asignacionTable);

            asignacionTableT.CodJefe = encargadoTecnico;
            asignacionTableT.CodSeccion = 7;
            asignacionTableT.AsiFechaAsignacion = date;
            asignacionClass.GuardarAsignacion(asignacionTableT);

            Response.Redirect("./PM_IniciarProyecto.aspx");


        }
    }
}