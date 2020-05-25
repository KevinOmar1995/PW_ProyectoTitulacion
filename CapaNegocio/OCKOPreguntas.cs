using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaNegocio;

namespace CapaNegocio
{
    public class OCKOPreguntas
    {
        public static OCKO_EvaluacionDataContext OckoDc = new OCKO_EvaluacionDataContext();
        //Buscar por Id Evaluacion
        public static  bool  BuscarPregunta(string pregunta)
        {
            var pre = OckoDc.OCKO_TblPreguntas.Any(u => u.PrePregunta == pregunta);
            return pre;
        }

        public OCKO_TblPreguntas BuscarIdPregunta(int id)
        {
            var usu = OckoDc.OCKO_TblPreguntas.First(u => u.PreId == id);
            return usu;
        }

        public OCKO_TblPreguntas BuscarCategoriaiD(int PreId,int CodTipoEvaluacion)
        {
            var usu = OckoDc.OCKO_TblPreguntas.First(u => u.PreId == PreId && u.CodTipoEvaluacion == CodTipoEvaluacion);
            return usu;
        }

        //Eliminar
        public void eliminarPregunta(OCKO_TblPreguntas Evaluacion)
        {
            OckoDc.OCKO_TblPreguntas.DeleteOnSubmit(Evaluacion);
            //comand.Tbl_Persona.DeleteOnSubmit(Evaluacion.Tbl_Persona);
            OckoDc.SubmitChanges();
        }
        //Editar 
        public void EditarPregunta(OCKO_TblPreguntas evaluacion)
        {
            OckoDc.SubmitChanges();
        }
        //GuArdar
        public void GuardarPregunta(OCKO_TblPreguntas evaluacion)
        {
            OckoDc.OCKO_TblPreguntas.InsertOnSubmit(evaluacion);
            OckoDc.SubmitChanges();
        }
        //Listar Evaluacion 
        public List<OCKO_TblPreguntas> listaPreguntas(int evaluacion)
        {
            var lista = OckoDc.OCKO_TblPreguntas.Where(eva => eva.CodTipoEvaluacion == evaluacion);
            return lista.ToList();
        }

    }
}
