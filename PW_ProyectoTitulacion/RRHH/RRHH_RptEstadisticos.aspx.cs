using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Linq;
using System.Data.SqlClient;
using CapaDatos;
using CapaNegocio;
namespace PW_ProyectoTitulacion.RRHH
{
    public partial class RRHH_RptEstadisticos : System.Web.UI.Page
    {
        OCKO_StoreProcedureAction procedureClass = new OCKO_StoreProcedureAction();
        SqlCommand cmd;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected string ObtenerDatos()
        {
            String Strdatos;
            DataTable Datos = new DataTable();
            //Columna de los datos 
            //Datos.Columns.Add(new DataColumn("Tarea", typeof(string)));
            //Datos.Columns.Add(new DataColumn("Evaluaciones", typeof(string)));
            ////Datos de las Columnas(Mostra )
            //Datos.Rows.Add(new object[] { "Eficinecia", 11 });
            //Datos.Rows.Add(new object[] { "Liderazgo", 2 });
            //Datos.Rows.Add(new object[] { "Responsabilidad", 3 });
            //Datos.Rows.Add(new object[] { "Deficiencia", 4 });
            //SqlConnection conexion = new SqlConnection(@"Data Source=LAPTOP-04FTIL89\SQLEXPRESS;Initial Catalog=OCKO_EvaluacionPersonal;Integrated Security=True");
            SqlCommand cmd = new SqlCommand();
            //cmd.CommandText = "OCKO_TotalesEvaluacion";
            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@evaluacionId", 1);
            //cmd.Connection = conexion;
            //conexion.Open();
            cmd = procedureClass.TotalesEvaluacion(1);
            Datos.Load(cmd.ExecuteReader());

            Strdatos = "[['Tarea', 'Porcentaje'],";
            foreach (DataRow dr in Datos.Rows)
            {
                Strdatos = Strdatos + "[";
                Strdatos = Strdatos + "'" + dr[0] + "'" + "," + dr[1];
                Strdatos = Strdatos + "],";
            }
            Strdatos = Strdatos + "]";

            return Strdatos;
        }
    }
}