using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaDatos;
using CapaNegocio;

namespace PW_ProyectoTitulacion.pruebas
{
    public partial class final : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Clock_Tick(object sender, EventArgs e)
        {
            Examen exa = new Examen();
            if (Convert.ToInt32(Session["tiempo"]) != 0)
            {
                decimal s = Convert.ToDecimal(Session["tiempo"]);
                Reloj.Text = contador(s);
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
    }
}