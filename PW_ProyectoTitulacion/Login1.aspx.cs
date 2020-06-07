using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Security;
using System.Configuration;
using CapaDatos;
using CapaNegocio;
using System.Text;

namespace PW_ProyectoTitulacion
{
    public partial class Login1 : System.Web.UI.Page
    {
        OCKOEmpleadoUsuario usuarioClass = new OCKOEmpleadoUsuario();
        protected void Page_Load(object sender, EventArgs e)
        {
            string a = "";
        }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {

            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["OCKO_EvaluacionPersonal"].ToString()))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "OCKO_Acceso";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cn;
                cmd.Parameters.AddWithValue("@usuario", Login.UserName);
                cmd.Parameters.AddWithValue("@contraseña", Login.Password);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Session["Username"] = reader.GetValue(0);
                        Session["tipo"] = reader.GetValue(1);
                        Session["JefeIdEva"] = reader.GetValue(2);
                        

                        int jefeId = Convert.ToInt32(Session["tipo"].ToString());
                        Session["EmpId"] = reader.GetValue(2);
                        if (jefeId == 3 || jefeId == 4)
                            Session["IdJefe"] = jefeId;
                        else if (jefeId == 5 || jefeId == 6)
                            Session["PM"] = reader.GetValue(2);
                        else
                            Session["IdEmpleado"] = reader.GetValue(2);

                    }
                    e.Authenticated = true;
                }
                else
                {
                    if (!usuarioClass.BuscarUsuario(Login.UserName))
                    {
                        Response.Write("<script language=javascript>alert('Usuario no Registrado');</script>");
                    }
                    else
                    {
                        Response.Write("<script language=javascript>alert('Usuario o Contraseña Incorrecta..!');</script>");
                        e.Authenticated = false;
                    }

                }
            }
        }
        protected void Login1_LoggedIn(object sender, EventArgs e)
        {
            int tipo = Convert.ToInt32(Session["tipo"].ToString());
            if (tipo == 1)
            {
               
                Response.Redirect("./RRHH/RRHH_Index.aspx");
            }
            else if (tipo == 2)
            {
               
                Response.Redirect("./PM/PM_Inicio.aspx");
            }
            else if (tipo == 5 || tipo == 6)
            {
                Session["tiempo"] = 120;
                
                Response.Redirect("./Empleados/Empleado_Inicio.aspx");
            }
            else if (tipo == 3 || tipo == 4)
            {
                Session["tiempo"] = 120;
              
                Response.Redirect("./Jefes/Jefes_Inicio.aspx");
            }
            else
            {
               
                // si es un empleado o estudiante
                //Session["tiempo"] = 120;
                Response.Redirect("./Administrador/Admin_Incio.aspx");
            }
        }


    }
}