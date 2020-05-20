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
    public partial class RRHH_GrupoConcepto : System.Web.UI.Page
    {
        OCKOGrupoConceptos grupoConceptoClass = new OCKOGrupoConceptos();
        OCKO_TblGrupoConceptos grupoConceptoTable = new OCKO_TblGrupoConceptos();
        String mensaje;
        public int Suma;
        int SumaVariada;
        protected void Page_Load(object sender, EventArgs e)
        {
            Suma = OCKOGrupoConceptos.SumaPorcentaje();
           
            if (!IsPostBack)
            {

                Suma = OCKOGrupoConceptos.SumaPorcentaje();
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
                OCKO_TblGrupoConceptos grupoPeriodo = grupoConceptoClass.BuscarIdGrupoCategoria(Convert.ToInt32(hdId.Value));
                txtNombreEdit.Text = grupoPeriodo.GruNombre;
                txtMinimoEdit.Text = Convert.ToString( grupoPeriodo.GruMinimo);
                txtPorcentajeEdit.Text = Convert.ToString(grupoPeriodo.GruPeso);
            }
            catch (Exception ex)
            {
                mensaje = "Algo Salio Mal" + ex;
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "confirm", "Mensaje('" + mensaje + "');", true);
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string GrupoConcepto = txtnombreCreate.Text;
            bool existe = OCKOGrupoConceptos.BuscarGrupoCategoria(GrupoConcepto);
            try
            {
                if (!existe)
                {

                    grupoConceptoTable.GruNombre = GrupoConcepto;
                    grupoConceptoTable.GruMinimo = Convert.ToInt32(txtMinimo.Text);
                    grupoConceptoTable.GruPeso   = Convert.ToInt32(txtPorcentaje.Text);
                    grupoConceptoClass.GuardarGrupoCategoria(grupoConceptoTable);
                    mensaje = "Grupo Registrado";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "confirm", "Mensaje('" + mensaje + "');", true);
                }
            }
            catch (Exception ex)
            {
                mensaje = "Algo Salio Mal " + ex;
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "confirm", "Mensaje('" + mensaje + "');", true);
            }
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                OCKO_TblGrupoConceptos GrupoPeriodoLocal = grupoConceptoClass.BuscarIdGrupoCategoria(Convert.ToInt32(hdId.Value));
                GrupoPeriodoLocal.GruNombre = txtNombreEdit.Text;
                GrupoPeriodoLocal.GruMinimo = Convert.ToInt32( txtMinimoEdit.Text);
                GrupoPeriodoLocal.GruPeso   = Convert.ToInt32(txtPorcentajeEdit.Text);

                grupoConceptoClass.ActualizarGrupoCategoria(GrupoPeriodoLocal);
                mensaje = "Registro Editado";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "confirm", "Mensaje('" + mensaje + "');", true);
            }
            catch (Exception ex)
            {
                mensaje = "Algo salio mal " + ex;
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "confirm", "Mensaje('" + mensaje + "');", true);
            }
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            //some code
            TextBox IdPorcentaje = GridView1.Rows[e.RowIndex].Cells[1].Controls[0] as TextBox;
            TextBox Porcentaje = GridView1.Rows[e.RowIndex].Cells[4].Controls[0] as TextBox;
            BindData();
            int SumaLocal = Convert.ToInt32(Session["SumaVariada"].ToString()) + Convert.ToInt32(Porcentaje.Text);

            int IdGrupoOld = Convert.ToInt32(Session["IdGrupoOld"].ToString());
            int GruPesoOld = Convert.ToInt32(Session["IdPorcentajeOld"].ToString());
            Session["GruId"] = "";
            Session["GruPeso"] = "";
            if (SumaLocal <= 100)
            {
               // OCKO_TblGrupoConceptos GrupoPeriodoLocal = grupoConceptoClass.BuscarIdGrupoCategoria(Convert.ToInt32(IdPorcentaje.Text));
               // GrupoPeriodoLocal.GruPeso = Convert.ToInt32(Porcentaje.Text);
                //grupoConceptoClass.ActualizarGrupoCategoria(GrupoPeriodoLocal);
                Session["GruId"] = IdPorcentaje.Text;
                Session["GruPeso"] = IdPorcentaje.Text;
                SqlDataSource1.Update();
                Suma = SumaLocal;
            }
            else
            {
                mensaje = "La Suma del Porcentaje es superio a 100";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "confirm", "Mensaje('" + mensaje + "');", true);
                Session["GruId"] = IdGrupoOld;
                Session["GruPeso"] = GruPesoOld;
                SqlDataSource1.Update();
                Suma = OCKOGrupoConceptos.SumaPorcentaje();

            }

        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            Session["IdGrupoOld"]= Convert.ToInt32(GridView1.Rows[e.NewEditIndex].Cells[1].Text);
            Session["IdPorcentajeOld"] = Convert.ToInt32(GridView1.Rows[e.NewEditIndex].Cells[4].Text);
            int id = Convert.ToInt32(GridView1.Rows[e.NewEditIndex].Cells[4].Text);
            Session["SumaVariada"] = Suma - id;
            BindData();
        }

        private void BindData()
        {
            GridView1.DataSource = Session["TaskTable"];
            
            GridView1.DataBind();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {

        }
    }
}