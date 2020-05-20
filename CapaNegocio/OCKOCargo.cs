using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaNegocio;
namespace CapaNegocio
{
    public class OCKOCargo
    {
        public static OCKO_EvaluacionDataContext OckoDc = new OCKO_EvaluacionDataContext();
        //Listar Cargo
        public List<OCKO_TblCargo> listaCargos()
        {
            return OckoDc.OCKO_TblCargo.ToList();
        }
    }
}
