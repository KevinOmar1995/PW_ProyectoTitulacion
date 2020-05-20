using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaNegocio;
namespace CapaNegocio
{
    public class OCKOCategoria
    {
        public static OCKO_EvaluacionDataContext OckoDc = new OCKO_EvaluacionDataContext();
        public OCKO_TblCategoriaPregunta BuscarIdCategoria(int id)
        {
            var usu = OckoDc.OCKO_TblCategoriaPregunta.First(u => u.CatId == id);
            return usu;
        }

        public int   BuscarIdCategoriaPercent(int id)
        {
            var usu = OckoDc.OCKO_TblCategoriaPregunta.First(u => u.CatId == id).OCKO_TblGrupoConceptos.GruPeso;
            return usu;
        }

        public void GuardarCategoria(OCKO_TblCategoriaPregunta Usuario)
        {
            OckoDc.OCKO_TblCategoriaPregunta.InsertOnSubmit(Usuario);
            OckoDc.SubmitChanges();
        }
        public void EliminarCategoria(OCKO_TblCategoriaPregunta usu)
        {
            OckoDc.OCKO_TblCategoriaPregunta.DeleteOnSubmit(usu);
            OckoDc.SubmitChanges();
        }
        public void ActualizarCategoria(OCKO_TblCategoriaPregunta usu)
        {
            OckoDc.SubmitChanges();
        }

        public static bool BuscarCategoria(string  categoria)
        {
            var pre = OckoDc.OCKO_TblCategoriaPregunta.Any(u => u.CatNombre == categoria);
            return pre;
        }

    }
}
