﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
namespace CapaNegocio
{
     public class OCKO_TipoEvaluacion
    {

        public static OCKO_EvaluacionDataContext OckoDc = new OCKO_EvaluacionDataContext();
        //Buscar por Id Evaluacion
        public OCKO_TblTipoEvaluacion BuscarIdTipoEvaluacion(int id)
        {
            var usu = OckoDc.OCKO_TblTipoEvaluacion.First(u => u.TipId == id);
            return usu;
        }
        //Eliminar

        public void eliminarEvaluacion(OCKO_TblTipoEvaluacion usu)
        {
            OckoDc.OCKO_TblTipoEvaluacion.DeleteOnSubmit(usu);
            OckoDc.SubmitChanges();
        }

        //Editar 
        public void EditarEvaluacion(OCKO_TblTipoEvaluacion evaluacion)
        {
            OckoDc.SubmitChanges();
        }
        //GuArdar
        public void GuardarEvaluacion(OCKO_TblTipoEvaluacion evaluacion)
        {
            OckoDc.OCKO_TblTipoEvaluacion.InsertOnSubmit(evaluacion);
            OckoDc.SubmitChanges();
        }
        //Listar Evaluacion 
        public List<OCKO_TblTipoEvaluacion> listaEvaluacion()
        {
            return OckoDc.OCKO_TblTipoEvaluacion.ToList();
        }

    }
}
