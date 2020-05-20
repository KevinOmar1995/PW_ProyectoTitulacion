using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
namespace CapaNegocio
{
    public class Examen
    {
        public string agregaCero(string n)
        {
            if (n.ToString().Length < 2)
            {
                return '0' + n;
            }
            else
            {
                return n;
            }
        }

       

    }
}
