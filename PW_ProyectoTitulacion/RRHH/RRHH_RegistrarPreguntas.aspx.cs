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
    
    public partial class RRHH_RegistrarPreguntas : System.Web.UI.Page
    {
        OCKO_TipoEvaluacion evaluacion = new OCKO_TipoEvaluacion();
        OCKO_Preguntas preguntas = new OCKO_Preguntas();
        OCKO_Listar ListarClass = new OCKO_Listar();
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);

            if (!IsPostBack)
            {
                upModal.Update();
                CargarEvaluaciones();
                CargarCategorias();
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

        private void CargarCategorias()
        {
            List<OCKO_TblCategoriaPregunta> listaCategoria = new List<OCKO_TblCategoriaPregunta>();
            listaCategoria = ListarClass.ListarCategoria();
            listaCategoria.Insert(0, new OCKO_TblCategoriaPregunta() { CatNombre = "--Seleccionar--" });
            dllCategoria.DataSource = listaCategoria;
            dllCategoria.DataTextField = "CatNombre";
            dllCategoria.DataValueField = "CatId";
            dllCategoria.DataBind();
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Request.QueryString["e"].ToString() == "t")
                {
                    Response.Redirect("RRHH_PreguntasLista.aspx?e=t&d=f&v=f&a=f");
                }
                else
                if (Request.QueryString["d"].ToString() == "t")
                {
                    Response.Redirect("RRHH_PreguntasLista.aspx?e=f&d=t&v=f&a=f");
                }
                else
                if (Request.QueryString["v"].ToString() == "t")
                {
                    Response.Redirect("RRHH_PreguntasLista.aspx?e=f&d=f&v=t&a=f");
                }
                else
                if (Request.QueryString["a"].ToString() == "t")
                {
                    Response.Redirect("RRHH_PreguntasLista.aspx?e=f&d=f&v=f&a=t");
                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(' Algo Salio Mal" + ex + "');", true);
            }
        }

        protected void dllEvaluacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            int evaluacion1 = Convert.ToInt32(dllEvaluacion.SelectedValue) ;
            Session["EvaluacionList"] = evaluacion1;
        }

        protected void dllCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            int evaluacion1 = Convert.ToInt32(dllCategoria.SelectedValue);
            Session["CategoriaId"] = evaluacion1;
        }
    }

}