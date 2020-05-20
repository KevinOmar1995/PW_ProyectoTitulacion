using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class OCKO_ConexionSP
    {
        public SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-04FTIL89\SQLEXPRESS;Initial Catalog=OCKO_EvaluacionPersonal;Integrated Security=True");

        public SqlConnection AbrirConexion()
        {
            if (con.State == ConnectionState.Closed)
                con.Open();
            return con;

        }

        public SqlConnection CerrarConexion()
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            return con;

        }
    }
}
