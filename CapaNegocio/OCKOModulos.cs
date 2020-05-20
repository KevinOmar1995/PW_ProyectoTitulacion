using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaNegocio;
namespace CapaNegocio
{
    public class OCKOModulos
    {
        public static OCKO_EvaluacionDataContext OckoDc = new OCKO_EvaluacionDataContext();
        public OCKO_TblModulos BuscarIdModulos(int id)
        {
            var Modulos = OckoDc.OCKO_TblModulos.First(u => u.ModId == id);
            return Modulos;
        }

        public void GuardarModulos(OCKO_TblModulos Modulos)
        {
            OckoDc.OCKO_TblModulos.InsertOnSubmit(Modulos);
            OckoDc.SubmitChanges();
        }
        public void EliminarModulos(OCKO_TblModulos Modulos)
        {
            OckoDc.OCKO_TblModulos.DeleteOnSubmit(Modulos);
            OckoDc.SubmitChanges();
        }
        public void ActualizarModulos(OCKO_TblModulos Modulos)
        {
            OckoDc.SubmitChanges();
        }

        public static bool BuscarModulosxNombre(string Modulos)
        {
            var pre = OckoDc.OCKO_TblModulos.Any(u => u.ModNombre == Modulos);
            return pre;
        }

        public List<OCKO_TblModulos> ListaModulos()
        {
            return OckoDc.OCKO_TblModulos.ToList();
        }

    }
}
