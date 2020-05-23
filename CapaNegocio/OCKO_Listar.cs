using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
namespace CapaNegocio
{
    public class OCKO_Listar
    {
        OCKO_EvaluacionDataContext ockoListar = new OCKO_EvaluacionDataContext();
        //Listar todos empleados
        public List<OCKO_TblEmpleado> ListarEmpleados()
        {
            var lista = ockoListar.OCKO_TblEmpleado.Where(li => li.EmpJefe.Equals('Y'));
            return lista.ToList();
        }
        public List<OCKO_TblUsuario> ListarUsuario()
        {
            var listaUsuario = ockoListar.OCKO_TblUsuario.Where(li => li.UsuEstado.Equals('A'));
            return listaUsuario.ToList();
        }

        public List<OCKO_TblEmpresa> ListarEmpresa()
        {
            return ockoListar.OCKO_TblEmpresa.ToList();
        }

        public List<OCKO_TblCategoriaPregunta> ListarCategoria()
        {
            return ockoListar.OCKO_TblCategoriaPregunta.ToList();
        }

        public List<OCKO_TblEmpleado> ListarJefeInmediato(int cargo)
        {
            var listaUsuario = ockoListar.OCKO_TblEmpleado.Where(li => li.CodCargo == cargo && li.EmpJefe.Equals("Y") );
            return listaUsuario.ToList();
        }
        public List<OCKO_TblEmpleado> ListarACargoInmediato(int jefeId)
        {
            var listaUsuario = ockoListar.OCKO_TblEmpleado.Where(li => li.EmpJefeId == jefeId && li.EmpJefe.Equals("N"));
            return listaUsuario.ToList();
        }
    }
}
