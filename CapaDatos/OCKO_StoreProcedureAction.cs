using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace CapaDatos
{
    public class OCKO_StoreProcedureAction
    {
        private OCKO_ConexionSP con = new OCKO_ConexionSP();
        SqlCommand comando = new SqlCommand();

        //Inicio agregado QR 
        public void GuardaRespuestas(int evaluacion, int pregunta, int respuesta, int empleado,decimal PesoAbsoluto)
        {

            comando.Connection = con.AbrirConexion();
            comando.CommandText = "OCKO_InsertaRespuestas";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@evaluacion", evaluacion);
            comando.Parameters.AddWithValue("@pregunta", pregunta);
            comando.Parameters.AddWithValue("@respuesta", respuesta);
            comando.Parameters.AddWithValue("@alumno", empleado);
            comando.Parameters.AddWithValue("@pesoAbsoluto", PesoAbsoluto); 
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            con.CerrarConexion();
        }

        public void ActualizarCompetencias(decimal desempeno, decimal actitud, decimal habilidad, int evaluacion, int codEmpleado)
        {

            comando.Connection = con.AbrirConexion();
            comando.CommandText = "OCKO_ActualizarCompeteneicas";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@desempeno", desempeno);
            comando.Parameters.AddWithValue("@actitud", actitud);
            comando.Parameters.AddWithValue("@habilidades", habilidad);
            comando.Parameters.AddWithValue("@evaluacion", evaluacion);
            comando.Parameters.AddWithValue("@empleado", codEmpleado);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            con.CerrarConexion();
        }

        public decimal puntuacion(int evaluacion, int empleado)
        {
            //int [] resultado ;
            decimal resultado=0;
            SqlCommand comando = new SqlCommand();
            comando.Connection = con.AbrirConexion();
            comando.CommandText = "OCKO_ObtenerPuntuacion";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@empleado", empleado);
            comando.Parameters.AddWithValue("@evaluacion", evaluacion);
            SqlDataReader reader = comando.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    //Desempeño
                    if (reader.GetValue(1).Equals(1))
                    {
                        resultado += Convert.ToDecimal(reader.GetValue(0) is DBNull ? 0 : reader.GetValue(0));
                        this.ActualizarCompetencias(Convert.ToDecimal(reader.GetValue(0)), 0, 0, evaluacion, empleado);
                    }
                    //habilidades
                    if (reader.GetValue(1).Equals(2))
                    {
                        resultado += Convert.ToDecimal(reader.GetValue(0) is DBNull ? 0 : reader.GetValue(0));
                        this.ActualizarCompetencias(0, 0, Convert.ToDecimal(reader.GetValue(0)), evaluacion, empleado);
                    }
                    //Actitud
                    if (reader.GetValue(1).Equals(3))
                    {
                        resultado += Convert.ToDecimal(reader.GetValue(0) is DBNull ? 0 : reader.GetValue(0));
                        this.ActualizarCompetencias(0, Convert.ToDecimal(reader.GetValue(0)), 0, evaluacion, empleado);
                    }
                }
            }
            else
            {
                resultado = 0;
            }
            return resultado;
        }

        public void ActualizaPuntuacion(decimal resultado, int evaluacion, int empleado,int Periodo)
        {
            con.CerrarConexion();
            comando.Connection = con.AbrirConexion();
            comando.CommandText = "OCKO_ActualizaExamen";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@resultado", resultado);
            comando.Parameters.AddWithValue("@empleado", empleado);
            comando.Parameters.AddWithValue("@evaluacion", evaluacion);
            comando.Parameters.AddWithValue("@fecha", DateTime.Now);
            if(Periodo != 0)
                comando.Parameters.AddWithValue("@Periodo", Periodo);
            else
                comando.Parameters.AddWithValue("@Periodo", DBNull.Value);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            con.CerrarConexion();           
        }
        // google Chaert
        public SqlCommand TotalesEvaluacion(int EvaluacionId)
        {
            con.CerrarConexion();
            comando.Connection = con.AbrirConexion();
            comando.CommandText = "OCKO_TotalesEvaluacion";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@evaluacionId", EvaluacionId);
  
            return comando;
        }

        public SqlCommand TotalesEvaluacionxCedula(int EvaluacionId =0,string Cedula="")
        {
            con.CerrarConexion();
            comando.Connection = con.AbrirConexion();
            comando.CommandText = "OCKO_TotalesEvaluacionPorCedula";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@evaluacionId", EvaluacionId);
            comando.Parameters.AddWithValue("@Cedula", Cedula);
            return comando;
        }

        //Google Charte end

        public void GenerarRespuestas()
        {
            con.CerrarConexion();
            comando.Connection = con.AbrirConexion();
            comando.CommandText = "OCKO_InsertarItems";
            comando.CommandType = CommandType.StoredProcedure;
            comando.ExecuteNonQuery();
            con.CerrarConexion();
        }


        //Procedimiento Asignacion de evaluacion por cargo
        public String EvaluacionXCargo(int cargo, int evaluacion)
        {
            String resultado = "" ;
            SqlCommand comando = new SqlCommand();
            comando.Connection = con.AbrirConexion();
            comando.CommandText = "OCKO_InsertaEvaluacionCargo";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Cargo", cargo);
            comando.Parameters.AddWithValue("@evaluacion", evaluacion);
            SqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    resultado = reader.ToString();
                }
            return resultado;
        }

        public void GuardaUsuario(int RolDesempeño)
        {

            comando.Connection = con.AbrirConexion();
            comando.CommandText = "OCKO_InsertarUsuario";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@RolDesempeno", RolDesempeño);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            con.CerrarConexion();
        }

    }
}
