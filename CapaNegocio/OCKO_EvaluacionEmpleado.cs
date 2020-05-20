using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;

namespace CapaNegocio
{
    public class OCKO_EvaluacionEmpleado
    {
        public static OCKO_EvaluacionDataContext OckoDc = new OCKO_EvaluacionDataContext();
        //Buscar por Id Evaluacion
        public OCKO_TblEvaluacionEmpleado BuscarIdEmpleado(int id)
        {
            var usu = OckoDc.OCKO_TblEvaluacionEmpleado.First(u => u.CodEmpleado == id);
            return usu;
        }
        //verificar si ya exsite una evaluacion asignada a X empleado
        public static bool AsignacionEvaluacion(int IdEmpleado,int IdEvaluacion)
        {
            var auto = OckoDc.OCKO_TblEvaluacionEmpleado.Any(eva => eva.CodEmpleado== IdEmpleado && eva.CodTipoEvaluacion== IdEvaluacion);
            return auto;
        }
        //Eliminar
        public void eliminarEvaluacionEmpleado(OCKO_TblEvaluacionEmpleado Evaluacion)
        {
            OckoDc.OCKO_TblEvaluacionEmpleado.DeleteOnSubmit(Evaluacion);
            //comand.Tbl_Persona.DeleteOnSubmit(Evaluacion.Tbl_Persona);
            OckoDc.SubmitChanges();
        }
        //Editar 
        public void EditarEvaluacionEmpleado(OCKO_TblEvaluacionEmpleado evaluacion)
        {
            OckoDc.SubmitChanges();
        }
        //GuArdar
        public void GuardarEvaluacionEmpleado(OCKO_TblEvaluacionEmpleado evaluacion)
        {
            OckoDc.OCKO_TblEvaluacionEmpleado.InsertOnSubmit(evaluacion);
            OckoDc.SubmitChanges();
        }
       
    
    }
}
