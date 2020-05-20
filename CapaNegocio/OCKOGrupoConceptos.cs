using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaNegocio;

namespace CapaNegocio
{
    public class OCKOGrupoConceptos
    {

        public static OCKO_EvaluacionDataContext OckoDc = new OCKO_EvaluacionDataContext();
        public OCKO_TblGrupoConceptos BuscarIdGrupoCategoria(int id)
        {
            var usu = OckoDc.OCKO_TblGrupoConceptos.First(u => u.GruId == id);
            return usu;
        }


        public List<OCKO_TblGrupoConceptos> ListarGrupoConcepto()
        {
            return OckoDc.OCKO_TblGrupoConceptos.ToList();
        }

        public void GuardarGrupoCategoria(OCKO_TblGrupoConceptos Grupo)
        {
            OckoDc.OCKO_TblGrupoConceptos.InsertOnSubmit(Grupo);
            OckoDc.SubmitChanges();
        }
        public void EliminarGrupoCategoria(OCKO_TblGrupoConceptos Grupo)
        {
            OckoDc.OCKO_TblGrupoConceptos.DeleteOnSubmit(Grupo);
            OckoDc.SubmitChanges();
        }
        public void ActualizarGrupoCategoria(OCKO_TblGrupoConceptos Grupo)
        {
            OckoDc.SubmitChanges();
        }

        public static bool BuscarGrupoCategoria(string GrupoCategoria)
        {
            var pre = OckoDc.OCKO_TblGrupoConceptos.Any(u => u.GruNombre == GrupoCategoria);
            return pre;
        }

        public static int  SumaPorcentaje()
        {
            var resultado = OckoDc.OCKO_TblGrupoConceptos.ToList();
            var suma = resultado.Sum(x => x.GruPeso);
            return suma;
        }


    }
}
