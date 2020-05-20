using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaNegocio;
namespace CapaNegocio
{
    public class OCKOPeriodos
    {
        public static OCKO_EvaluacionDataContext OckoDc = new OCKO_EvaluacionDataContext();
        //Buscar por Id Perido
        public static bool BuscarPeriodo(string perido)
        {
            var pre = OckoDc.OCKO_TblPeriodo.Any(u => u.PerPeriodo == perido);
            return pre;
        }

        public static bool ValidarFechasExistentes(DateTime   FechaIncio,DateTime FechaFin)
        {
            var pre = OckoDc.OCKO_TblPeriodo.Any(u => u.PerFechaFin >= FechaIncio &&  u.PerFechaFin <= FechaFin);
            return pre;
        }

        public OCKO_TblPeriodo BuscarIdPerido(int id)
        {
            var usu = OckoDc.OCKO_TblPeriodo.First(u => u.PerId == id);
            return usu;
        }

        //Eliminar
        public void eliminarPeriodo(OCKO_TblPeriodo Periodo)
        {
            OckoDc.OCKO_TblPeriodo.DeleteOnSubmit(Periodo);
            //comand.Tbl_Persona.DeleteOnSubmit(Evaluacion.Tbl_Persona);
            OckoDc.SubmitChanges();
        }
        //Editar 
        public void EditarPeriodo(OCKO_TblPeriodo Periodo)
        {
            OckoDc.SubmitChanges();
        }
        //GuArdar
        public void GuardarPeriodo(OCKO_TblPeriodo Periodo)
        {
            OckoDc.OCKO_TblPeriodo.InsertOnSubmit(Periodo);
            OckoDc.SubmitChanges();
        }
        //Listar Evaluacion 
        public List<OCKO_TblPeriodo> ListarPeriodo()
        {
            return OckoDc.OCKO_TblPeriodo.ToList();
        }
    }
}
