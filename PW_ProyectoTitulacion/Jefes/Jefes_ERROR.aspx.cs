using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PW_ProyectoTitulacion.Jefes
{
    public partial class Jefes_ERROR : System.Web.UI.Page
    {
        public string error;
        protected void Page_Load(object sender, EventArgs e)
        {
            error = Session["ERROR_JEFES"].ToString();
        }
    }
}