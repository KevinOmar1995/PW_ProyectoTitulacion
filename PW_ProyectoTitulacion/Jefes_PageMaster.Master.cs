﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaDatos;
using CapaNegocio;
namespace PW_ProyectoTitulacion
{
    public partial class Jefes_PageMaster : System.Web.UI.MasterPage
    {
        public String sesion, Empresa, sesionNombre;
        OCKOEmpleadoUsuario usu = new OCKOEmpleadoUsuario();
        OCKO_TblUsuario tblusuario = new OCKO_TblUsuario();
        OCKOProyecto proyectoClass = new OCKOProyecto();
        OCKO_TblProyecto proyectoTable = new OCKO_TblProyecto();
        //
        OCKO_TblEmpleado empleadoTable = new OCKO_TblEmpleado();
        OCKO_TblEmpresa empresaTable = new OCKO_TblEmpresa();
        OCKOEmpresa empresaClass = new OCKOEmpresa();
        //
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarProyecto();
               
            }
               

            if (Session["Username"] != null)
            {
                tblusuario = usu.OckoBbuscarPorNombre(Session["Username"].ToString());

                empleadoTable = usu.BuscarIdEmpleado(tblusuario.UsuId);
                empresaTable = empresaClass.BuscarIdEmpresa(Convert.ToInt32(empleadoTable.CodEmpresa));
                Empresa = empresaTable.EmpNombre;
                sesion = tblusuario.Usunombre.ToUpper();
                sesionNombre = empleadoTable.EmpPrimerNombre.ToUpper() + " " + empleadoTable.EmpPrimerApellido.ToUpper();
            }
            else
            {
                Response.Redirect("/Login1.aspx");

            }
            
        }
        private void CargarProyecto()
        {
            List<OCKO_TblProyecto> listaProyecto = new List<OCKO_TblProyecto>();
            listaProyecto = proyectoClass.ListaProyecto();
            listaProyecto.Insert(0, new OCKO_TblProyecto() { ProNombre = "--Seleccionar--" });
            ddlPro.DataSource = listaProyecto;
            ddlPro.DataTextField = "ProNombre";
            ddlPro.DataValueField = "ProId";
            ddlPro.DataBind();

        }
        protected void CerrarSesion(object sender, EventArgs e)
        {
            /*String a = Session["Username"].ToString();
            Session["usuario"] = null;
            // Response.Redirect("/Index.aspx");*/
            HttpContext.Current.Session.Abandon();
            HttpContext.Current.Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
            Response.Redirect("/Login1.aspx");
        }

        protected void ddlProyecto_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                int proyecto = Convert.ToInt32(ddlPro.SelectedValue);
                Session["ProyectoId"] = proyecto;
                Response.Redirect("./Jefes_AsigActividades.aspx");
            }
            catch (ArgumentOutOfRangeException ex)
            {

            }


        }
    }
}