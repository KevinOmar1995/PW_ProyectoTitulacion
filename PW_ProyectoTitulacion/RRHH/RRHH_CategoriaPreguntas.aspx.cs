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
    public partial class RRHH_CategoriaPreguntas : System.Web.UI.Page
    {
        OCKOCategoria categoriaClass = new OCKOCategoria();
        OCKOGrupoConceptos grupoConceptosClass = new OCKOGrupoConceptos();
        OCKO_TblCategoriaPregunta categoriaPre = new OCKO_TblCategoriaPregunta();
        string mensaje;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarGrupoConceptos();
                CargarGrupoConceptosEdit();
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
 
            string categoria = txtNombreCreate.Text;
            bool existe = OCKOPreguntas.BuscarPregunta(categoria);
            try
            {
                if (!existe)
                {
                    categoriaPre.CatNombre = categoria;
                    categoriaPre.CatDescripcion = txtDescripcionCreate.Text;
                    categoriaPre.CodGrupoConceptos = int.Parse(dllGrupoConcepto.SelectedValue);
                    categoriaClass.GuardarCategoria(categoriaPre);
                    mensaje = "Categoria Registrada";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "confirm", "Evaluacion('" + mensaje + "');", true);
                }
            }
            catch (Exception ex)
            {
                mensaje = "Algo Salio Mal "+ex;
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "confirm", "Evaluacion('" + mensaje + "');", true);
            }
        }

        private void CargarGrupoConceptos()
        {
            List<OCKO_TblGrupoConceptos> ListaGrupo = new List<OCKO_TblGrupoConceptos>();
            ListaGrupo = grupoConceptosClass.ListarGrupoConcepto();
            ListaGrupo.Insert(0, new OCKO_TblGrupoConceptos() { GruNombre = "--Seleccionar--" });
            dllGrupoConcepto.DataSource = ListaGrupo;
            dllGrupoConcepto.DataTextField = "GruNombre";
            dllGrupoConcepto.DataValueField = "GruId";
            dllGrupoConcepto.DataBind();
        }
        private void CargarGrupoConceptosEdit()
        {
            List<OCKO_TblGrupoConceptos> ListaGrupo = new List<OCKO_TblGrupoConceptos>();
            ListaGrupo = grupoConceptosClass.ListarGrupoConcepto();
            ListaGrupo.Insert(0, new OCKO_TblGrupoConceptos() { GruNombre = "--Seleccionar--" });
            dllGrupoConceptoEdit.DataSource = ListaGrupo;
            dllGrupoConceptoEdit.DataTextField = "GruNombre";
            dllGrupoConceptoEdit.DataValueField = "GruId";
            dllGrupoConceptoEdit.DataBind();
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                OCKO_TblCategoriaPregunta categoriaLocal = categoriaClass.BuscarIdCategoria(Convert.ToInt32(hdId.Value));
                categoriaLocal.CatNombre = txtCategoriaEdit.Text;
                categoriaLocal.CatDescripcion = txtDescripcionEdit.Text;
                categoriaLocal.CodGrupoConceptos = int.Parse(dllGrupoConceptoEdit.SelectedValue); 
                categoriaClass.ActualizarCategoria(categoriaLocal);
                mensaje = "Registro Editado";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "confirm", "Evaluacion('" + mensaje + "');", true);
            }
            catch (Exception ex)
            {
                mensaje = "Algo salio mal "+ex;
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "confirm", "Evaluacion('" + mensaje + "');", true);
            }
            
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id;
            pnlBotones.Visible = true;
            try
            {
                GridViewRow row = GridView1.SelectedRow;
                id = row.Cells[1].Text;
                hdId.Value = id;
                OCKO_TblCategoriaPregunta cat = categoriaClass.BuscarIdCategoria(Convert.ToInt32(hdId.Value));
                txtCategoriaEdit.Text = cat.CatNombre;
                txtDescripcionEdit.Text = cat.CatDescripcion;
                dllGrupoConceptoEdit.SelectedIndex = Convert.ToInt32(cat.CodGrupoConceptos);
                dllGrupoConceptoEdit.Items.FindByValue("Desempeño").Selected = true;
            }
            catch (Exception ex)
            {
                mensaje = "Algo salio mal " + ex;
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "confirm", "Mensaje('" + mensaje + "');", true);
            }
        }

        protected void BtnEliminar_Click(object sender, EventArgs e)
        {
             try
             {
                OCKO_TblCategoriaPregunta categoriaLocal = categoriaClass.BuscarIdCategoria(Convert.ToInt32(hdId.Value));
                categoriaClass.EliminarCategoria(categoriaLocal);
                mensaje = " ¿Esta Seguro de Eliminar  :" + categoriaLocal.CatNombre + "?"; 
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "confirm", "Evaluacion('" + mensaje + "');", true);
             }
            catch (Exception ex)
            {
                mensaje = "Algo salio mal " + ex;
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "confirm", "Mensaje('" + mensaje + "');", true);
            }
        }

        protected void dllGrupoConcepto_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}