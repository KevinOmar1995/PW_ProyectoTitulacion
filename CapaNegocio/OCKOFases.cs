using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaNegocio;
namespace CapaNegocio
{
    public class OCKOFases
    {
        public static OCKO_EvaluacionDataContext OckoDc = new OCKO_EvaluacionDataContext();
        public OCKO_TblFase BuscarIdFases(int id)
        {
            var Fases = OckoDc.OCKO_TblFase.First(u => u.FasId == id);
            return Fases;
        }

        public void GuardarFases(OCKO_TblFase Fases)
        {
            OckoDc.OCKO_TblFase.InsertOnSubmit(Fases);
            OckoDc.SubmitChanges();
        }
        public void EliminarFases(OCKO_TblFase Fases)
        {
            OckoDc.OCKO_TblFase.DeleteOnSubmit(Fases);
            OckoDc.SubmitChanges();
        }
        public void ActualizarFases(OCKO_TblFase Fases)
        {
            OckoDc.SubmitChanges();
        }

        public static bool BuscarFasesxNombre(string Fases)
        {
            var pre = OckoDc.OCKO_TblFase.Any(u => u.FasNombre == Fases);
            return pre;
        }

        public List<OCKO_TblFase> ListaFases()
        {
            return OckoDc.OCKO_TblFase.ToList();
        }

    }
}
