using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaNegocio;
namespace CapaNegocio
{
    public class OCKOAsignacion
    {
        public static OCKO_EvaluacionDataContext OckoDc = new OCKO_EvaluacionDataContext();
        public OCKO_TblAsignacion BuscarIdAsignacion(int id)
        {
            var Asignacion = OckoDc.OCKO_TblAsignacion.First(u => u.AsiId == id);
            return Asignacion;
        }

        public void GuardarAsignacion(OCKO_TblAsignacion Asignacion)
        {
            OckoDc.OCKO_TblAsignacion.InsertOnSubmit(Asignacion);
            OckoDc.SubmitChanges();
        }
        public void EliminarAsignacion(OCKO_TblAsignacion Asignacion)
        {
            OckoDc.OCKO_TblAsignacion.DeleteOnSubmit(Asignacion);
            OckoDc.SubmitChanges();
        }
        public void ActualizarAsignacion(OCKO_TblAsignacion Asignacion)
        {
            OckoDc.SubmitChanges();
        }

        public static bool BuscarAsignacionxNombre(string Asignacion)
        {
            var pre = OckoDc.OCKO_TblAsignacion.Any(u => u.AsiDescripcion == Asignacion);
            return pre;
        }

        public List<OCKO_TblAsignacion> ListaAsignacion()
        {
            return OckoDc.OCKO_TblAsignacion.ToList();
        }

    }
}
