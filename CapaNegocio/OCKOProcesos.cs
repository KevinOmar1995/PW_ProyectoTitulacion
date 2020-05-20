using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaNegocio;
namespace CapaNegocio
{
    public class OCKOProcesos
    {
        public static OCKO_EvaluacionDataContext OckoDc = new OCKO_EvaluacionDataContext();
        public OCKO_TblProceso BuscarIdProceso(int id)
        {
            var Proceso = OckoDc.OCKO_TblProceso.First(u => u.ProId == id);
            return Proceso;
        }

        public void GuardarProceso(OCKO_TblProceso Proceso)
        {
            OckoDc.OCKO_TblProceso.InsertOnSubmit(Proceso);
            OckoDc.SubmitChanges();
        }
        public void EliminarProceso(OCKO_TblProceso Proceso)
        {
            OckoDc.OCKO_TblProceso.DeleteOnSubmit(Proceso);
            OckoDc.SubmitChanges();
        }
        public void ActualizarProceso(OCKO_TblProceso Proceso)
        {
            OckoDc.SubmitChanges();
        }

        public static bool BuscarProcesoxNombre(string Proceso)
        {
            var pre = OckoDc.OCKO_TblProceso.Any(u => u.ProNombre == Proceso);
            return pre;
        }

        public List<OCKO_TblProceso> ListaProceso()
        {
            return OckoDc.OCKO_TblProceso.ToList();
        }
    }
}
