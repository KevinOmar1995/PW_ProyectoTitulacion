using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaDatos;
using CapaNegocio;
using System.Collections.Specialized;
using CapaDatos;
using CapaNegocio;

namespace PW_ProyectoTitulacion.Empleados
{
    public partial class Empleado_InicioEvaluacion : System.Web.UI.Page
    {
        OCKO_StoreProcedureAction spActions = new OCKO_StoreProcedureAction();
        OCKO_Preguntas preguntasClass = new OCKO_Preguntas();
        OCKOCategoria categoriaClass = new OCKOCategoria();
        OCKO_TblPreguntas preguntasTable = new OCKO_TblPreguntas();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            ProcesoGuardar();
        }

        public void ProcesoGuardar()
        {
            int evaluacion = Convert.ToInt32(Session["NoEvaluacion"].ToString());
            int Empleado = Convert.ToInt32(Session["IdEmpleado"].ToString());
            decimal resultado ;
            ObtenRespuestas();
            resultado = spActions.puntuacion(evaluacion, Empleado);
            spActions.ActualizaPuntuacion(resultado, evaluacion, Empleado, 0);
            Response.Redirect("Empleado_EvaluacionRealizadas.aspx");
        }

        public void ObtenRespuestas()
        {
            int loop1;
            decimal PesoAbsoluto;
            NameValueCollection coll;
            //Se cargan todas la variables del form en la variable NameValueCollection
            coll = Request.Form;
            //Se guardan todos los nombres del form dentro del array
            String[] arr1 = coll.AllKeys;
            //Se recorre el array completo
            for (loop1 = 6; loop1 < arr1.Length-1; loop1++)
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
                        //multiplicar por el porcentaje de los objetivos de la evaluacion
                        int examen = Convert.ToInt32(Session["NoEvaluacion"].ToString());
                        //preguntasTable = preguntasClass.BuscarCategoriaiD(pregunta, examen);
                        //int Porcentaje = categoriaClass.BuscarIdCategoriaPercent(Convert.ToInt32(preguntasTable.CodCategoria));
                        PesoAbsoluto = ((pregunta * 50) / 100);

                        OCKO_StoreProcedureAction evaluacion = new OCKO_StoreProcedureAction();
                        evaluacion.GuardaRespuestas(examen, pregunta, respuesta, empleado, PesoAbsoluto);
                    }
                    
                }
                catch (Exception ex)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(' Algo Salio Mal" + ex + "');", true);
                }
            }
        }
    }
}