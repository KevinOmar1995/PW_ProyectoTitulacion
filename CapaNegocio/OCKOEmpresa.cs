using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaNegocio;
namespace CapaNegocio
{
    public  class OCKOEmpresa
    {
        public static OCKO_EvaluacionDataContext OckoDc = new OCKO_EvaluacionDataContext();
        public OCKO_TblEmpresa BuscarIdEmpresa(int id)
        {
            var usu = OckoDc.OCKO_TblEmpresa.First(u => u.EmpId == id);
            return usu;
        }

        public void GuardarEmpresa(OCKO_TblEmpresa Usuario)
        {
            OckoDc.OCKO_TblEmpresa.InsertOnSubmit(Usuario);
            OckoDc.SubmitChanges();
        }
        public void EliminarEmpresa(OCKO_TblEmpresa usu)
        {
            OckoDc.OCKO_TblEmpresa.DeleteOnSubmit(usu);
            OckoDc.SubmitChanges();
        }
        public void ActualizarEmpresa(OCKO_TblEmpresa usu)
        {
            OckoDc.SubmitChanges();
        }

        public static bool BuscarEmpresaxNombre(string Empresa)
        {
            var pre = OckoDc.OCKO_TblEmpresa.Any(u => u.EmpNombre == Empresa);
            return pre;
        }
    }
}
