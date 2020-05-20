using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaNegocio;
namespace CapaNegocio
{
    public class OCKOProyecto
    {
        public static OCKO_EvaluacionDataContext OckoDc = new OCKO_EvaluacionDataContext();
        public OCKO_TblProyecto BuscarIdProyecto(int id)
        {
            var Proyecto = OckoDc.OCKO_TblProyecto.First(u => u.ProId == id);
            return Proyecto;
        }

        public void GuardarProyecto(OCKO_TblProyecto Proyecto)
        {
            OckoDc.OCKO_TblProyecto.InsertOnSubmit(Proyecto);
            OckoDc.SubmitChanges();
        }
        public void EliminarProyecto(OCKO_TblProyecto Proyecto)
        {
            OckoDc.OCKO_TblProyecto.DeleteOnSubmit(Proyecto);
            OckoDc.SubmitChanges();
        }
        public void ActualizarProyecto(OCKO_TblProyecto Proyecto)
        {
            OckoDc.SubmitChanges();
        }

        public static bool BuscarProyectoxNombre(string Proyecto)
        {
            var pre = OckoDc.OCKO_TblProyecto.Any(u => u.ProNombre == Proyecto);
            return pre;
        }

        public List<OCKO_TblProyecto> ListaProyecto()
        {
            return OckoDc.OCKO_TblProyecto.ToList();
        }

    }
}
