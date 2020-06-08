using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaDatos;
using CapaNegocio;
namespace PW_ProyectoTitulacion.PM
{
    public partial class PM_StartEvaluacion : System.Web.UI.Page
    {
        String mensaje;
        OCKO_StoreProcedureAction spActions = new OCKO_StoreProcedureAction();
        OCKOPeriodos ClassPeriodo = new OCKOPeriodos();
        OCKORespuestas ClassRespuestas = new OCKORespuestas();
        OCKO_TblRespuestas TableRespuestas = new OCKO_TblRespuestas();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ////////////////////////////////////////////////////////////////////////////////
                if (Request.QueryString["evaluacion"].ToString() == "" &&
                    Request.QueryString["empleado"].ToString() == "" &&
                    Request.QueryString["Periodo"].ToString() == "")
                {
                    mensaje = "No se ha seleccionado una Evaluaciòn o Empleado";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "confirm", "MensajeError('" + mensaje + "');", true);
                }
                else
                {
                    Session["NoEvaluacion"] = Request.QueryString["evaluacion"].ToString();
                    Session["IdEmpleado"] = Request.QueryString["empleado"].ToString();
                    Session["IdPeriodo"] = Request.QueryString["Periodo"].ToString();
                }
                ///////////////////////////////////////////////////////////////////////////////////
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {

            ProcesoGuardar();
            int sigCategoria = Convert.ToInt32(Session["Categoria"]);
            int siguiente = sigCategoria + 1;
            if (siguiente == 3)
                siguiente = 6;
            Session["Categoria"] = siguiente;

            String Strperiodo = "Periodo=" + Session["IdPeriodo"] + "&";
            String Ruta = Strperiodo + "evaluacion=" + Session["NoEvaluacion"] + "&empleado=" + Session["IdEmpleado"];
            if (siguiente == 7)
                Response.Redirect("./PM_FinEvaluacion.aspx");
            else
                Response.Redirect("./PM_StartEvaluacion.aspx?" + Ruta);
        }

        public void ProcesoGuardar()
        {
            int evaluacion = Convert.ToInt32(Session["NoEvaluacion"].ToString());
            int Empleado = Convert.ToInt32(Session["IdEmpleado"].ToString());
            int Periodo = Convert.ToInt32(Session["IdPeriodo"].ToString());
            decimal resultado = 0;
            ObtenRespuestas();
            resultado = spActions.puntuacion(evaluacion, Empleado);
            spActions.ActualizaPuntuacion(resultado, evaluacion, Empleado, Periodo);
        }

        public void ObtenRespuestas()
        {
            int loop1, total1;
            int Puntos;
            decimal PesoAbsoluto;
            NameValueCollection coll;
            //Se cargan todas la variables del form en la variable NameValueCollection
            coll = Request.Form;
            //Se guardan todos los nombres del form dentro del array
            String[] arr1 = coll.AllKeys;
            //Se recorre el array completo
            for (loop1 = 6; loop1 < arr1.Length - 8; loop1++)
            {
                int empleado = Convert.ToInt32(Session["IdEmpleado"]);
                try
                {
                    //Response.Write(arr1[loop1]);
                    //Response.Write("<br/>");
                    if (arr1[loop1] != null)
                    {
                        int pregunta = Convert.ToInt32(arr1[loop1]);
                        int respuesta = Convert.ToInt32(Request.Form[arr1[loop1]]);
                        TableRespuestas = ClassRespuestas.BuscarIdRespuestas(respuesta);
                        int examen = Convert.ToInt32(Session["NoEvaluacion"].ToString());
                        Puntos = Convert.ToInt32(TableRespuestas.resPuntos);
                        total1 = Puntos * 50;
                        PesoAbsoluto = (decimal)total1 / (decimal)100;

                        OCKO_StoreProcedureAction evaluacion = new OCKO_StoreProcedureAction();
                        evaluacion.GuardaRespuestas(examen, pregunta, respuesta, empleado, PesoAbsoluto);
                    }
                }
                catch (Exception ex)
                {

                    Session["ERROR_PM"] = ex;
                    Response.Redirect("PM_ERROR.aspx");
                }
            }
        }
    }
}