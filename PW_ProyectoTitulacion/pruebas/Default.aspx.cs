using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Configuration;
using System.Collections.Specialized;
using CapaDatos;
using CapaNegocio;

namespace PW_ProyectoTitulacion.pruebas
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Session["tiempo"] = 120;// 120 equivale 2 minutos 
                if (Convert.ToInt32(Session["NoExamen"].ToString()) > 3)
                {
                    Session["tiempo"] = 5;
                    Response.Redirect("./final.aspx");
                }
            }
        }

        protected void Reloj_Tick(object sender, EventArgs e)
        {
            if (Convert.ToInt32(Session["tiempo"]) != 0)
            {
                decimal s = Convert.ToDecimal(Session["tiempo"]);
                lblReloj.Text = this.contador(s);
            }
            else
            {

            }
        }
        public string contador(decimal s)
        {
            Examen ex = new Examen();
            decimal seg = s;
            string segundos = "00";
            string minutos = "00";
            if (seg <= 59)
            {
                segundos = Convert.ToString(seg);
                segundos = ex.agregaCero(segundos);
            }
            else if (seg > 59)
            {
                segundos = Convert.ToString(seg % 60);
                segundos = ex.agregaCero(segundos);
                minutos = Convert.ToString(Math.Floor(seg / 60));
            }
            seg--;
            HttpContext.Current.Session["tiempo"] = seg;
            String res = minutos + ":" + segundos;
            return res;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            proceso();
            int sigexamen = Convert.ToInt32(Session["NoExamen"]);
            int siguiente = sigexamen + 1;
            Session["NoExamen"] = siguiente;
            Response.Redirect("./Default.aspx");
        }

        public void proceso()
        {
            Examen ex = new Examen();
            int examen = Convert.ToInt32(Session["NoExamen"].ToString());
            int alumno = Convert.ToInt32(Session["idAlumno"]);
            decimal resultado = 0;
            GuardaExamen(examen, alumno);
            ObtenRespuestas();
            resultado = puntuacion(examen, alumno);
            ActualizaPuntuacion(resultado, examen, alumno);
        }
        //descartado
        public void GuardaExamen(int examen, int alumno)
        {
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["ExamenTest"].ToString()))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "spInsertaExamen";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@examen", examen);
                cmd.Parameters.AddWithValue("@alumno", alumno);
                cmd.Parameters.AddWithValue("@fecha", DateTime.Now);
                cmd.ExecuteNonQuery();
            }
        }
        public void GuardaRespuestas(int pregunta, int respuesta, int alumno, int examen)
        {
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["ExamenTest"].ToString()))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "spInsertaRespuestas";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cn;
                cmd.Parameters.AddWithValue("@examen", examen);
                cmd.Parameters.AddWithValue("@pregunta", pregunta);
                cmd.Parameters.AddWithValue("@respuesta", respuesta);
                cmd.Parameters.AddWithValue("@alumno", alumno);
                cmd.ExecuteNonQuery();
            }
        }
        public decimal puntuacion(int examen, int alumno)
        {
            decimal resultado = 0;
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["ExamenTest"].ToString()))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "spObtenerPuntuacion";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@alumno", alumno);
                cmd.Parameters.AddWithValue("@examen", examen);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        resultado = Convert.ToDecimal(reader.GetValue(0) is DBNull ? 0 : reader.GetValue(0));
                    }
                }
                else
                {
                    resultado = 0;
                }

            }
            return resultado;
        }
        public void ActualizaPuntuacion(decimal resultado, int examen, int alumno)
        {
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["ExamenTest"].ToString()))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "OCKO_ActualizaExamen";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@examen", examen);
                cmd.Parameters.AddWithValue("@alumno", alumno);
                cmd.Parameters.AddWithValue("@resultado", resultado);
                cmd.ExecuteNonQuery();
            }
        }

        public void ObtenRespuestas()
        {
            int loop1;
            NameValueCollection coll;
            //Se cargan todas la variables del form en la variable NameValueCollection
            coll = Request.Form;
            //Se guardan todos los nombres del form dentro del array
            String[] arr1 = coll.AllKeys;
            //Se recorre el array completo
            for (loop1 = 0; loop1 < arr1.Length; loop1++)
            {
                int alumno = Convert.ToInt32(Session["IdAlumno"]);
                try
                {
                    //Response.Write(arr1[loop1]);
                    //Response.Write("<br/>");
                    int pregunta = Convert.ToInt32(arr1[loop1]);
                    int respuesta = Convert.ToInt32(Request.Form[arr1[loop1]]);
                    int examen = Convert.ToInt32(Session["NoExamen"].ToString());
                    Examen exa = new Examen();
                    GuardaRespuestas(pregunta, respuesta, alumno, examen);
                }
                catch (Exception ex)
                {

                }
            }
        }

    }
}