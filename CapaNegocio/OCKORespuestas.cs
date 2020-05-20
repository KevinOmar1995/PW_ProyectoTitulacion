using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaNegocio;

namespace CapaNegocio
{
    public class OCKORespuestas
    {
        public static OCKO_EvaluacionDataContext OckoDc = new OCKO_EvaluacionDataContext();
        //Buscar por Id Evaluacion
        public OCKO_TblRespuestas BuscarIdRespuestas(int id)
        {
            var usu = OckoDc.OCKO_TblRespuestas.First(u => u.ResId == id);
            return usu;
        }

        //Eliminar
        public void eliminarRespuestas(OCKO_TblRespuestas Evaluacion)
        {
            OckoDc.OCKO_TblRespuestas.DeleteOnSubmit(Evaluacion);
            //comand.Tbl_Persona.DeleteOnSubmit(Evaluacion.Tbl_Persona);
            OckoDc.SubmitChanges();
        }
        //Editar 
        public void EditarRespuestas(OCKO_TblRespuestas evaluacion)
        {
            OckoDc.SubmitChanges();
        }
        //GuArdar
        public void GuardarRespuestas(OCKO_TblRespuestas evaluacion)
        {
            OckoDc.OCKO_TblRespuestas.InsertOnSubmit(evaluacion);
            OckoDc.SubmitChanges();
        }

    }
}
