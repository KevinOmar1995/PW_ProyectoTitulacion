using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaNegocio;
namespace CapaNegocio
{
    public class OCKOSeccion
    {
        public static OCKO_EvaluacionDataContext OckoDc = new OCKO_EvaluacionDataContext();
        public OCKO_TblSeccion BuscarIdSeccion(int id)
        {
            var Seccion = OckoDc.OCKO_TblSeccion.First(u => u.SecId == id);
            return Seccion;
        }

        public void GuardarSeccion(OCKO_TblSeccion Seccion)
        {
            OckoDc.OCKO_TblSeccion.InsertOnSubmit(Seccion);
            OckoDc.SubmitChanges();
        }
        public void EliminarSeccion(OCKO_TblSeccion Seccion)
        {
            OckoDc.OCKO_TblSeccion.DeleteOnSubmit(Seccion);
            OckoDc.SubmitChanges();
        }
        public void ActualizarSeccion(OCKO_TblSeccion Seccion)
        {
            OckoDc.SubmitChanges();
        }

        public static bool BuscarSeccion(string Seccion)
        {
            var pre = OckoDc.OCKO_TblSeccion.Any(u => u.SecNombre == Seccion);
            return pre;
        }
    }
}
